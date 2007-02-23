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
using PMTDataProvider.Configuration;

namespace PMT.Admin
{
	/// <summary>
	/// Allows the Administrator to configure the application
	/// </summary>
	public partial class Settings : Page
	{
    
		protected void Page_Load(object sender, System.EventArgs e)
		{
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

            bool trusted = cbTrusted.Checked;

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

            // write the settings to web.config
            // the following line throws the exception on the next line:
            // PMTDataProvider.Configuration.Config.ConnectionString = cs.ToString();
            //   System.Configuration.ConfigurationErrorsException: The configuration is read only. 
            // To make this work I would have to implement a custom Configuration Handler, and I'd rather
            //   not right now, so I'm just displaying it instead.
            lblConnString.Text = "Your connection string: <br/>" + cs.ToString();
        }

		override protected void OnInit(EventArgs e)
		{
            this.Load += new System.EventHandler(this.Page_Load);
            cbTrusted.CheckedChanged += new EventHandler(cbTrusted_CheckedChanged);
            btnUpdate.Click += new EventHandler(btnUpdate_Click);
			base.OnInit(e);
		}
    }
}
