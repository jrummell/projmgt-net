using System;
using System.Collections;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Web;
using System.Web.SessionState;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;
using MySql;
using MySql.Data;
using MySql.Data.MySqlClient;

namespace PMT.PM
{
	/// <summary>
	/// Summary description for EditCompetency.
	/// </summary>
	public class EditCompetency : System.Web.UI.Page
	{
		protected System.Web.UI.WebControls.Label IDLabel;
		protected System.Web.UI.WebControls.Label FirstNameLabel;
		protected System.Web.UI.WebControls.Label LastNameLabel;
		protected System.Web.UI.WebControls.Label PresentCompetenceLabel;
		protected System.Web.UI.WebControls.Button SaveButton;
		protected System.Web.UI.WebControls.Button CancelButton;
		protected System.Web.UI.WebControls.Label devFirstLabel;
		protected System.Web.UI.WebControls.Label devLastLabel;
		protected System.Web.UI.WebControls.DropDownList DeveloperDropDownList;
		protected System.Web.UI.WebControls.DropDownList CompetenceDropDownList;
		protected System.Web.UI.WebControls.Panel DeveloperPanel;
	
		private void Page_Load(object sender, System.EventArgs e)
		{
			// Put user code to initialize the page here

			if(!Page.IsPostBack)
			{
				// fill drop down list
				// initialize the DB object
				DBDriver myDB=new DBDriver();
				//set the query to select all projects
				myDB.Query = "select p.ID as ID, p.lastName as lastName, p.firstName as firstName\n"
					       + "from users u, person p\n"
						   + "where u.security = 'Developer'\n"
						   + "and p.ID = u.ID;";
				//create a data set
				//DataSet ds=new DataSet();
				//initialize the data adapter
				//fill the data set with the data adapter
				MySqlDataReader dr = myDB.createReader();
				int i = 1;
				DeveloperDropDownList.Items.Insert(0,"");
				while( dr.Read() )
				{
					DeveloperDropDownList.Items.Insert(i,dr["lastName"].ToString() + ", " + dr["firstName"].ToString());
					DeveloperDropDownList.Items[i].Value = dr["ID"].ToString();
					i++;
				}

				myDB.close();

				CompetenceDropDownList.Items.Insert(0,"Low");
				CompetenceDropDownList.Items[0].Value= "Low";
				CompetenceDropDownList.Items.Insert(1,"Medium");
				CompetenceDropDownList.Items[1].Value= "Medium";
				CompetenceDropDownList.Items.Insert(2,"High");
				CompetenceDropDownList.Items[2].Value= "High";
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
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{    
			this.DeveloperDropDownList.SelectedIndexChanged += new System.EventHandler(this.DeveloperDropDownList_SelectedIndexChanged);
			this.SaveButton.Click += new System.EventHandler(this.Button_Click);
			this.CancelButton.Click += new System.EventHandler(this.Button_Click);
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion

		private void DeveloperDropDownList_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			/*
			 * get developer info and display it ...
			 * 
			 * */


			//initialize the DB object
			DBDriver myDB=new DBDriver();
			//set the appropriate SQL query
			myDB.Query = "select person.ID, firstName, lastName, competence"
				       + " from person, compLevels"
					   + " where person.ID = compLevels.ID and person.ID=@devID;";
			myDB.addParam("@devID", DeveloperDropDownList.SelectedValue);

			//initialize the datareader
			MySqlDataReader dr = myDB.createReader();
			//fill the datareader
			dr.Read();

			this.CancelButton.Visible = true; //reset buttons
			this.SaveButton.Visible = true;
			this.CompetenceDropDownList.Visible= true;
	
			
			try
			{
				this.devFirstLabel.Text=Convert.ToString(dr["firstName"]);
				this.devLastLabel.Text=Convert.ToString(dr["lastName"]);
				this.CompetenceDropDownList.SelectedValue = dr["competence"].ToString();
			}
			catch
			{
				this.devFirstLabel.Text="ERROR";
				this.devLastLabel.Text="ERROR";
			}

			myDB.close();
		

			
			DeveloperPanel.Visible = true;
		}

		private void Button_Click(object sender, System.EventArgs e)
		{
			if (sender.Equals(this.SaveButton))
			{
				//initialize the DB object
				DBDriver myDB=new DBDriver();
				//set the appropriate SQL query
				myDB.Query="update compLevels"
					+" set competence=@compLevel"
					+" where ID=@devID;";
				myDB.addParam("@devID", DeveloperDropDownList.SelectedValue);
				myDB.addParam("@compLevel", CompetenceDropDownList.SelectedValue);
				myDB.nonQuery();
				this.syncCompetenceText();//sync back both inputs to database values.
			}
			else
				syncCompetenceText();

				return;
			
				
		}

		private void syncCompetenceText()
		{
			//initialize the DB object
			DBDriver myDB=new DBDriver();
			//set the appropriate SQL query
			myDB.Query="select ID, competence"
				+" from compLevels"
				+" where compLevels.ID=@devID;";
			myDB.addParam("@devID", DeveloperDropDownList.SelectedValue);
			//initialize the datareader
			MySqlDataReader dr = myDB.createReader();
			//fill the datareader
			dr.Read();
			this.CompetenceDropDownList.SelectedValue = Convert.ToString(dr["competence"]);
			myDB.close();
			
		}


	}
}
