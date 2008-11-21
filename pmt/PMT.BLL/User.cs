using System;
using System.Web.Configuration;
using System.Web.Security;

namespace PMT.BLL
{
    /// <summary>
    /// User Roles
    /// </summary>
    public enum UserRole
    {
        Client = 0,
        Developer,
        Manager,
        Administrator
    }

    /// <summary>
    /// Developer Competency Levels
    /// </summary>
    public enum CompLevel
    {
        Low = 0,
        Medium,
        High
    }

    /// <summary>
    /// Project Management .Net User Base Class
    /// </summary>
    public class User : IRecord
    {
        private readonly UserRole _role;
        private User _manager;
        private int _managerID = -1;
        private string _password;

        /// <summary>
        /// Initializes a new instance of the <see cref="User"/> class.
        /// </summary>
        /// <param name="role">The role.</param>
        /// <param name="username">The username.</param>
        /// <param name="password">The password.</param>
        public User(UserRole role, string username, string password)
            : this(-1, role, username, password, false)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="User"/> class.
        /// </summary>
        /// <param name="id">The id.</param>
        /// <param name="role">The role.</param>
        /// <param name="username">The username.</param>
        /// <param name="hashedPassword">The hashed password.</param>
        internal User(int id, UserRole role, string username, string hashedPassword)
            : this(id, role, username, hashedPassword, true)
        {
            
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="User"/> class.
        /// </summary>
        /// <param name="id">The id.</param>
        /// <param name="role">The role.</param>
        /// <param name="username">The username.</param>
        /// <param name="password">The password.</param>
        /// <param name="isPasswordHashed">if set to <c>true</c> [is password hashed].</param>
        private User(int id, UserRole role, string username, string password, bool isPasswordHashed)
        {
            if (username == null)
            {
                throw new ArgumentNullException("username");
            }
            if (password == null)
            {
                throw new ArgumentNullException("password");
            }

            ID = id;
            Username = username;
            _role = role;

            if (isPasswordHashed)
            {
                _password = password;
            }
            else
            {
                Password = password;
            }
        }

        /// <summary>
        /// Gets or sets a value indicating whether this <see cref="User"/> is enabled.
        /// </summary>
        /// <value><c>true</c> if enabled; otherwise, <c>false</c>.</value>
        public bool Enabled { get; set; }

        /// <summary>
        /// Gets the hashed password and sets the unhashed password.
        /// </summary>
        /// <remarks>Hashes the password when it is set.</remarks>
        /// <value>The password.</value>
        public string Password
        {
            get { return _password; }
            set { _password = HashPassword(value); }
        }

        /// <summary>
        /// Gets or sets the ID
        /// </summary>
        public int ID { get; internal set; }

        /// <summary>
        /// Gets or sets the username.
        /// </summary>
        /// <value>The username.</value>
        public string Username { get; set; }

        /// <summary>
        /// Gets or sets the first name
        /// </summary>
        public string FirstName { get; set; }

        /// <summary>
        /// Gets or sets the last name
        /// </summary>
        public string LastName { get; set; }

        /// <summary>
        /// Gets or sets the street address
        /// </summary>
        public string Address { get; set; }

        /// <summary>
        /// Gets or sets the city
        /// </summary>
        public string City { get; set; }

        /// <summary>
        /// Getsor sets the state
        /// </summary>
        public string State { get; set; }

        /// <summary>
        /// Gets or sets the zip code
        /// </summary>
        public string ZipCode { get; set; }

        /// <summary>
        /// Gets or sets the phone number
        /// </summary>
        public string PhoneNumber { get; set; }

        /// <summary>
        /// Gets or sets the email address
        /// </summary>
        public string Email { get; set; }

        /// <summary>
        /// Gets or sets the role (security level)
        /// </summary>
        public UserRole Role
        {
            get { return _role; }
        }

        /// <summary>
        /// Gets or sets the manager ID.
        /// </summary>
        /// <value>The manager ID.</value>
        public int ManagerID
        {
            get
            {
                if (_managerID == -1)
                {
                    UserService data = new UserService();
                    _managerID = data.GetManagerID(ID);
                }
                return _managerID;
            }
            set { _managerID = value; }
        }

        /// <summary>
        /// Gets the manager.
        /// </summary>
        /// <value>The manager.</value>
        public User Manager
        {
            get
            {
                if (_manager == null && ManagerID != -1)
                {
                    UserService data = new UserService();
                    _manager = data.GetByID(ManagerID);
                }

                return _manager;
            }
        }

        /// <summary>
        /// Hashes the password.
        /// </summary>
        /// <param name="value">The value.</param>
        /// <returns></returns>
        private static string HashPassword(string value)
        {
            return FormsAuthentication.HashPasswordForStoringInConfigFile(value, FormsAuthPasswordFormat.SHA1.ToString());
        }
    }
}