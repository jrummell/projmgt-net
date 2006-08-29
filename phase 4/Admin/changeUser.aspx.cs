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
using PMT.Controls;

namespace PMT.Admin
{
  /// <summary>
  /// Summary description for changeUser.
  /// </summary>
  public class ChangeUser : System.Web.UI.Page
  {
    protected ProfileControl ProfileControl1;
    protected System.Web.UI.WebControls.Button Submit;
    protected System.Web.UI.WebControls.Button Cancel;
    protected User user;

    private void Page_Load(object sender, System.EventArgs e)
    {
      string uID=Request.QueryString["id"];
      string typeID=Request.QueryString["type"];
      // Put user code to initialize the page here
      if(typeID.Equals("new"))
      {
        //new user handling here
        //need to move the new user info to the users table
        user = PMT.User.approveNewUser(uID);
        
      }
      if(typeID.Equals("current"))
      {
        //current user handling here
        user=new User(uID);
      }
      if(!Page.IsPostBack)
      {
        //what to do when the page is loaded fresh
        //set the control to show admin field set
        //then fill it with the appropriate user information
        ProfileControl1.AdminView = true;
        ProfileControl1.fillForm(new User(uID));
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
      this.Submit.Click += new System.EventHandler(this.Submit_Click);
      this.Cancel.Click += new System.EventHandler(this.Cancel_Click);
      this.Load += new System.EventHandler(this.Page_Load);

    }
    #endregion

    private void Submit_Click(object sender, System.EventArgs e)
    {
      //store new user information to database
      string uID=Request.QueryString["id"];
      user=new User(uID);
      ProfileControl1.fillUser(user);
      user.updateProfile();
      //Response.Redirect(Request.Url.AbsoluteUri);
    }

    private void Cancel_Click(object sender, System.EventArgs e)
    {
      //cancel user profile editing, return to user list page
      Response.Redirect("userList.aspx");
    }
  }
}
