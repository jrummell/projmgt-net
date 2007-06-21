using System;
using System.Web.UI;
using PMT.BLL;

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

                throw new NotImplementedException();

                //IDataProvider data = DataProviderFactory.CreateInstance();
                //double status = data.ResolvePercentComplete(item);

                //lblItemStatus.Text = status.ToString("p");
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
