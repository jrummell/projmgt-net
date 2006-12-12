using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using PMTDataProvider;
using PMTComponents;

namespace PMT.Admin
{
    /// <summary>
    /// Summary description for default
    /// </summary>
    public partial class Default : Page
    {
        private void Page_Load(object sender, EventArgs e)
        {
            IDataProvider data = DataProviderFactory.CreateInstance();
            DataTable dtUsers = data.GetPMTUsers();

            string count = "count(id)";
            string filter = "enabled=0";
            int newUsers = (int)dtUsers.Compute(count, filter);
            lblNewUsers.Text = newUsers.ToString();

            filter = "enabled=1";
            int users = (int)dtUsers.Compute(count, filter);
            lblTotalUsers.Text = users.ToString();

            filter += " and Role={0}";
            int admins = (int)dtUsers.Compute(count, String.Format(filter, (int)PMTUserRole.Administrator));
            int managers = (int)dtUsers.Compute(count, String.Format(filter, (int)PMTUserRole.Manager));
            int devs = (int)dtUsers.Compute(count, String.Format(filter, (int)PMTUserRole.Developer));
            int clients = (int)dtUsers.Compute(count, String.Format(filter, (int)PMTUserRole.Client));

            lblAdmins.Text = admins.ToString();
            lblManagers.Text = managers.ToString();
            lblDevelopers.Text = devs.ToString();
            lblClients.Text = clients.ToString();
        }

        #region Web Form Designer generated code
        override protected void OnInit(EventArgs e)
        {
            //
            // CODEGEN: This call is required by the ASP.NET Web Form Designer.
            //
            InitializeComponent();
            base.OnInit(e);
            this.Load += new EventHandler(Page_Load);
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
