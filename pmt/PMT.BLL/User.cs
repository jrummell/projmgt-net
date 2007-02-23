using System;
using System.Collections.Generic;
using System.Text;
using System.Reflection;
using PMT.DAL;
using PMT.DAL.UsersDataSetTableAdapters;
using System.Web;

namespace PMT.BLL
{
    /// <summary>
    /// User Roles
    /// </summary>
    public enum UserRole { Client = 0, Developer, Manager, Administrator }

    /// <summary>
    /// Developer Competency Levels
    /// </summary>
    public enum CompLevel { Low = 0, Medium, High }

    /// <summary>
    /// Project Management .Net User Base Class
    /// </summary>
    public abstract class User 
    {
        #region Attributes
        private string userName;
        private string password;
        private int id;
        private string firstName;
        private string lastName;
        private string email;
        private string phone;
        private string address;
        private string city;
        private string state;
        private string zip;
        private bool enabled;
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
        protected User(int id, string user, string pwd, string firstName, string lastName,
            string email, string phone, string address, string city, string state, string zip, bool enabled)
        {
            this.userName = user;
            this.password = pwd;
            this.id = id;
            //this.role = role;
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
        /// Default Constructor. Creates a blank User
        /// </summary>
        protected User()
            : this(0, String.Empty, String.Empty, String.Empty, String.Empty, String.Empty, String.Empty, String.Empty, String.Empty, String.Empty, String.Empty, false) { }
        #endregion

        /// <summary>
        /// Creates the user.
        /// </summary>
        /// <param name="role">The role.</param>
        /// <returns></returns>
        public static User CreateUser(UserRole role)
        {
            Type t = Type.GetType(typeof(User).Namespace + "." + role.ToString());
            ConstructorInfo constructor = t.GetConstructor(Type.EmptyTypes);
            return (User)constructor.Invoke(new Object[0]);
        }

        /// <summary>
        /// Gets the cookie.
        /// </summary>
        /// <returns></returns>
        public HttpCookie GetCookie()
        {
            HttpCookie cookie = new HttpCookie("user");
            cookie.Values.Add("role", Role.ToString());
            cookie.Values.Add("id", ID.ToString());
            cookie.Values.Add("name", UserName);
            cookie.Values.Add("fname", FirstName);
            cookie.Values.Add("lname", LastName);

            return cookie;
        }

        #region Properties
        /// <summary>
        /// Gets or sets the ID
        /// </summary>
        public int ID
        {
            get { return id; }
            set { id = value; }
        }
        /// <summary>
        /// Gets or sets the **Encrypted** password
        /// </summary>
        public string Password
        {
            get { return password; }
            set { password = value; }
        }
        /// <summary>
        /// Gets or sets the first name
        /// </summary>
        public string FirstName
        {
            get { return firstName; }
            set { firstName = value; }
        }
        /// <summary>
        /// Gets or sets the last name
        /// </summary>
        public string LastName
        {
            get { return lastName; }
            set { lastName = value; }
        }
        /// <summary>
        /// Gets or sets the username
        /// </summary>
        public string UserName
        {
            get { return userName; }
            set { userName = value; }
        }
        /// <summary>
        /// Gets or sets the street address
        /// </summary>
        public string Address
        {
            get { return address; }
            set { address = value; }
        }
        /// <summary>
        /// Gets or sets the city
        /// </summary>
        public string City
        {
            get { return city; }
            set { city = value; }
        }
        /// <summary>
        /// Getsor sets the state
        /// </summary>
        public string State
        {
            get { return state; }
            set { state = value; }
        }
        /// <summary>
        /// Gets or sets the zip code
        /// </summary>
        public string ZipCode
        {
            get { return zip; }
            set { zip = value; }
        }
        /// <summary>
        /// Gets or sets the phone number
        /// </summary>
        public string PhoneNumber
        {
            get { return phone; }
            set { phone = value; }
        }
        /// <summary>
        /// Gets or sets the email address
        /// </summary>
        public string Email
        {
            get { return email; }
            set { email = value; }
        }
        /// <summary>
        /// Gets or sets the role (security level)
        /// </summary>
        public abstract UserRole Role
        {
            get;
        }
        /// <summary>
        /// Gets or sets if the user is approved
        /// </summary>
        public bool Enabled
        {
            get { return enabled; }
            set { enabled = value; }
        }
        #endregion
    }

    /// <summary>
    /// Administrator
    /// </summary>
    public class Administrator : User
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Administrator"/> class.
        /// </summary>
        public Administrator() {}

        /// <summary>
        /// Initializes a new instance of the <see cref="Administrator"/> class.
        /// </summary>
        /// <param name="user">The user.</param>
        public Administrator(User user)
            : base(user.ID, user.UserName, user.Password, user.FirstName, user.LastName, user.Email,
            user.PhoneNumber, user.Address, user.City, user.State, user.ZipCode, user.Enabled)
        {}

        /// <summary>
        /// Gets the role (security level)
        /// </summary>
        /// <value></value>
        public override UserRole Role
        {
            get { return UserRole.Administrator; }
        }
    }

    /// <summary>
    /// Manager
    /// </summary>
    public class Manager : User
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Manager"/> class.
        /// </summary>
        public Manager() { }

        /// <summary>
        /// Initializes a new instance of the <see cref="Manager"/> class.
        /// </summary>
        /// <param name="user">The user.</param>
        public Manager(User user)
            : base(user.ID, user.UserName, user.Password, user.FirstName, user.LastName, user.Email,
            user.PhoneNumber, user.Address, user.City, user.State, user.ZipCode, user.Enabled)
        {}
        /// <summary>
        /// Gets the role (security level)
        /// </summary>
        /// <value></value>
        public override UserRole Role
        {
            get { return UserRole.Manager; }
        }
    }

    /// <summary>
    /// Developer
    /// </summary>
    public class Developer : User
    {
        private CompLevel compentency;

        /// <summary>
        /// Creates a blank Developer.
        /// </summary>
        public Developer() { }

        /// <summary>
        /// Creates a Developer from a PMTUser.
        /// </summary>
        public Developer(User user)
            : base(user.ID, user.UserName, user.Password, user.FirstName, user.LastName, user.Email,
            user.PhoneNumber, user.Address, user.City, user.State, user.ZipCode, user.Enabled)
        {
            this.Competency = CompLevel.Low;
        }

        /// <summary>
        /// Gets or sets the competency.
        /// </summary>
        /// <value>The competency.</value>
        public CompLevel Competency
        {
            get { return compentency; }
            set { compentency = value; }
        }

        /// <summary>
        /// Gets the role (security level)
        /// </summary>
        /// <value></value>
        public override UserRole Role
        {
            get { return UserRole.Developer; }
        }
    }

    /// <summary>
    /// Client
    /// </summary>
    public class Client : User
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Client"/> class.
        /// </summary>
        public Client() { }

        /// <summary>
        /// Initializes a new instance of the <see cref="Client"/> class.
        /// </summary>
        /// <param name="user">The user.</param>
        public Client(User user)
            : base(user.ID, user.UserName, user.Password, user.FirstName, user.LastName, user.Email,
            user.PhoneNumber, user.Address, user.City, user.State, user.ZipCode, user.Enabled)
        { }

        /// <summary>
        /// Gets the role (security level)
        /// </summary>
        /// <value></value>
        public override UserRole Role
        {
            get { return UserRole.Client; }
        }
    }
}
