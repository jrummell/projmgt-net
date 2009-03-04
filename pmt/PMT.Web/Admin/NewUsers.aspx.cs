using System;
using System.Web.UI;
using System.Web.UI.WebControls;
using PMT.BLL;

namespace PMT.Web.Admin
{
    public partial class NewUser : Page
    {
        private readonly UserService services = new UserService();

        /// <summary>
        /// Raises the <see cref="E:System.Web.UI.Control.Init"/> event to initialize the page.
        /// </summary>
        /// <param name="e">An <see cref="T:System.EventArgs"/> that contains the event data.</param>
        protected override void OnInit(EventArgs e)
        {
            base.OnInit(e);

            Load += Page_Load;
        }

        /// <summary>
        /// Handles the Load event of the Page control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindData();
            }
        }

        /// <summary>
        /// Handles the DeleteCommand event of the NewUserDataGrid control.
        /// </summary>
        /// <param name="source">The source of the event.</param>
        /// <param name="e">The <see cref="System.Web.UI.WebControls.DataGridCommandEventArgs"/> instance containing the event data.</param>
        protected void NewUserDataGrid_DeleteCommand(object source, DataGridCommandEventArgs e)
        {
            string delID = (NewUserDataGrid.Items[e.Item.ItemIndex].Cells[0].Text);
            services.Delete(Convert.ToInt32(delID));
            BindData();
        }

        /// <summary>
        /// Handles the CheckedChanged event of the cbEnabled control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        protected void cbEnabled_CheckedChanged(object sender, EventArgs e)
        {
            CheckBox cb = (CheckBox) sender;
            string id = ((DataGridItem) cb.Parent.Parent).Cells[0].Text;
            services.Enable(Convert.ToInt32(id), cb.Checked);
            BindData();
        }

        /// <summary>
        /// Binds the data.
        /// </summary>
        private void BindData()
        {
            //fill the datagrid with wannabe users
            NewUserDataGrid.DataSource = services.GetByEnabled(false);
            NewUserDataGrid.DataBind();
        }
    }
}