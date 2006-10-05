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
using PMTComponents;
using PMTDataProvider;

namespace PMT.PM
{
	public partial class ViewDevProfile : Page
	{
        protected System.Web.UI.WebControls.LinkButton BackLinkButton;

		protected void Page_Load(object sender, System.EventArgs e)
		{
            if (!IsPostBack)
            {
                ProfileControl1.Editable = false;
                IDataProvider data = DataProviderFactory.CreateInstance();
                PMTUser dev = data.GetPMTUserById(DevID);
                if (dev.Role == PMTUserRole.Developer)
                {
                    ProfileControl1.fillForm(dev);

                    ddlComp.DataSource = Enum.GetNames(typeof(CompLevel));
                    ddlComp.DataBind();
                    // select dev's comp level
                    //ListItem item = ddlComp.Items.FindByValue(dev.com);
                    //if (item != null)
                    //    item.Selected = true;
                }
                else
                {
                    throw new Exception("ViewDevProfile requires the user id to be of a developer.");
                }
            }
        }

        #region Properties
        private int DevID
        {
            get
            {
                int id = -1;
                try
                {
                    id = Convert.ToInt32(Request["devID"]);
                }
                catch (Exception ex)
                {
                    throw new Exception("Developer ID is required.");
                }
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
