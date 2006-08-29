using System;
using System.Collections;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Web;
using System.Web.SessionState;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;
using PMTComponents;
using PMTDataProvider;

namespace PMT.AllUsers.Msg
{
	/// <summary>
	/// Summary description for newMessage.
	/// </summary>
	public class NewMessage : Page
	{
        protected HtmlTextArea MessageTextBox;
        protected ListBox ToListBox;
        protected ListBox ContactsListBox;
        protected TextBox SubjectTextBox;
        protected RequiredFieldValidator SubjectRequiredFieldValidator;
        protected RequiredFieldValidator MessageRequiredFieldValidator;
        protected CustomValidator ToCustomValidator;
        protected Button SendButton;
        protected CheckBox cbSaveCopy;
        protected ValidationSummary ComposeValidationSummary;
        protected Label lblResult;

		private void Page_Load(object sender, EventArgs e)
		{
            if (!this.IsPostBack)
            {
                //fill the Contacts list box
                IDataProvider data = DataProviderFactory.CreateInstance();
                ContactsListBox.DataSource = data.GetContacts();
                ContactsListBox.DataTextField = "username";
                ContactsListBox.DataValueField = "id";
                ContactsListBox.DataBind();

                if (Action != null)
                {
                    Message oldMessage = data.GetMessage(MessageID);
                    Message newMessage = new Message();
                    newMessage.Sender = data.GetPMTUserById(UserID);

                    if (Action.Equals("reply"))
                    {
                        newMessage.Reply(oldMessage);
                        // add sender to recipients
                        ListItem item = new ListItem(newMessage.Recipients[0].UserName, newMessage.Recipients[0].ID.ToString());
                        ToListBox.Items.Add(item);
                        item = new ListItem(item.Text, item.Value);
                        ContactsListBox.Items.Remove(item);
                    }
                    else if (Action.Equals("forward"))
                    {
                        newMessage.Forward(oldMessage);
                    }

                    SubjectTextBox.Text = newMessage.Subject;
                    MessageTextBox.Value = newMessage.Body;
                }
            }
		}

        /// <summary>
        /// Remove item from contacts and put in toList
        /// </summary>
        private void ContactsListBox_SelectedIndexChanged(object sender, System.EventArgs e)
        {
            ListItem li = ContactsListBox.SelectedItem;
            ToListBox.Items.Add(li);
            li.Selected = false;
            ContactsListBox.Items.Remove(li);
        }

        /// <summary>
        /// Remove item from toList and put back in contacts
        /// </summary>
        private void ToListBox_SelectedIndexChanged(object sender, System.EventArgs e)
        {
            ListItem li = ToListBox.SelectedItem;
            ContactsListBox.Items.Add(li);
            li.Selected = false;
            ToListBox.Items.Remove(li);
        }

        /// <summary>
        /// Send the message
        /// </summary>
        private void SendButton_Click(object sender, System.EventArgs e)
        {
            if (!Page.IsValid)
                return;

            ArrayList toList = new ArrayList();
            foreach (ListItem item in ToListBox.Items)
            {
                toList.Add(item.Value);
            }

            IDataProvider data = DataProviderFactory.CreateInstance();
            Message msg = new Message();
            msg.Sender = data.GetPMTUserById(UserID);
            msg.Subject = SubjectTextBox.Text;
            msg.Body = MessageTextBox.Value;
            msg.DateSent = DateTime.Now;

            // add recipients
            ArrayList recipients = new ArrayList();
            foreach(ListItem item in ToListBox.Items)
            {
                recipients.Add(data.GetPMTUserById(Convert.ToInt32(item.Value)));
            }

            // add the user if Save a Copy is checked
            if (cbSaveCopy.Checked)
                recipients.Add(msg.Sender);

            msg.Recipients = recipients.ToArray(typeof(PMTUser)) as PMTUser[];

            if (0 < data.InsertMessage(msg, new TransactionFailedHandler(this.TransactionFailed)))
                Server.Transfer("default.aspx");
        }

        private void ToCustomValidate(object source, ServerValidateEventArgs args)
        {
            if (ToListBox.Items.Count > 0)
                args.IsValid = true;
            else
                args.IsValid = false;
        }

        private void TransactionFailed(Exception ex)
        {
            lblResult.Text = String.Format("Error: {0}", ex.Message);
        }

        #region Properties
        protected int MessageID
        {
            get 
            {
                int id = 0;
                try
                {
                    id = Convert.ToInt32(Request["id"]);
                }
                catch {}
                return id;
            }
        }
        protected string Action
        {
            get {   return Request["action"];   }
        }
        private int UserID
        {
            get 
            {
                int user = 0;
                try
                {
                    user = Convert.ToInt32(Request.Cookies["user"]["id"]);
                }
                catch {}
                return user;
            }
        }
        #endregion

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
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{    
            this.ToListBox.SelectedIndexChanged += new System.EventHandler(this.ToListBox_SelectedIndexChanged);
            this.ContactsListBox.SelectedIndexChanged += new System.EventHandler(this.ContactsListBox_SelectedIndexChanged);
            this.ToCustomValidator.ServerValidate += new System.Web.UI.WebControls.ServerValidateEventHandler(this.ToCustomValidate);
            this.SendButton.Click += new System.EventHandler(this.SendButton_Click);
            this.Load += new System.EventHandler(this.Page_Load);

        }
		#endregion
	}
}
