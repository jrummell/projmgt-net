using System;
using System.Web.UI;
using PMT.BLL;

namespace PMT.Web.AllUsers.Msg
{
    public partial class ViewMessage : Page
    {
        protected void Page_Load(object sender, System.EventArgs e)
        {
            if (!IsPostBack)
            {
                int messageID = MessageID;
                int userID = CookiesHelper.LoggedInUserID;

                throw new NotImplementedException();

                //IDataProvider data = DataProviderFactory.CreateInstance();

                //if (!data.IsMessageOpened(messageID, userID))
                //    data.UpdateOpenedMessage(messageID, userID, true, null);

                //Message message = data.GetMessage(MessageID);
                //FillForm(message);
            }
        }

        private void FillForm(Message message)
        {
            senderLabel.Text = String.Format("{0}, {1} ({2})",
                                             message.Sender.LastName,
                                             message.Sender.FirstName,
                                             message.Sender.UserName);
            dateLabel.Text = message.DateSent.ToString();
            dlRecipients.DataSource = message.Recipients;
            dlRecipients.DataBind();
            lblMessage.Text = message.Body;
            subjectLabel.Text = message.Subject;
        }

        #region Properties
        protected int MessageID
        {
            get 
            {
                int id = 0;
                try
                {
                    id = Convert.ToInt32(Request["id"]);
                }
                catch{}
                return id;
            }
        }
        #endregion
    }
}