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

namespace PMT.AllUsers.Msg
{
    /// <summary>
    /// Summary description for Messages.
    /// </summary>
    public class Messages : System.Web.UI.Page
    {
        protected System.Web.UI.WebControls.Panel ComposePanel;
        protected System.Web.UI.HtmlControls.HtmlTextArea MessageTextBox;
        protected System.Web.UI.WebControls.ListBox ToListBox;
        protected System.Web.UI.WebControls.ListBox ContactsListBox;
        protected System.Web.UI.WebControls.TextBox SubjectTextBox;
        protected System.Web.UI.WebControls.RequiredFieldValidator SubjectRequiredFieldValidator;
        protected System.Web.UI.WebControls.RequiredFieldValidator MessageRequiredFieldValidator;
        protected System.Web.UI.WebControls.Button SendButton;
        protected System.Web.UI.WebControls.ValidationSummary ComposeValidationSummary;
        protected System.Web.UI.WebControls.Panel MessagesPanel;
        protected System.Web.UI.WebControls.DataGrid MessagesDataGrid;
        protected System.Web.UI.WebControls.CustomValidator ToCustomValidator;
        protected System.Web.UI.WebControls.LinkButton UpdateLinkButton;
        protected System.Web.UI.WebControls.LinkButton ComposeLinkButton;
    
        private void Page_Load(object sender, System.EventArgs e)
        {
            DBDriver myDB=new DBDriver();
            // Put user code to initialize the page here

            string role = Request.Cookies["user"]["role"];
            string userID = Request.Cookies["user"]["id"];

            // fill the contact list
            if (!this.IsPostBack)
            {
                if (role.Equals(PMT.User.Security.CLIENT))
                {
                    myDB.Query=
                        "select u.userName as userName, u.id as ID\n"
                        + "from users u, clients c\n"
                        + "where u.id = c.managerID\n"
                        + "and c.clientID = @clientID;";
                    myDB.addParam("@clientID", userID);
                }
                else
                {
                    myDB.Query="select userName, id from users;";
                }
                DataSet ds2=new DataSet();
                myDB.createAdapter().Fill(ds2);
                //create a datatable to fill the dropdown list from
                DataTable dt=ds2.Tables[0];
                //fill the Contacts list box
                ContactsListBox.DataSource=dt.DefaultView;
                ContactsListBox.DataTextField="userName";
                ContactsListBox.DataValueField="id";
                ContactsListBox.DataBind();

                // fill the inbox
                myDB.Query="select m.ID messID, u.userName sender, m.subject subject, m.timestamp date, m.ID id from users u, messages m, recipients r"
                    +" where r.recipientID=@me and m.ID=r.messageID and u.ID=m.senderID;";
                myDB.addParam("@me", Request.Cookies["user"]["id"]);

                DataSet ds=new DataSet();
                //initialize the data adapter
                //fill the dataset
                myDB.createAdapter().Fill(ds);
                //fill the display grid
                this.MessagesDataGrid.DataSource=ds;
                this.MessagesDataGrid.DataBind();
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {    
            this.ComposeLinkButton.Click += new System.EventHandler(this.ComposeLinkButton_Click);
            this.UpdateLinkButton.Click += new System.EventHandler(this.UpdateLinkButton_Click);
            this.ToListBox.SelectedIndexChanged += new System.EventHandler(this.ToListBox_SelectedIndexChanged);
            this.ContactsListBox.SelectedIndexChanged += new System.EventHandler(this.ContactsListBox_SelectedIndexChanged);
            this.ToCustomValidator.ServerValidate += new System.Web.UI.WebControls.ServerValidateEventHandler(this.ToCustomValidate);
            this.SendButton.Click += new System.EventHandler(this.SendButton_Click);
            this.MessagesDataGrid.DeleteCommand += new System.Web.UI.WebControls.DataGridCommandEventHandler(this.MessagesDataGrid_DeleteCommand);
            this.Load += new System.EventHandler(this.Page_Load);

        }
        #endregion

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
        /// Show the compose message panel
        /// </summary>
        private void ComposeLinkButton_Click(object sender, System.EventArgs e)
        {
            ComposePanel.Visible = true;
            MessagesPanel.Visible = false;
            ComposeLinkButton.Visible = false;
            UpdateLinkButton.Visible = false;
        }

        /// <summary>
        /// Send the message
        /// </summary>
        private void SendButton_Click(object sender, System.EventArgs e)
        {
            if (!Page.IsValid)
                return;

            //string from = user.Name;

            ArrayList toList = new ArrayList();
            foreach (ListItem item in ToListBox.Items)
            {
                toList.Add(item.Value);
            }

            //Message msg = new Message(from, toList, message);

            string time=DateTime.Now.ToString("MM/dd/yyyy hh:mm:ss");
            // insert into database
            DBDriver myDB=new DBDriver();
            myDB.Query=
                "insert into messages (SenderID, Subject, Body, timestamp)\n"
                + "values (@sender, @subject, @body, @time);";
            myDB.addParam("@sender", Request.Cookies["user"]["id"]);
            myDB.addParam("@subject", this.SubjectTextBox.Text);
            myDB.addParam("@body", this.MessageTextBox.InnerText);
            myDB.addParam("@time", time);
            myDB.nonQuery();
            
            myDB.Query="select id from messages where timestamp=@time;";
            myDB.addParam("@time", time);
            int mID=Convert.ToInt32(myDB.scalar());

            //insert into the recipients table as well
            for(int i=0;i<this.ToListBox.Items.Count;i++)
            {
                myDB.Query="insert into recipients (MessageID, RecipientID, Timestamp) values (@id, @recipient, @time);";
                myDB.addParam("@id", mID);
                myDB.addParam("@recipient", this.ToListBox.Items[i].Value);
                myDB.addParam("@time", time);
                myDB.nonQuery();
            }

            Server.Transfer(Request.Url.AbsolutePath);
        }

        private void ToCustomValidate(object source, System.Web.UI.WebControls.ServerValidateEventArgs args)
        {
            if (ToListBox.Items.Count > 0)
                args.IsValid = true;
            else
                args.IsValid = false;
        }

        private void MessagesDataGrid_DeleteCommand(object source, System.Web.UI.WebControls.DataGridCommandEventArgs e)
        {
            //add appropriate warning popup and Database delete statement here
          string delID=this.MessagesDataGrid.Items[e.Item.ItemIndex].Cells[0].Text;
          DBDriver myDB=new DBDriver();
          myDB.Query="delete from recipients where recipientID=@rID and MessageID=@mID;";
          myDB.addParam("@rID", Request.Cookies["user"]["id"]);
          myDB.addParam("@mID", delID);
          myDB.nonQuery();
          Response.Redirect(Request.Url.AbsolutePath);
        }

        /// <summary>
        /// Refresh the page
        /// </summary>
        private void UpdateLinkButton_Click(object sender, System.EventArgs e)
        {
            Server.Transfer(Request.Url.AbsolutePath);
        }
    }
}