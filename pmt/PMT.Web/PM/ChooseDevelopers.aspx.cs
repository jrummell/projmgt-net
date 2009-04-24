using System;
using System.Data;
using System.Web.UI;
using System.Web.UI.WebControls;
using PMT.BLL;

namespace PMT.Web.PM
{
    public partial class ChooseDevelopers : Page
    {
        /// <summary>
        /// Raises the <see cref="E:System.Web.UI.Control.Init"/> event to initialize the page.
        /// </summary>
        /// <param name="e">An <see cref="T:System.EventArgs"/> that contains the event data.</param>
        protected override void OnInit(EventArgs e)
        {
            // set the object data source type name
            //dsDevelopers.TypeName = PMTDataProvider.DataProviderFactory.CreateInstance().GetType().ToString();
            //dsDevelopers.SelectParameters.Add("mgrID", CookiesHelper.LoggedInUserID.ToString());
            base.OnInit(e);

            Load += Page_Load;
        }

        /// <summary>
        /// Handles the Load event of the Page control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        private void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
            }

            //TODO: ~/PM/ChooseDevelopers.aspx
            throw new NotImplementedException();
        }

        protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                DataRowView drv = e.Row.DataItem as DataRowView;
                int lastCol = e.Row.Cells.Count - 1;

                // set complevel text
                e.Row.Cells[lastCol - 1].Text = Enum.GetName(typeof (CompLevel),
                                                             Convert.ToInt32(e.Row.Cells[lastCol - 1].Text));

                // check box if dev is assigned to logged in manager
                CheckBox cb = e.Row.Cells[lastCol].Controls[1] as CheckBox;
                cb.Checked = (Convert.ToInt32(drv["Selected"]) == 1);
            }
        }

        protected void cbSelected_CheckedChanged(object sender, EventArgs e)
        {
            //IDataProvider data = DataProviderFactory.CreateInstance();
            //CheckBox cb = sender as CheckBox;
            //GridViewRow row = cb.Parent.Parent as GridViewRow;

            //int devID = Convert.ToInt32(row.Cells[0].Text);
            //int mgrID = CookiesHelper.LoggedInUserID;

            //if (cb.Checked)
            //{
            //    data.AssignPMTUser(devID, mgrID, new TransactionFailedHandler(this.TransactionFailed));
            //}
            //else
            //{
            //    data.UnassignPMTUser(devID, mgrID, new TransactionFailedHandler(this.TransactionFailed));
            //}
        }
    }
}