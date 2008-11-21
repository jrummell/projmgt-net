using System;
using System.Web.UI;
using PMT.BLL;

namespace PMT.Web.Controls
{
    public partial class Profile : UserControl
    {
        private bool adminView;

        protected void Page_Load(object sender, EventArgs e)
        {
            // Put user code to initialize the page here
            if (!IsPostBack)
            {
                SecurityDropDownList.DataSource = Enum.GetNames(typeof (UserRole));
                SecurityDropDownList.DataBind();
            }
        }

        /// <summary>
        /// Show or hide the old and new password fields
        /// </summary>
        protected void ChangePasswordCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            showChangePassword(ChangePasswordCheckBox.Checked);
        }

        /// <summary>
        /// Show or hide the old and new password fields
        /// </summary>
        /// <param name="val">show if true, hide if false</param>
        private void showChangePassword(bool val)
        {
            OldPasswordLabel.Visible = val;
            OldPasswordTextBox.Visible = val;
            OldPasswordRequiredFieldValidator.Enabled = val;

            if (val)
            {
                NewPassword1Label.Text = "New Password:";
                NewPassword2Label.Text = "Re-enter New Password:";
            }
            else
            {
                NewPassword1Label.Text = "Password:";
                NewPassword2Label.Text = "Re-enter Password:";
            }

            showNewPassword(val);
        }

        /// <summary>
        /// Show or hide new password fields
        /// </summary>
        /// <param name="val">show if true, hide if false</param>
        private void showNewPassword(bool val)
        {
            NewPassword1Label.Visible = val;
            NewPassword1TextBox.Visible = val;
            Password1RequiredFieldValidator.Enabled = val;

            NewPassword2Label.Visible = val;
            NewPassword2TextBox.Visible = val;
            Password2RequiredFieldValidator.Enabled = val;
        }

        /// <summary>
        /// Fills the form with a user's information
        /// </summary>
        /// <param name="user">A PMT user</param>
        public void FillForm(User user)
        {
            if (user == null)
            {
                throw new ArgumentNullException("user");
            }

            FirstNameTextBox.Text = user.FirstName;
            FirstNameLabel.Text = user.FirstName;
            LastNameTextBox.Text = user.LastName;
            LastNameLabel.Text = user.LastName;
            AddressTextBox.Text = user.Address;
            AddressLabel.Text = user.Address;
            CityTextBox.Text = user.City;
            CityLabel.Text = user.City;
            StateTextBox.Text = user.State;
            StateLabel.Text = user.State;
            ZipTextBox.Text = user.ZipCode;
            ZipLabel.Text = user.ZipCode;
            PhoneTextBox.Text = user.PhoneNumber;
            PhoneLabel.Text = user.PhoneNumber;
            EmailTextBox.Text = user.Email;
            EmailLabel.Text = user.Email;
            UsernameTextBox.Text = user.Username;
            UsernameLabel.Text = user.Username;

            // select the correct Security in the dropdown
            SecurityDropDownList.SelectedIndex = (int) user.Role;
            SecurityLabel.Text = user.Role.ToString();
        }

        /// <summary>
        /// fill a user object from the form
        /// </summary>
        /// <param name="user"></param>
        public void FillUser(User user)
        {
            if (user == null)
            {
                throw new ArgumentNullException("user");
            }

            user.Username = UsernameTextBox.Text;
            user.Address = AddressTextBox.Text;
            user.City = CityTextBox.Text;
            user.Email = EmailTextBox.Text;
            user.FirstName = FirstNameTextBox.Text;
            user.LastName = LastNameTextBox.Text;
            user.PhoneNumber = PhoneTextBox.Text;
            //if(this.AllowChangeSecurity)
            //    user.GetRole() = (UserRole)Enum.Parse(typeof(UserRole), this.SecurityDropDownList.SelectedItem.Text);
            user.State = StateTextBox.Text;
            user.ZipCode = ZipTextBox.Text;
            user.Password = NewPassword1TextBox.Text;
        }

        #region User Properties

        /// <summary>
        /// Gets username
        /// </summary>
        public string Username
        {
            get { return UsernameTextBox.Text; }
        }

        /// <summary>
        /// Gets first name
        /// </summary>
        public string FirstName
        {
            get { return FirstNameTextBox.Text; }
        }

        /// <summary>
        /// Gets lastname
        /// </summary>
        public string LastName
        {
            get { return LastNameTextBox.Text; }
        }

        /// <summary>
        /// Gets old password
        /// </summary>
        public string OldPassword
        {
            get { return OldPasswordTextBox.Text; }
        }

        /// <summary>
        /// Gets first new password
        /// </summary>
        public string NewPassword1
        {
            get { return NewPassword1TextBox.Text; }
        }

