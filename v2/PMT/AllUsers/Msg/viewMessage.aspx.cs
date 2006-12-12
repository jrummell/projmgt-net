using System;
using System.Collections;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Web;
using System.Web.SessionState;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;
using PMTDataProvider;
using PMTComponents;
using PMT.Configuration;

namespace PMT.AllUsers.Msg
{
    public partial class viewMessage : Page
    {
  
        protected void Page_Load(object sender, System.EventArgs e)
        {
            if (!IsPostBack)
            {
                int messageID = MessageID;
                int userID = Config.LoggedInUserID;
                IDataProvider data = DataProviderFactory.CreateInstance();

                if (!data.IsMessageOpened(messageID, userID))
                    data.UpdateOpenedMessage(messageID, userID, true, null);

                Message message = data.GetMessage(MessageID);
                fillForm(message);
            }
        }

        private void fillForm(Message message)
        {
            senderLabel.Text = String.Format("{0}, {1} ({2})",
                message.Sender.LastName,
                message.Sender.FirstName,
                message.Sender.UserName);
            dateLabel.Text = message.DateSent.ToString();
            dlRecipients.DataSource = message.Recipients;
            dlRecipients.DataBind();
            lblMessage.Text = message.Body;
            subjectLabel.Text = message.Subject;
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
                catch{}
                return id;
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
        }
        #endregion
    }
}
