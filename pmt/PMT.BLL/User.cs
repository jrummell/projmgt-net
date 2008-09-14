using System;
using PMT.DAL;

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
    public class User
    {
        private UserProfile _profile;
        private DAL.User _user;

        #region Constructors

        /// <summary>
        /// Default Constructor. Creates a blank User
        /// </summary>
        public User(UserRole role)
        {
            _user = new DAL.User {Role = ((short) role)};
            _profile = new UserProfile();
        }

        /// <summary>
        /// Main constructor
        /// </summary>
        /// <param name="id">User ID</param>
        public User(int id)
        {
            _user = new DAL.User(id);
            _profile = new UserProfile(id);
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="User"/> class.
        /// </summary>
        /// <param name="user">The user.</param>
        /// <param name="profile">The profile.</param>
        internal User(DAL.User user, UserProfile profile)
        {
            if (user == null)
            {
                throw new ArgumentNullException("user");
            }
            if (profile == null)
            {
                throw new ArgumentNullException("profile");
            }

            _user = user;
            _profile = profile;
        }

        #endregion

        /// <summary>
        /// Gets or sets a value indicating whether this <see cref="User"/> is enabled.
        /// </summary>
        /// <value><c>true</c> if enabled; otherwise, <c>false</c>.</value>
        public bool Enabled
        {
            get { return _user.Enabled; }
            set { _user.Enabled = value; }
        }

        /// <summary>
        /// Gets the hashed password and sets the unhashed password.
        /// </summary>
        /// <remarks>Hashes the password when it is set.</remarks>
        /// <value>The password.</value>
        public string Password
        {
            get { return _user.Password; }
            set { _user.Password = Encryption.Encrypt(value); }
        }

        /// <summary>
        /// Gets or sets the ID
        /// </summary>
        public int ID
        {
            get { return _user.Id; }
        }

        /// <summary>
        /// Gets or sets the first name
        /// </summary>
        public string FirstName
        {
            get { return _profile.FirstName; }
            set { _profile.FirstName = value; }
        }

        /// <summary>
        /// Gets or sets the last name
        /// </summary>
        public string LastName
        {
            get { return _profile.LastName; }
            set { _profile.LastName = value; }
        }

        /// <summary>
        /// Gets or sets the username
        /// </summary>
        public string UserName
        {
            get { return _user.Username; }
            set { _user.Username = value; }
        }

        /// <summary>
        /// Gets or sets the street address
        /// </summary>
        public string Address
        {
            get { return _profile.Address; }
            set { _profile.Address = value; }
        }

        /// <summary>
        /// Gets or sets the city
        /// </summary>
        public string City
        {
            get { return _profile.City; }
            set { _profile.City = value; }
        }

        /// <summary>
        /// Getsor sets the state
        /// </summary>
        public string State
        {
            get { return _profile.State; }
            set { _profile.State = value; }
        }

        /// <summary>
        /// Gets or sets the zip code
        /// </summary>
        public string ZipCode
        {
            get { return _profile.Zip; }
            set { _profile.Zip = value; }
        }

        /// <summary>
        /// Gets or sets the phone number
        /// </summary>
        public string PhoneNumber
        {
            get { return _profile.PhoneNumber; }
            set { _profile.PhoneNumber = value; }
        }

        /// <summary>
        /// Gets or sets the email address
        /// </summary>
        public string Email
        {
            get { return _profile.Email; }
            set { _profile.Email = value; }
        }

        /// <summary>
        /// Gets or sets the role (security level)
        /// </summary>
        public UserRole Role
        {
            get { return (UserRole) _user.Role; }
        }

        /// <summary>
        /// Updates the specified user.
        /// </summary>
        /// <param name="user">The user.</param>
        /// <param name="profile">The profile.</param>
        internal void Update(DAL.User user, UserProfile profile)
        {
            if (user == null)
            {
                throw new ArgumentNullException("user");
            }
            if (profile == null)
            {
                throw new ArgumentNullException("profile");
            }

            _user = user;
            _profile = profile;
        }
    }
}