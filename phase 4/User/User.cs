using System;
using System.Data;
using System.Data.SqlClient;

namespace PMT
{
    /// <summary>
    /// Summary description for User.
    /// </summary>
    public class User
    {
        public struct Security
        {
            public const string ADMINISTRATOR = "Administrator";
            public const string PROJECT_MANAGER = "Project Manager";
            public const string DEVELOPER = "Developer";
            public const string CLIENT = "Client";
        };

        /// <summary>
        /// Username
        /// </summary>
        private string userName;
        private string password;
        private string id;
        /// <summary>
        /// Security (User Type)
        /// </summary>
        private string role;
        private string firstName;
        private string lastName;
        private string email;
        private string phone;
        private string address;
        private string city;
        private string state;
        private string zip;
        private DBDriver myDB;
        /// <summary>
        /// Create a new User
        /// </summary>
        /// <param name="un">The username</param>
        /// <param name="pwd">the Password</param>
        /// <param name="r">the security/role</param>
        /// <param name="fn">the first name</param>
        /// <param name="ln">the last name</param>
        /// <param name="em">the email address</param>
        /// <param name="ph">the phone number</param>
        /// <param name="ad">the address</param>
        /// <param name="c">the city</param>
        /// <param name="s">the state</param>
        /// <param name="z">thezip code</param>
        public User(string un, string pwd, string r, string fn, string ln, 
            string em, string ph, string ad, string c, string s, string z)
        {
            this.userName = un;
            this.password = Encryption.encrypt(pwd);
            //this.id = id;
            this.role = r;
            this.firstName=fn;
            this.lastName=ln;
            this.email=em;
            this.phone=ph;
            this.address=ad;
            this.city=c;
            this.state=s;
            this.zip=z;

            myDB=new DBDriver();
            myDB.Query = "insert into person (firstName, lastName, address, city, state, zip, phoneNumber, email) " +
                "values (@first,@last,@address,@city,@state,@zip,@phone,@email);";
            myDB.addParam("@first", firstName);
            myDB.addParam("@last", lastName);
            myDB.addParam("@address", address);
            myDB.addParam("@city", city);
            myDB.addParam("@state", state);
            myDB.addParam("@zip", zip);
            myDB.addParam("@phone", phone);
            myDB.addParam("@email", email);
            myDB.nonQuery();

            //get the user id from the person table to satisfy the user tables foreign constraint
            myDB.Query="select id from person where email=@email;";
            myDB.addParam("@email", email);
            this.id=myDB.scalar().ToString();
            // TODO: when administrator approves, this is transferred to the users table
            // for now, this is stored in the newUsers table
            myDB.Query = "insert into newUsers (ID, password, userName, security)\n" +
                "values (@id, @pwd,@username,@sec);";
            myDB.addParam("@id", id);
            myDB.addParam("@pwd", this.password);
            myDB.addParam("@username", this.userName);
            myDB.addParam("@sec", this.role);
            myDB.nonQuery();
        }

        /// <summary>
        /// Create user from id
        /// </summary>
        /// <param name="id">User ID number</param>
        public User(string id)
        {
            // get user info from db
            this.id=id;
            DBDriver myDB=new DBDriver();
            myDB.Query="select * from person p, users u where p.id=@id and u.id=p.id;";
            myDB.addParam("@id", this.id);
            SqlDataReader dr=myDB.createReader();
            dr.Read();
            this.userName=dr["userName"].ToString();
            this.address=dr["address"].ToString();
            this.city=dr["city"].ToString();
            this.email=dr["email"].ToString();
            this.firstName=dr["firstName"].ToString();
            this.lastName=dr["lastName"].ToString();
            this.password=dr["password"].ToString();
            this.phone=dr["phoneNumber"].ToString();
            this.role=dr["security"].ToString();
            this.state=dr["state"].ToString();
            this.zip=dr["zip"].ToString();
            myDB.close();
        }
        /// <summary>
        /// Verify that an email address exists in the database
        /// </summary>
        /// <param name="email">email address to verify</param>
        /// <returns>true if it exists, false if it doesn't</returns>
        static public bool verifyEmailExists(string email)
        {
            DBDriver myDB=new DBDriver();
            myDB.Query="select count(*) from person where email=@email;";
            myDB.addParam("@email", email);
            int k=Convert.ToInt32(myDB.scalar());
            if(k==1)
                return true;
            return false;
        }

