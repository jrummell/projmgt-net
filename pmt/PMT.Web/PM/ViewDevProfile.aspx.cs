using System;
using System.Web.UI;
using System.Web.UI.WebControls;
using PMT.BLL;

namespace PMT.Web.PM
{
    public partial class ViewDevProfile : Page
    {
        private Developer dev;
        private UserData userData;
        protected void Page_Load(object sender, EventArgs e)
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
                int id;
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

        protected void btnUpdate_Click(object sender, EventArgs e)
        {
            if (!IsValid)
                return;

            throw new NotImplementedException("ViewDevProfile.btnUpdate_Click is not implemented.");
        }
    }
}