        /// <summary>
        /// Gets second new password
        /// </summary>
        public string NewPassword2
        {
            get { return NewPassword2TextBox.Text; }
        }

        /// <summary>
        /// Gets address
        /// </summary>
        public string Address
        {
            get { return AddressTextBox.Text; }
        }

        /// <summary>
        /// Gets city
        /// </summary>
        public string City
        {
            get { return CityTextBox.Text; }
        }

        /// <summary>
        /// Gets state
        /// </summary>
        public string State
        {
            get { return StateTextBox.Text; }
        }

        /// <summary>
        /// Gets zip code
        /// </summary>
        public string Zip
        {
            get { return ZipTextBox.Text; }
        }

        /// <summary>
        /// Gets phone number
        /// </summary>
        public string Phone
        {
            get { return PhoneTextBox.Text; }
        }

        /// <summary>
        /// Gets email address
        /// </summary>
        public string Email
        {
            get { return EmailTextBox.Text; }
        }

        /// <summary>
        /// Gets security level (user type)
        /// </summary>
        public string Security
        {
            get { return SecurityDropDownList.SelectedItem.Text; }
        }

        #endregion

        #region Profile Settings Properties

        /// <summary>
        /// Sets the profile to be editable or not
        /// </summary>
        public bool Editable
        {
            set
            {
                FirstNameLabel.Visible = !value;
                FirstNameTextBox.Visible = value;
                FirstNameRequiredFieldValidator.Enabled = value;

                LastNameLabel.Visible = !value;
                LastNameTextBox.Visible = value;
                LastNameRequiredFieldValidator.Enabled = value;

                UsernameLabel.Visible = !value;
                UsernameTextBox.Visible = value;
                UsernameRequiredFieldValidator.Enabled = value;

                AddressLabel.Visible = !value;
                AddressTextBox.Visible = value;
                AddressRequiredFieldValidator.Enabled = value;

                CityLabel.Visible = !value;
                CityTextBox.Visible = value;
                CityRequiredFieldValidator.Enabled = value;

                StateLabel.Visible = !value;
                StateTextBox.Visible = value;
                StateRequiredFieldValidator.Enabled = value;

                ZipLabel.Visible = !value;
                ZipTextBox.Visible = value;
                ZipRequiredFieldValidator.Enabled = value;
                ZipRegularExpressionValidator.Enabled = value;

                PhoneLabel.Visible = !value;
                PhoneTextBox.Visible = value;
                PhoneRequiredFieldValidator.Enabled = value;
                PhoneRegularExpressionValidator.Enabled = value;

                EmailLabel.Visible = !value;
                EmailTextBox.Visible = value;
                EmailRequiredFieldValidator.Enabled = value;
                EmailRegularExpressionValidator.Enabled = value;

                SecurityLabel.Visible = !value;
                SecurityDropDownList.Visible = value;
                SecurityRequiredFieldValidator.Enabled = value;

                AllowChangeUsername = value;
                AllowChangePassword = value;
                AllowNewPassword = value;
                AllowChangeSecurity = value;
            }
            get { return FirstNameTextBox.Visible; }
        }

        /// <summary>
        /// Gets or sets "Change Username" checkbox enabled
        /// </summary>
        public bool AllowChangeUsername
        {
            get { return UsernameTextBox.Visible; }
            set
            {
                UsernameLabel.Visible = !value;
                UsernameTextBox.Visible = value;
                UsernameRequiredFieldValidator.Enabled = value;
            }
        }

        /// <summary>
        /// Gets or sets change password enabled
        /// </summary>
        public bool AllowChangePassword
        {
            get { return ChangePasswordCheckBox.Visible; }
            set
            {
                ChangePasswordCheckBox.Visible = value;
                showChangePassword(false);
            }
        }

        /// <summary>
        /// Gets or sets new password enabled
        /// </summary>
        public bool AllowNewPassword
        {
            get { return NewPassword1TextBox.Visible; }
            set { showNewPassword(value); }
        }

        /// <summary>
        /// Gets or sets changing security enabled
        /// </summary>
        public bool AllowChangeSecurity
        {
            get { return SecurityPromptLabel.Visible; }
            set
            {
                SecurityLabel.Visible = !value;
                SecurityDropDownList.Visible = value;
                SecurityRequiredFieldValidator.Enabled = value;
            }
        }

        /// <summary>
        /// Sets appropriate properties for the Administrative view
        /// </summary>
        public bool AdminView
        {
            get { return adminView; }
            set
            {
                adminView = value;

                if (value)
                {
                    AllowChangePassword = false;
                    AllowNewPassword = true;
                    AllowChangeSecurity = false;
                    AllowChangeUsername = true;
                    Password1RequiredFieldValidator.Enabled = false;
                    Password2RequiredFieldValidator.Enabled = false;
                }
            }
        }

        #endregion
    }
}