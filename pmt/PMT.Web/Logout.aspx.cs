using System.Web.Security;

namespace PMT.Web
{
    /// <summary>
    /// Logout the user and redirect to pmt root on page load
    /// </summary>
    public partial class Logout : System.Web.UI.Page
    {
        protected void Page_Load(object sender, System.EventArgs e)
        {
            // Put user code to initialize the page here
            FormsAuthentication.SignOut();
            Response.Redirect(Request.ApplicationPath);
        }
    }
}