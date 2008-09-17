using System;
using System.Web.UI;
using PMT.BLL;

namespace PMT.Web.Controls
{
    public partial class Report : UserControl
    {
        private ProjectItem item;

        public ProjectItem Item
        {
            get { return item; }
            set { item = value; }
        }

        public void FillForm()
        {
            if (item != null)
            {
                lblType.Text = item.Type.ToString();
                lblName.Text = item.Name;
                lblDescription.Text = item.Description;
                lblStartDate.Text = Utility.MaskNull(item.StartDate);
                lblExpEndDate.Text = Utility.MaskNull(item.ExpEndDate);
                lblActEndDate.Text = Utility.MaskNull(item.ActEndDate);

                throw new NotImplementedException();

                //IDataProvider data = DataProviderFactory.CreateInstance();
                //double status = data.ResolvePercentComplete(item);

                //lblItemStatus.Text = status.ToString("p");
            }
        }
    }
}