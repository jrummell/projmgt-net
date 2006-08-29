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

namespace PMT.Admin
{
	/// <summary>
	/// Summary description for maint.
	/// </summary>
	public class Maint : System.Web.UI.Page
	{
    protected System.Web.UI.WebControls.Button cleanPeople;
    protected System.Web.UI.WebControls.Button cleanMail;
  
		private void Page_Load(object sender, System.EventArgs e)
		{
			// Put user code to initialize the page here
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
      this.cleanMail.Click += new System.EventHandler(this.cleanMail_Click);
      this.cleanPeople.Click += new System.EventHandler(this.cleanPeople_Click);
      this.Load += new System.EventHandler(this.Page_Load);

    }
		#endregion

    private void cleanMail_Click(object sender, System.EventArgs e)
    {
//      DBDriver myDB=new DBDriver();
//      myDB.Query="delete from messages where ID not in (select messageID from recipients);";
//      myDB.nonQuery();
    }

    private void cleanPeople_Click(object sender, System.EventArgs e)
    {
//      DBDriver myDB=new DBDriver();
//      myDB.Query="create table temp(id int);";
//      myDB.nonQuery();
//      myDB.Query="insert into temp (id) select id from users;";
//      myDB.nonQuery();
//      myDB.Query="insert into temp (id) select id from newUsers;";
//      myDB.nonQuery();
//      myDB.Query="delete from person where id not in (select id from temp);";
//      myDB.nonQuery();
//      myDB.Query="drop table temp;";
//      myDB.nonQuery();
    }
	}
}
