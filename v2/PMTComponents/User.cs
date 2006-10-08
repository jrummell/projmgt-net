using System;
using System.Data;
using System.Data.SqlClient;
using System.Reflection;
using MySql;
using MySql.Data;
using MySql.Data.MySqlClient;

namespace PMTComponents
{
    /// <summary>
    /// User Roles
    /// </summary>
    public enum PMTUserRole { Client=0, Developer, Manager, Administrator }

    /// <summary>
    /// Developer Competency Levels
    /// </summary>
    public enum CompLevel { Low=0, Medium, High }

    /// <summary>
    /// Project Management .Net User Base Class
    /// </summary>
    public class PMTUser : ICloneable
    {
        #region Attributes
        private string userName;
        private string password;
        private int id;
        private PMTUserRole role;
        private string firstName;
        private string lastName;
        private string email;
        private string phone;
        private string address;
        private string city;
        private string state;
        private string zip;
        private bool enabled;
        private int managerID;
        #endregion

        #region Constructors
        /// <summary>
        /// Main constructor
        /// </summary>
        /// <param name="id">User ID</param>
        /// <param name="user">Username</param>
        /// <param name="pwd">Encrypted Password</param>
        /// <param name="role">Role (Security)</param>
        /// <param name="firstName">First Name</param>
        /// <param name="lastName">Last Name</param>
        /// <param name="email">Email Address</param>
        /// <param name="phone">Phone Number</param>
        /// <param name="address">Street Address</param>
        /// <param name="city">City</param>
        /// <param name="state">State</param>
        /// <param name="zip">Zip Code</param>
        /// <param name="enabled">Is the user enabled?</param>
        /// <param name="managerID">Manager's ID</param>
        public PMTUser(int id, string user, string pwd, PMTUserRole role, string firstName, string lastName, 
            string email, string phone, string address, string city, string state, string zip, bool enabled, int managerID)
        {
            this.userName = user;
            this.password = pwd;
            this.id = id;
            this.role = role;
            this.firstName = firstName;
            this.lastName = lastName;
            this.email = email;
            this.phone = phone;
            this.address = address;
            this.city = city;
            this.state = state;
            this.zip = zip;
            this.enabled = enabled;
        }

        /// <summary>
        /// Default Constructor. Creates a blank PMTUser
        /// </summary>
        public PMTUser()
            : this (0, String.Empty, String.Empty, 0, String.Empty, String.Empty, String.Empty, String.Empty, String.Empty, String.Empty, String.Empty, String.Empty, false, 0) {}
        #endregion

        public static PMTUser CreatePMTUser(PMTUserRole role)
        {
            Type t = Type.GetType(role.ToString());
            ConstructorInfo constructor = t.GetConstructor(Type.EmptyTypes);
            return (PMTUser)constructor.Invoke(new Object[0]);
        }

        #region Properties
        /// <summary>
        /// Gets or sets the ID
        /// </summary>
        public int ID
        {
            get {	return id;	    }
            set {   id = value;     }
        }
        /// <summary>
        /// Gets or sets the **Encrypted** password
        /// </summary>
        public string Password
        {
            get {   return password;    }
            set {   password = value;   }
        }
        /// <summary>
        /// Gets or sets the first name
        /// </summary>
        public string FirstName
        {
            get {   return firstName;	    }
            set {   firstName = value;      }
        }
        /// <summary>
        /// Gets or sets the last name
        /// </summary>
        public string LastName
        {
            get {	return lastName;    }
            set {   lastName = value;   }
        }
        /// <summary>
        /// Gets or sets the username
        /// </summary>
        public string UserName
        {
            get {	return userName;    }
            set {   userName = value;   }
        }
        /// <summary>
        /// Gets or sets the street address
        /// </summary>
        public string Address
        {
            get {   return address;     }
            set {   address = value;    }
        }
        /// <summary>
        /// Gets or sets the city
        /// </summary>
        public string City
        {
            get	{   return city;    }
            set {   city = value;   }
        }
        /// <summary>
        /// Getsor sets the state
        /// </summary>
        public string State
        {
            get {   return state;   }
            set {   state = value;  }
        }
        /// <summary>
        /// Gets or sets the zip code
        /// </summary>
        public string ZipCode
        {
            get {   return zip;     }
            set {   zip = value;    }
        }
        /// <summary>
        /// Gets or sets the phone number
        /// </summary>
        public string PhoneNumber
        {
            get {   return phone;	}
            set {   phone = value;  }
        }
        /// <summary>
        /// Gets or sets the email address
        /// </summary>
        public string Email
        {
            get {   return email;	}
            set {   email = value;  }
        }
        /// <summary>
        /// Gets or sets the role (security level)
        /// </summary>
        public PMTUserRole Role
        {
            get {   return role;    }
            set {   role = value;   }
        }
        /// <summary>
        /// Gets or sets if the user is approved
        /// </summary>
        public bool Enabled
        {
            get {   return enabled;    }
            set {   enabled = value;   }
        }

