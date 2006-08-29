namespace PMT.Controls
{
    using System;
    using System.Data;
    using System.Drawing;
    using System.Web;
    using System.Web.UI.WebControls;
    using System.Web.UI.HtmlControls;
    using System.Collections;

    /// <summary>
    ///		Summary description for Profile.
    /// </summary>
    public class ProfileControl : System.Web.UI.UserControl
    {
        protected System.Web.UI.WebControls.RequiredFieldValidator SecurityRequiredFieldValidator;
        protected System.Web.UI.WebControls.DropDownList SecurityDropDownList;
        protected System.Web.UI.WebControls.RegularExpressionValidator EmailRegularExpressionValidator;
        protected System.Web.UI.WebControls.RequiredFieldValidator EmailRequiredFieldValidator;
        protected System.Web.UI.WebControls.TextBox EmailTextBox;
        protected System.Web.UI.WebControls.RegularExpressionValidator PhoneRegularExpressionValidator;
        protected System.Web.UI.WebControls.RequiredFieldValidator PhoneRequiredFieldValidator;
        protected System.Web.UI.WebControls.TextBox PhoneTextBox;
        protected System.Web.UI.WebControls.RegularExpressionValidator ZipRegularExpressionValidator;
        protected System.Web.UI.WebControls.RequiredFieldValidator ZipRequiredFieldValidator;
        protected System.Web.UI.WebControls.TextBox ZipTextBox;
        protected System.Web.UI.WebControls.RequiredFieldValidator StateRequiredFieldValidator;
        protected System.Web.UI.WebControls.TextBox StateTextBox;
        protected System.Web.UI.WebControls.RequiredFieldValidator CityRequiredFieldValidator;
        protected System.Web.UI.WebControls.TextBox CityTextBox;
        protected System.Web.UI.WebControls.RequiredFieldValidator AddressRequiredFieldValidator;
        protected System.Web.UI.WebControls.TextBox AddressTextBox;
        protected System.Web.UI.WebControls.CompareValidator PasswordCompareValidator;
        protected System.Web.UI.WebControls.RequiredFieldValidator Password2RequiredFieldValidator;
        protected System.Web.UI.WebControls.RequiredFieldValidator Password1RequiredFieldValidator;
        protected System.Web.UI.WebControls.RequiredFieldValidator UsernameRequiredFieldValidator;
        protected System.Web.UI.WebControls.RequiredFieldValidator LastNameRequiredFieldValidator;
        protected System.Web.UI.WebControls.TextBox LastNameTextBox;
        protected System.Web.UI.WebControls.RequiredFieldValidator FirstNameRequiredFieldValidator;
        protected System.Web.UI.WebControls.TextBox FirstNameTextBox;
        protected System.Web.UI.WebControls.TextBox OldPasswordTextBox;
        protected System.Web.UI.WebControls.RequiredFieldValidator OldPasswordRequiredFieldValidator;
        protected System.Web.UI.WebControls.Label NewPassword1Label;
        protected System.Web.UI.WebControls.Label NewPassword2Label;
        protected System.Web.UI.WebControls.TextBox UsernameTextBox;
        protected System.Web.UI.WebControls.Label OldPasswordLabel;
        protected System.Web.UI.WebControls.CheckBox ChangePasswordCheckBox;
        protected System.Web.UI.WebControls.TextBox NewPassword1TextBox;
        protected System.Web.UI.WebControls.TextBox NewPassword2TextBox;
        protected System.Web.UI.WebControls.Label FirstNameLabel;
        protected System.Web.UI.WebControls.Label LastNameLabel;
        protected System.Web.UI.WebControls.Label UsernamePromptLabel;
        protected System.Web.UI.WebControls.Label UsernameLabel;
        protected System.Web.UI.WebControls.Label AddressLabel;
        protected System.Web.UI.WebControls.Label CityLabel;
        protected System.Web.UI.WebControls.Label StateLabel;
        protected System.Web.UI.WebControls.Label ZipLabel;
        protected System.Web.UI.WebControls.Label PhoneLabel;
        protected System.Web.UI.WebControls.Label EmailLabel;
        protected System.Web.UI.WebControls.Label SecurityPromptLabel;
        protected System.Web.UI.WebControls.Label SecurityLabel;
        protected System.Web.UI.WebControls.ValidationSummary ValidationSummary1;

        private void Page_Load(object sender, System.EventArgs e)
        {
            // Put user code to initialize the page here
        }

        /// <summary>
        /// Sets the profile to be editable or not
        /// </summary>
        public bool Editable
        {
            set
            {
                this.FirstNameLabel.Visible = !value;
                this.FirstNameTextBox.Visible = value;
                this.FirstNameRequiredFieldValidator.Enabled = value;

                this.LastNameLabel.Visible = !value;
                this.LastNameTextBox.Visible = value;
                this.LastNameRequiredFieldValidator.Enabled = value;

                this.UsernameLabel.Visible = !value;
                //this.UsernamePromptLabel.Visible = value;
                this.UsernameTextBox.Visible = value;
                this.UsernameRequiredFieldValidator.Enabled = value;

                this.AddressLabel.Visible = !value;
                this.AddressTextBox.Visible = value;
                this.AddressRequiredFieldValidator.Enabled = value;

                this.CityLabel.Visible = !value;
                this.CityTextBox.Visible = value;
                this.CityRequiredFieldValidator.Enabled = value;

                this.StateLabel.Visible = !value;
                this.StateTextBox.Visible = value;
                this.StateRequiredFieldValidator.Enabled = value;

                this.ZipLabel.Visible = !value;
                this.ZipTextBox.Visible = value;
                this.ZipRequiredFieldValidator.Enabled = value;
                this.ZipRegularExpressionValidator.Enabled = value;

                this.PhoneLabel.Visible = !value;
                this.PhoneTextBox.Visible = value;
                this.PhoneRequiredFieldValidator.Enabled = value;
                this.PhoneRegularExpressionValidator.Enabled = value;

                this.EmailLabel.Visible = !value;
                this.EmailTextBox.Visible = value;
                this.EmailRequiredFieldValidator.Enabled = value;
                this.EmailRegularExpressionValidator.Enabled = value;

                this.SecurityLabel.Visible = !value;
                this.SecurityDropDownList.Visible = value;
                this.SecurityRequiredFieldValidator.Enabled = value;

                AllowChangeUsername = value;
                AllowChangePassword = value;
                AllowNewPassword = value;
                AllowChangeSecurity = value;
            }
            get
            {   return FirstNameTextBox.Visible;    }
        }

        /// <summary>
        /// Gets or sets "Change Username" checkbox enabled
        /// </summary>
        public bool AllowChangeUsername
        {
            get
            {   return UsernameTextBox.Visible; }
            set
            {
                UsernameLabel.Visible = !value;
                UsernameTextBox.Visible = value;
                //UsernamePromptLabel.Visible = value;
                UsernameRequiredFieldValidator.Enabled = value;
            }
        }

        /// <summary>
        /// Gets or sets change password enabled
        /// </summary>
        public bool AllowChangePassword
        {
            get {   return ChangePasswordCheckBox.Visible;    }
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
            get {   return NewPassword1TextBox.Visible;    }
            set {   showNewPassword(value);         }
        }

        /// <summary>
        /// Gets or sets changing security enabled
        /// </summary>
        public bool AllowChangeSecurity
        {
            get {   return SecurityPromptLabel.Visible;   }
            set
            {
                SecurityLabel.Visible = !value;
                //SecurityPromptLabel.Visible = value;
                SecurityDropDownList.Visible = value;
                SecurityRequiredFieldValidator.Enabled = value;
            }
        }

        /// <summary>
        /// Sets appropriate properties for the Administrative view
        /// </summary>
        public bool AdminView
        {
            set
            {
                if (value == true)
                {
                    AllowChangePassword = false;
                    AllowNewPassword = true;
                    AllowChangeSecurity = true;
                    AllowChangeUsername = true;
                    SecurityDropDownList.Items.Add(User.Security.ADMINISTRATOR);
                    Password1RequiredFieldValidator.Enabled = false;
                    Password2RequiredFieldValidator.Enabled = false;
                }
            }
        }
        

        #region Web Form Designer generated code
        override protected void OnInit(EventArgs e)
        {
            //
            // CODEGEN: This call is required by the ASP.NET Web Form Designer.
            //
            InitializeComponent();
            base.OnInit(e);
        }
		
        /// <summary>
        ///		Required method for Designer support - do not modify
        ///		the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.ChangePasswordCheckBox.CheckedChanged += new System.EventHandler(this.ChangePasswordCheckBox_CheckedChanged);
            this.Load += new System.EventHandler(this.Page_Load);

        }
        #endregion

        /// <summary>
        /// Show or hide the old and new password fields
        /// </summary>
        private void ChangePasswordCheckBox_CheckedChanged(object sender, System.EventArgs e)
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

            if (val == true)
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
        public void fillForm(PMT.User user)
        {
            this.FirstNameTextBox.Text = user.FirstName;
            this.FirstNameLabel.Text   = user.FirstName;
            this.LastNameTextBox.Text  = user.LastName;
            this.LastNameLabel.Text    = user.LastName;
            this.AddressTextBox.Text   = user.Address;
            this.AddressLabel.Text     = user.Address;
            this.CityTextBox.Text	   = user.City;
            this.CityLabel.Text        = user.City;
            this.StateTextBox.Text     = user.State;
            this.StateLabel.Text       = user.State;
            this.ZipTextBox.Text       = user.ZipCode;
            this.ZipLabel.Text         = user.ZipCode;
            this.PhoneTextBox.Text     = user.PhoneNumber;
            this.PhoneLabel.Text       = user.PhoneNumber;
            this.EmailTextBox.Text     = user.Email;
            this.EmailLabel.Text       = user.Email;

            //if (this.UsernameTextBox.Enabled)
            this.UsernameTextBox.Text = user.UserName;
            this.UsernameLabel.Text = user.UserName;

            // select the correct Security in the dropdown
            //if (this.SecurityDropDownList.Enabled)
            SecurityDropDownList.SelectedIndex 
                = SecurityDropDownList.Items.IndexOf(
                SecurityDropDownList.Items.FindByText(user.Role));
            this.SecurityLabel.Text = user.Role;
        }

        /// <summary>
        /// fill a user object from the form
        /// </summary>
        /// <param name="user"></param>
        public void fillUser(PMT.User user)
        {
            user.Address=this.AddressTextBox.Text;
            user.City=this.CityTextBox.Text;
            user.Email=this.EmailTextBox.Text;
            user.FirstName=this.FirstNameTextBox.Text;
            user.LastName=this.LastNameTextBox.Text;
            user.PhoneNumber=this.PhoneTextBox.Text;
            if(this.AllowChangeSecurity)
                user.Role=this.SecurityDropDownList.SelectedItem.Text;
            user.State=this.StateTextBox.Text;
            user.ZipCode=this.ZipTextBox.Text;
            if (NewPassword1TextBox.Text.Length > 0)
                user.Password=this.NewPassword1TextBox.Text;
        }

        /// <summary>
        /// Gets username
        /// </summary>
        public string Username 
        {
            get {   return UsernameTextBox.Text;    }
        }
        /// <summary>
        /// Gets first name
        /// </summary>
        public string FirstName
        {
            get {   return FirstNameTextBox.Text;   }
        }
        /// <summary>
        /// Gets lastname
        /// </summary>
        public string LastName
        {
            get {   return LastNameTextBox.Text;    }
        }
        /// <summary>
        /// Gets old password
        /// </summary>
        public string OldPassword
        {
            get {   return OldPasswordTextBox.Text; }
        }
        /// <summary>
        /// Gets first new password
        /// </summary>
        public string NewPassword1
        {
            get {   return NewPassword1TextBox.Text;    }
        }
        /// <summary>
        /// Gets second new password
        /// </summary>
        public string NewPassword2
        {
            get {   return NewPassword2TextBox.Text;    }
        }
        /// <summary>
        /// Gets address
        /// </summary>
        public string Address
        {
            get {   return AddressTextBox.Text;    }
        }
        /// <summary>
        /// Gets city
        /// </summary>
        public string City
        {
            get {   return CityTextBox.Text;    }
        }
        /// <summary>
        /// Gets state
        /// </summary>
        public string State
        {
            get {   return StateTextBox.Text;    }
        }
        /// <summary>
        /// Gets zip code
        /// </summary>
        public string Zip
        {
            get {   return ZipTextBox.Text;    }
        }
        /// <summary>
        /// Gets phone number
        /// </summary>
        public string Phone
        {
            get {   return PhoneTextBox.Text;    }
        }
        /// <summary>
        /// Gets email address
        /// </summary>
        public string Email
        {
            get {   return EmailTextBox.Text;    }
        }
        /// <summary>
        /// Gets security level (user type)
        /// </summary>
        public string Security
        {
            get {   return SecurityDropDownList.SelectedItem.Text;    }
        }
    }
}
