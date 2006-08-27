using System;
using System.Data;
using System.Drawing;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;
using PMTComponents;
using PMTDataProvider;

namespace PMT.Controls
{
    public class Report : UserControl
    {
        protected Label lblType;
        protected Label lblName;
        protected Label lblDescription;
        protected Label lblStartDate;
        protected Label lblExpEndDate;
        protected Label lblActEndDate;
        protected Label lblItemStatus;
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
        ///		Required method for Designer support - do not modify
        ///		the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
        }
        #endregion
    }
}
