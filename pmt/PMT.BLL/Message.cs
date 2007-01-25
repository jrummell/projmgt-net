using System;
using System.Text;

namespace PMT.BLL
{
	/// <summary>
	/// A PMT Message
	/// </summary>
	public class Message
	{
        #region Attributes
        private int id;
        private User sender;
        private User[] recipients;
        private DateTime dateSent;
        private string subject;
        private StringBuilder body;
        #endregion

        #region Constructors
        /// <summary>
        /// Main Constructor
        /// </summary>
        /// <param name="id">Message ID</param>
        /// <param name="sender">Sender</param>
        /// <param name="recipients">Recipients</param>
        /// <param name="dateSent">Date Sent</param>
        /// <param name="subject">Subject</param>
        /// <param name="body">Body</param>
        public Message(int id, User sender, User[] recipients, 
            DateTime dateSent, string subject, string body)
        {
            this.ID = id;
            this.Sender = sender;
            this.Recipients = recipients;
            this.DateSent = dateSent;
            //this.DateReceived = dateReceived;
            this.Subject = subject;
            this.Body = body;
        }

        /// <summary>
        /// Constructor for a new Message
        /// </summary>
        /// <param name="sender">Sender</param>
        /// <param name="recipients">Recipients</param>
        /// <param name="dateSent">Date Sent</param>
        /// <param name="dateReceived">Date Sent</param>
        /// <param name="subject">Subject</param>
        /// <param name="body">Body</param>
        public Message(User sender, User[] recipients, 
            DateTime dateSent, DateTime dateReceived,
            string subject, string body)
            : this (0, sender, recipients, dateSent, subject, body) {}

        /// <summary>
        /// Default Constructor.  Creates a blank Message.
        /// </summary>
		public Message()
            : this (0, null, null, 
                DateTime.MinValue, String.Empty, String.Empty) {}
        #endregion

        #region Properties
        /// <summary>
        /// Gets or sets the Message ID
        /// </summary>
        public int ID
        {
            get {   return id;      }
            set 
            {   
                if (value<0)
                    throw new Exception("Message ID must be greater than 0.");
                id = value;     
            }
        }
        /// <summary>
        /// Gets or sets the Sender 
        /// </summary>
        public User Sender
        {
            get {   return sender;          }
            set {   sender = value;         }
        }
        /// <summary>
        /// Gets or sets the Recipients 
        /// </summary>
        public User[] Recipients
        {
            get {   return recipients;                          }
            set {   recipients = value.Clone() as User[];    }
        }
        /// <summary>
        /// Gets or sets the Date Sent
        /// </summary>
        public DateTime DateSent
        {
            get {   return dateSent;    }
            set {   dateSent = value;   }
        }
        ///// <summary>
        ///// Gets or sets the Date Received
        ///// </summary>
        //public DateTime DateReceived
        //{
        //    get {   return dateReceived;    }
        //    set {   dateReceived = value;   }
        //}
        /// <summary>
        /// Gets or sets the Subject
        /// </summary>
        public string Subject
        {
            get {   return subject;     }
            set {   subject = value;    }
        }
        /// <summary>
        /// Gets or sets the Body
        /// </summary>
        public string Body
        {
            get {   return body.ToString();             }
            set {   body = new StringBuilder(value);    }
        }
        /// <summary>
        /// Gets or sets the Body as a StringBuilder
        /// </summary>
        public StringBuilder BodyStringBuilder
        {
            get {   return body;    }
            set {   body = value;   }
        }
        #endregion

        #region Methods
        /// <summary>
        /// Reply to a message
        /// </summary>
        /// <param name="m">Message to Reply to</param>
        public void Reply(Message m)
        {
            Subject = String.Format("RE: {0}", m.Subject);
            Body = GetReplyForwardBlock(m);

            recipients = new User[1];
            recipients[0] = m.Sender;
        }

        /// <summary>
        /// Forward a Message
        /// </summary>
        /// <param name="m">Message to Forward</param>
        public void Forward(Message m)
        {
            Subject = String.Format("FW: {0}", m.Subject);
            Body = GetReplyForwardBlock(m);
        }

        /// <summary>
        /// Returns a standard Reply or Forward block of text based on the given message
        /// </summary>
        private string GetReplyForwardBlock(Message m)
        {
            StringBuilder block = new StringBuilder();
            block.Append("\r\n\r\n\r\n");
            block.Append(" --- Original Message --- \r\n");
            block.AppendFormat("From: {1}, {0} \r\n", m.Sender.FirstName, m.Sender.LastName);
            block.AppendFormat("Sent: {0} \r\n", m.DateSent.ToString());
            block.AppendFormat("To: {1}, {0} \r\n", Sender.FirstName, Sender.LastName);
            block.AppendFormat("Subject: {0}", m.Subject);
            block.Append("\r\n\r\n");
            block.Append(m.Body);
            return block.ToString();
        }
        #endregion
    }
}
