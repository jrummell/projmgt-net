using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using PMT.Configuration;
using PMTDataProvider;
using PMTComponents;
using PMT.Web;

namespace PMT.PM
{
    public partial class Developers : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
        }

        protected override void OnInit(EventArgs e)
        {
            // set the object data source type name
            dsDevelopers.TypeName = PMTDataProvider.DataProviderFactory.CreateInstance().GetType().ToString();
            dsDevelopers.SelectMethod = "GetDevelopers";
            dsDevelopers.SelectParameters.Add("mgrID", CookiesHelper.LoggedInUserID.ToString());
            dsDevelopers.FilterExpression = String.Format("Selected=1");
            base.OnInit(e);
        }

        protected void dvDevs_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                TableCell cell = e.Row.Cells[e.Row.Cells.Count-1];
                cell.Text = Enum.GetName(typeof(CompLevel), Convert.ToInt32(cell.Text));
            }
        }
    }
}
