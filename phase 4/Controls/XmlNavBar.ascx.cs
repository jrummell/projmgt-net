namespace PMT.Controls
{
    using System;
    using System.Data;
    using System.Web;
    using System.Web.UI.WebControls;
    using System.Web.UI.HtmlControls;
    using System.Text;
    using System.Web.Security;

    /// <summary>
    ///		Summary description for XmlNavBar.
    /// </summary>
    public class XmlNavBar : System.Web.UI.UserControl
    {
        protected System.Web.UI.WebControls.Table navTable;

        private void Page_Load(object sender, System.EventArgs e)
        {
            // if the users is logged in, add a logged in links
            // else add a login and register links
            if(Context.User.Identity.IsAuthenticated)
            {
                string appPath = Request.ApplicationPath;
                string xmlFile = "NavLinks.xml";
               
                if (Request.Cookies["user"]["role"].Equals(PMT.User.Security.PROJECT_MANAGER))
                    loadXmlLinks(appPath+"/PM/"+xmlFile);
                else if (Request.Cookies["user"]["role"].Equals(PMT.User.Security.DEVELOPER))
                    loadXmlLinks(appPath+"/Dev/"+xmlFile);
                else if (Request.Cookies["user"]["role"].Equals(PMT.User.Security.ADMINISTRATOR))
                {
                    loadXmlLinks(appPath+"/Admin/"+xmlFile);
                    loadXmlLinks(appPath+"/PM/"+xmlFile);
                }
                else if (Request.Cookies["user"]["role"].Equals(PMT.User.Security.CLIENT))
                    loadXmlLinks(appPath+"/Client/"+xmlFile);

                addLink("Reports", "AllUsers/Reports.aspx");
                addLink("Profile", "AllUsers/Profile.aspx");
                addLink("Messaging", "AllUsers/Msg/");
                addLink("Logout", "Logout.aspx");
            }
            else
            {
                addLink("Login", "Login.aspx");
                addLink("Register", "Register.aspx");
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
