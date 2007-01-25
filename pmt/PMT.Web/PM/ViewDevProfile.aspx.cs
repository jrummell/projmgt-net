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
//using PMTComponents;
//using PMTDataProvider;
using PMT.BLL;

namespace PMT.PM
{
    public partial class ViewDevProfile : Page
    {
        private Developer dev;
        private UserData userData;
        protected void Page_Load(object sender, System.EventArgs e)
        {
            if (!IsPostBack)
            {
                ProfileControl1.Editable = false;
                // get the developer
                userData = new UserData();
                dev = new Developer(userData.GetUser(DevID));

                // fill the form
                ProfileControl1.FillForm(dev);

                // bind complevels
                ddlComp.DataSource = Enum.GetNames(typeof(CompLevel));
                ddlComp.DataBind();
                ddlComp.Items.Insert(0, String.Empty);

                // select dev's comp level
                ListItem item = ddlComp.Items.FindByValue(dev.Competency.ToString());
                if (item != null)
                    item.Selected = true;
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
                catch (Exception)
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

        protected void btnUpdate_Click(object sender, EventArgs e)
        {
            if (!IsValid)
                return;

            throw new NotImplementedException("ViewDevProfile.btnUpdate_Click is not implemented.");
        }
    }
}
