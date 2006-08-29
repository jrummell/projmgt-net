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

namespace PMT.AllUsers.Msg
{
    /// <summary>
    /// Summary description for viewMessage.
    /// </summary>
    public class viewMessage : Page
    {
        protected Label senderLabel;
        protected Label dateLabel;
        protected Label lblMessage;
        protected Label subjectLabel;
  
        private void Page_Load(object sender, System.EventArgs e)
        {
            if (!IsPostBack)
            {
                IDataProvider data = DataProviderFactory.CreateInstance();
                Message message = data.GetMessage(MessageID);
                fillForm(message);
            }
        }

        private void fillForm(Message message)
        {
            senderLabel.Text = String.Format("{0} {1} ({2})", 
                message.Sender.FirstName,
                message.Sender.LastName,
                message.Sender.UserName);
            dateLabel.Text = message.DateReceived.ToString("d, t");
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
            this.Load += new System.EventHandler(this.Page_Load);
        }
        #endregion
    }
}