        /// <summary>
        /// Verify that a username exists in the database
        /// </summary>
        /// <param name="userName">the username to verify</param>
        /// <returns>true if it exists, false if it doesn't</returns>
        static public bool verifyUserNameExists(string userName, bool isNew)
        {
            DBDriver myDB=new DBDriver();
            myDB.Query="select count(*) from users where userName=@name;";
            myDB.addParam("@name", userName);
            int k=Convert.ToInt32(myDB.scalar());
            if(k!=1)
                if(isNew)
                {
                    myDB.Query="select count(*) from newUsers where userName=@name;";
                    myDB.addParam("@name", userName);
                    k=Convert.ToInt32(myDB.scalar());                                                                  
                }
            if(k==1)
                return true;

            return false;
        }

        static public void declineNewUser(string delID)
        {
            DBDriver myDB=new DBDriver();
            myDB.Query="delete from newUsers where id=@id;";
            myDB.addParam("@id", delID);
            myDB.nonQuery();
            myDB.Query="delete from person where id=@id;";
            myDB.addParam("@id", delID);
            myDB.nonQuery();
        }

        static public User approveNewUser(string ID)
        {
            DBDriver myDB=new DBDriver();
            myDB.Query="insert into users select * from newUsers where id=@id;";
            myDB.addParam("@id", ID);
            myDB.nonQuery();
            //need to delete said info from the newUsers table
            myDB.Query="delete from newUsers where id=@id;";
            myDB.addParam("@id", ID);
            myDB.nonQuery();

            return new User(ID);
        }

        /// <summary>
        /// Update a user's profile.  Maybe we could instead have properties for each 
        /// member and update the database in the destructor ...
        /// NOTE: That would not be a good idea due to the garbage collection issues
        /// that I discovered with the DBDriver class.
        /// </summary>
        public void updateProfile()
        {
            //this isn't working... why? is my update wrong?
            //no, a multiple update like that works...
            //is it losing something elsewhere?
            DBDriver myDB=new DBDriver();
            myDB.Query="update users set password=@pwd, security=@sec where id=@uID;";
            //TODO: Add in changing username(need to verify availability)
            //myDB.addParam("@name", this.userName);
            myDB.addParam("@pwd", this.password);
            myDB.addParam("@sec", this.role);
            myDB.addParam("@uID", this.id);
            myDB.nonQuery();
            myDB.Query="update person set firstName=@first, lastName=@last, address=@address, city=@city, "
                +"state=@state, zip=@zip, phoneNumber=@phone, email=@mail where id=@uID;";
            myDB.addParam("@first", this.firstName);
            myDB.addParam("@last", this.lastName);
            myDB.addParam("@address", this.address);
            myDB.addParam("@city", this.city);
            myDB.addParam("@state", this.state);
            myDB.addParam("@zip", this.zip);
            myDB.addParam("@phone", this.phone);
            myDB.addParam("@mail", this.email);
            myDB.addParam("@uID", this.id);
            myDB.nonQuery();
        }

        /// <summary>
        /// Create and fill the user cookie
        /// </summary>
        //public void createCookie(){}


        /// <summary>
        /// Gets the user's ID
        /// </summary>
        public string ID
        {
            get {	return this.id;	}
        }

        /// <summary>
        /// Sets the user's password
        /// </summary>
        public string Password
        {
            set { this.password=PMT.Encryption.encrypt(value); }
        }

        /// <summary>
        /// Gets the user's first name
        /// </summary>
        public string FirstName
        {
            get {	return this.firstName;	}
            set { this.firstName=value; }
        }

        /// <summary>
        /// Gets the user's last name
        /// </summary>
        public string LastName
        {
            get {	return this.lastName;	}
            set { this.lastName=value; }
        }

        /// <summary>
        /// Gets the user's username
        /// </summary>
        public string UserName
        {
            get {	return this.userName;	}
            set { this.userName=value; }
        }

        /// <summary>
        /// Gets the user's street address
        /// </summary>
        public string Address
        {
            get {	return this.address;	}
            set { this.address=value; }
        }

        /// <summary>
        /// Gets the user's city
        /// </summary>
        public string City
        {
            get	{	return this.city;	}
            set { this.city=value; }
        }

        /// <summary>
        /// Gets the user's state
        /// </summary>
        public string State
        {
            get {	return this.state;	}
            set { this.state=value; }
        }

        /// <summary>
        /// Gets the user's zip code
        /// </summary>
        public string ZipCode
        {
            get {	return this.zip;	}
            set { this.zip=value; }
        }

        /// <summary>
        /// Gets the user's phone number
        /// </summary>
        public string PhoneNumber
        {
            get {	return this.phone;	}
            set { this.phone=value; }
        }

        /// <summary>
        /// Gets the user's email address
        /// </summary>
        public string Email
        {
            get {	return this.email;	}
            set { this.email=value; }
        }

        /// <summary>
        /// Gets the user's role (security level)
        /// </summary>
        public string Role
        {
            get {	return this.role;	}
            set { this.role=value; }
        }
    }
}
