using System;
using System.Data;
using System.Drawing;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;
using PMTComponents;
using PMTDataProvider;

namespace PMT.Web.Controls
{
    public partial class Report : UserControl
    {
        private ProjectItem item;

        public void FillForm()
        {
            if (item != null)
            {
                lblType.Text = item.Type.ToString();
                lblName.Text = item.Name;
                lblDescription.Text = item.Description;
                lblStartDate.Text = item.StartDate.ToShortDateString();
                lblExpEndDate.Text = item.ExpEndDate.ToShortDateString();
                lblActEndDate.Text = item.ActEndDate.ToShortDateString();

                IDataProvider data = DataProviderFactory.CreateInstance();
                double status = data.ResolvePercentComplete(item);

                lblItemStatus.Text = status.ToString("p");
            }
        }

        #region Properties
        public ProjectItem Item
        {
            get {   return item;    }
            set {   item = value;   }
        }
        #endregion
    }
}