        public int ManagerID
        {
            get { return managerID; }
            set { managerID = value; }
        }
        #endregion

        #region ICloneable Members
        object ICloneable.Clone()
        {
            // delegate to type safe Clone()
            return this.Clone();
        }

        public virtual PMTUser Clone()
        {
            PMTUser copy = (PMTUser)this.MemberwiseClone();
            copy.UserName = UserName;
            copy.Password = Password;
            copy.ID = ID;
            copy.Role = Role;
            copy.FirstName = FirstName;
            copy.LastName = LastName;
            copy.Email = Email;
            copy.PhoneNumber = PhoneNumber;
            copy.Address = Address;
            copy.City = City;
            copy.State = State;
            copy.ZipCode = ZipCode;
            copy.Enabled = Enabled;

            return copy;
        }
        #endregion
    }

    /// <summary>
    /// Administrator
    /// </summary>
    public class Administrator : PMTUser
    {
        public Administrator() : base() 
        {
            Init();
        }

        public Administrator(PMTUser user)
            : base(user.ID, user.UserName, user.Password, user.Role, user.FirstName, user.LastName, user.Email,
            user.PhoneNumber, user.Address, user.City, user.State, user.ZipCode, user.Enabled, user.ManagerID)
        {
            Init();
        }

        private void Init()
        {
            this.Role = PMTUserRole.Administrator;
        }
    }

    /// <summary>
    /// Manager
    /// </summary>
    public class Manager : PMTUser
    {
        public Manager() : base() 
        {
            Init();
        }

        public Manager(PMTUser user)
            : base(user.ID, user.UserName, user.Password, user.Role, user.FirstName, user.LastName, user.Email,
            user.PhoneNumber, user.Address, user.City, user.State, user.ZipCode, user.Enabled, user.ManagerID)
        {
            Init();
        }

        private void Init()
        {
            this.Role = PMTUserRole.Manager;
        }
    }

    /// <summary>
    /// Developer
    /// </summary>
    public class Developer : PMTUser
    {
        private CompLevel compentency;

        /// <summary>
        /// Creates a blank Developer.
        /// </summary>
        public Developer() : base()
        {
            Init();
        }

        /// <summary>
        /// Creates a Developer from a PMTUser.
        /// </summary>
        public Developer(PMTUser user)
            : base(user.ID, user.UserName, user.Password, user.Role, user.FirstName, user.LastName, user.Email,
            user.PhoneNumber, user.Address, user.City, user.State, user.ZipCode, user.Enabled, user.ManagerID)
        {
            Init();
        }

        private void Init()
        {
            this.Role = PMTUserRole.Developer;
            this.Competency = CompLevel.Low;
        }

        /*
        public Developer(int id, string user, string pwd, string firstName, 
            string lastName, string email, string phone, string address, 
            string city, string state, string zip, bool enabled, 
            CompLevel competency, int managerID)
            : base(id, user, pwd, PMTUserRole.Developer, 
            firstName, lastName, email, phone, address, city, state, zip, enabled)
        {
            this.Competency = compentency;
            this.ManagerID = managerID;
        }
        */

        public CompLevel Competency
        {
            get { return compentency; }
            set { compentency = value; }
        }
    }

    /// <summary>
    /// Client
    /// </summary>
    public class Client : PMTUser
    {
        public Client() : base() 
        {
            Init();
        }

        public Client(PMTUser user)
            : base(user.ID, user.UserName, user.Password, user.Role, user.FirstName, user.LastName, user.Email,
            user.PhoneNumber, user.Address, user.City, user.State, user.ZipCode, user.Enabled, user.ManagerID)
        {
            Init();
        }

        private void Init()
        {
            this.Role = PMTUserRole.Client;
        }
    }
}
