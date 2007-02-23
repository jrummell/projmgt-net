using System;
using System.Data;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;
using System.Text;
using System.Web.Security;
using PMT.Configuration;
using PMTComponents;
using PMT.BLL;
using PMT.Web;

namespace PMT.Web.Controls
{
    public partial class Navigation : UserControl
    {
        protected void Page_Load(object sender, System.EventArgs e)
        {
            // if the users is logged in, add a logged in links
            // else add a login and register links
            if (Context.User.Identity.IsAuthenticated)
            {
                // parse role from cookie
                UserRole role = CookiesHelper.LoggedInUserRole;

                string dir = PathHelper.GetUserDefaultPath(role);

                // unknown role
                if (dir == null)
                    return;

                string xmlFile = "NavLinks.xml";
                StringBuilder sbPath = new StringBuilder();
                sbPath.Append(dir).Append(xmlFile);
                
                LoadXmlLinks(sbPath.ToString());

                // managers and client get reports
                if (role == UserRole.Manager ||
                    role == UserRole.Client)
                {
                    AddLink("Reports", "AllUsers/Reports.aspx");
                }
            }
        }

        /// <summary>
        /// Add links from an XML file
        /// </summary>
        /// <param name="xmlFile">XML file with links</param>
        private void LoadXmlLinks(string xmlFile)
        {
            DataSet ds = new DataSet();
            ds.ReadXml(Server.MapPath(xmlFile));

            if (ds.Tables.Count > 0)
            {
                foreach(DataRow item in ds.Tables[0].Rows)
                {
                    AddLink(item["Text"].ToString(), item["Link"].ToString());
                }
            }
            AddBreak();
        }

        /// <summary>
        /// Add a link to the navigation menu
        /// </summary>
        /// <param name="linkTitle">The title of the link</param>
        /// <param name="linkSource">The link source relative to the site root 
        /// (the part after "/~pmt/")</param>
        public void AddLink(string linkTitle, string linkSource)
        {
            TableRow  row = new TableRow();
            TableCell cell = new TableCell();
            StringBuilder sb = new StringBuilder();

            sb.Append("<a href=\"");
            sb.Append(PathHelper.ApplicationPath);
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
        public void AddBreak()
        {
            TableRow  row = new TableRow();
            TableCell cell = new TableCell();
            cell.Text = "&nbsp;";
            row.Cells.Add(cell);
            navTable.Rows.Add(row);
        }
    }
}
