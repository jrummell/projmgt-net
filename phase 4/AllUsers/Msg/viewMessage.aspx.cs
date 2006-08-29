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

namespace PMT.AllUsers.Msg
{
	/// <summary>
	/// Summary description for viewMessage.
	/// </summary>
	public class viewMessage : System.Web.UI.Page
	{
    protected System.Web.UI.WebControls.Label senderLabel;
    protected System.Web.UI.WebControls.Label dateLabel;
    protected System.Web.UI.WebControls.Label messageLabel;
        protected System.Web.UI.WebControls.HyperLink ReturnHyperLink;
    protected System.Web.UI.WebControls.Label subjectLabel;
  
		private void Page_Load(object sender, System.EventArgs e)
		{
			// Put user code to initialize the page here
      DBDriver myDB=new DBDriver();
      string mID=Request.QueryString["id"];
      myDB.Query="select u.userName sender, m.subject subject, m.timestamp date, m.body body from users u, messages m where m.ID=@mID and u.ID=m.senderID;";
      myDB.addParam("@mID", mID);

      SqlDataReader dr=myDB.createReader();
      dr.Read();

      this.subjectLabel.Text=Convert.ToString(dr["subject"]);
      this.senderLabel.Text=Convert.ToString(dr["sender"]);
      this.dateLabel.Text=Convert.ToString(dr["date"]);
      this.messageLabel.Text=Convert.ToString(dr["body"]);
      myDB.close();
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
            this.Load += new System.EventHandler(this.Page_Load);

        }
		#endregion
	}
}
