using System;
using System.Collections;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Web;
using System.Web.SessionState;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;
using System.Text;
using System.Configuration;

namespace PMT.Admin
{
	/// <summary>
	/// Allows the Administrator to configure the application
	/// </summary>
	public partial class Settings : Page
	{
    
		protected void Page_Load(object sender, System.EventArgs e)
		{
            if (!IsPostBack)
            {
                rblDbType.DataSource = Enum.GetNames(typeof(DatabaseType));
                rblDbType.DataBind();
            }
		}

        private void rblDbType_SelectedIndexChanged(object sender, EventArgs e)
        {
            RadioButtonList rbl = sender as RadioButtonList;
            DatabaseType db = (DatabaseType)Enum.Parse(typeof(DatabaseType), rbl.SelectedValue);

            cbTrusted.Enabled = (db == DatabaseType.SqlServer);
        }

        private void cbTrusted_CheckedChanged(object sender, EventArgs e)
        {
            CheckBox cb = sender as CheckBox;
            bool enabled = !cb.Checked;

            txtUsername.Enabled  = enabled;
            txtPassword1.Enabled = enabled;
            txtPassword2.Enabled = enabled;

            rfvUsername.Enabled  = enabled;
            rfvPassword1.Enabled = enabled;
            rfvPassword2.Enabled = enabled;
            cvPassword.Enabled   = enabled;
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (!IsValid)
                return;

            StringBuilder cs = new StringBuilder();

            DatabaseType db = (DatabaseType)Enum.Parse(typeof(DatabaseType), rblDbType.SelectedValue);
            bool trusted = cbTrusted.Checked;

            if (db == DatabaseType.MySql)
            {
                // "Server=Server;Database=Test;Uid=UserName;Pwd=asdasd;"
                cs.AppendFormat("Server={0};Database={1};Uid={2};Pwd={3};",
                    txtServer.Text, txtDatabase.Text, txtUsername.Text, txtPassword1.Text);
            }
            else if (db == DatabaseType.SqlServer)
            {
                cs.AppendFormat("Server={0};Database={1};Trusted_Connection={2};",
                    txtServer.Text, txtDatabase.Text, trusted.ToString());
                if (trusted)
                {
                    // "Server=Aron1;Database=pubs;Trusted_Connection=True;"
                }
                else
                {
                    // "Server=Aron1;Database=pubs;User ID=sa;Password=asdasd;Trusted_Connection=False" 
                    cs.AppendFormat("User ID={0};Password={1}",
                        txtUsername.Text, txtPassword1.Text);
                } 
            }
            else
            {}

            Response.Write(cs.ToString());

            // write the settings to web.config
            // throws an Access to the path ... is denied. 
            //PMTDataProvider.Configuration.ConnectionString = cs.ToString();
        }

		override protected void OnInit(EventArgs e)
		{
            this.Load += new System.EventHandler(this.Page_Load);
            rblDbType.SelectedIndexChanged += new EventHandler(rblDbType_SelectedIndexChanged);
            cbTrusted.CheckedChanged += new EventHandler(cbTrusted_CheckedChanged);
            btnUpdate.Click += new EventHandler(btnUpdate_Click);
			base.OnInit(e);
		}
    }
}
