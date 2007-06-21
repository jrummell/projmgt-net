using System;
using System.Web.UI;
using System.Web.UI.WebControls;
using PMT.BLL;

namespace PMT.Web.PM
{
    public partial class Matrix : Page
    {

        protected void Page_Load(object sender, System.EventArgs e)
        {
            if (!IsPostBack)
            {
                throw new NotImplementedException();

                //IDataProvider data = DataProviderFactory.CreateInstance();
                //dgCompMatrix.DataSource = data.GetCompMatrix();
                //dgCompMatrix.DataBind();
            }
        }

        protected void dgCompMatrix_ItemDataBound(object sender, DataGridItemEventArgs e)
        {
            if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
            {
                // set comp level text
                e.Item.Cells[0].Text = Enum.GetName(typeof(CompLevel), Convert.ToInt32(e.Item.Cells[0].Text));
            }
        }
    }
}
