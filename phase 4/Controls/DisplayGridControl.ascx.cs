namespace PMT.Controls
{
	using System;
	using System.Data;
	using System.Drawing;
	using System.Web;
	using System.Web.UI.WebControls;
	using System.Web.UI.HtmlControls;

	/// <summary>
	///		Summary description for DisplayGridControl.
	/// </summary>
	public class DisplayGridControl : System.Web.UI.UserControl
	{
        protected System.Web.UI.WebControls.DataGrid DataGrid1;
        string type;

		private void Page_Load(object sender, System.EventArgs e)
		{
			// Put user code to initialize the page here
		}

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
            this.Load += new System.EventHandler(this.Page_Load);

        }
		#endregion

        public DataSet DataSource
        {
            set
            {   
                DataGrid1.DataSource = value;
                DataGrid1.DataBind();
            }
        }

        public string ReportType
        {
            get {   return type;    }
            set
            {
                type = value;

                DataGrid1.Columns[0].HeaderText = value + " Name";

                if (value.Equals(ProjectItem.ItemType.TASK))
                    return;

                //HyperLinkColumn col = (HyperLinkColumn) DataGrid1.Columns[0];
                HyperLinkColumn col = new HyperLinkColumn();
                col.HeaderText = DataGrid1.Columns[0].HeaderText;
                col.DataTextField = "name";
                col.DataNavigateUrlField = "id";

                // set item type to be displayed
                string item = "";

                if (value.Equals(ProjectItem.ItemType.PROJECT))
                    item = ProjectItem.ItemType.MODULE;
                else if(value.Equals(ProjectItem.ItemType.MODULE))
                    item = ProjectItem.ItemType.TASK;                

                col.DataNavigateUrlFormatString = Request.ApplicationPath + "/PM/Projects.aspx?item="+item+"&id={0}";
                DataGrid1.Columns.Remove(DataGrid1.Columns[0]);
                DataGrid1.Columns.AddAt(0, col);
            }
        }
	}
}
