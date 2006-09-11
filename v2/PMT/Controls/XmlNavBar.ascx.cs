using System;
using System.Data;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;
using System.Text;
using System.Web.Security;
using PMTComponents;

namespace PMT.Controls
{
    /// <summary>
    /// Navigation Control.  Parses links from an xml in the user's role directory.
    /// </summary>
    public class XmlNavBar : UserControl
    {
        protected Table navTable;

        private void Page_Load(object sender, System.EventArgs e)
        {
            // if the user is logged in, give them links
            if(Context.User.Identity.IsAuthenticated)
            {
                string appPath = Request.ApplicationPath;
                string xmlFile = "NavLinks.xml";
               
                if (Request.Cookies["user"]["role"].Equals(PMTUserRole.Manager.ToString()))
                    loadXmlLinks(appPath+"/PM/"+xmlFile);
                else if (Request.Cookies["user"]["role"].Equals(PMTUserRole.Developer.ToString()))
                    loadXmlLinks(appPath+"/Dev/"+xmlFile);
                else if (Request.Cookies["user"]["role"].Equals(PMTUserRole.Administrator.ToString()))
                {
                    loadXmlLinks(appPath+"/Admin/"+xmlFile);
                    loadXmlLinks(appPath+"/PM/"+xmlFile);
                }
                else if (Request.Cookies["user"]["role"].Equals(PMTUserRole.Client.ToString()))
                    loadXmlLinks(appPath+"/Client/"+xmlFile);

                addLink("Reports", "AllUsers/Reports.aspx");
            }
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


        /// <summary>
        /// Add links from an XML file
        /// </summary>
        /// <param name="xmlFile">XML file with links</param>
        private void loadXmlLinks(string xmlFile)
        {
            DataSet ds = new DataSet();
            ds.ReadXml(Server.MapPath(xmlFile));

            if (ds.Tables.Count > 0)
            {
                foreach(DataRow item in ds.Tables[0].Rows)
                {
                    addLink(item["Text"].ToString(), item["Link"].ToString());
                }
            }
            addBreak();
        }

        /// <summary>
        /// Add a link to the navigation menu
        /// </summary>
        /// <param name="linkTitle">The title of the link</param>
        /// <param name="linkSource">The link source relative to the site root 
        /// (the part after "/~pmt/")</param>
        public void addLink(string linkTitle, string linkSource)
        {
            TableRow  row = new TableRow();
            TableCell cell = new TableCell();
            StringBuilder sb = new StringBuilder();

            sb.Append("<a href=\"");
            sb.Append(Request.ApplicationPath);
            sb.Append("/");
            sb.Append(linkSource);
            sb.Append("\" class=\"nav\">");
            sb.Append(linkTitle);
            sb.Append("</a>");
			
            cell.Text = sb.ToString();
            row.Cells.Add(cell);
            navTable.Rows.Add(row); 
        }

        /// <summary>
        /// Add a break to the navigation menu
        /// </summary>
        public void addBreak()
        {
            TableRow  row = new TableRow();
            TableCell cell = new TableCell();
            cell.Text = "&nbsp;";
            row.Cells.Add(cell);
            navTable.Rows.Add(row);
        }
    }
}
