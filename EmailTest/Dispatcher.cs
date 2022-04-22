using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace EmailTest
{
    public class Dispatcher
    {
        /// <summary>
        /// The the email address to send the message from.
        /// </summary>
        public string From { get; set; } 
        
        /// <summary>
        /// The email address to send the message to.
        /// </summary>
        public string To { get; set; } 
        
        /// <summary>
        /// Subject of the message.
        /// </summary>
        public string Subject { get; set; } 

        /// <summary>
        /// Wheather the body is Html or not.
        /// </summary>
        public bool IsBodyHtml { get; set; }  
        
        /// <summary>
        /// Body of the email message.
        /// </summary>
        public string Body { get; set; }
        
        /// <summary>
        /// Port used for sending the message. Ex. 587, 993, 995;
        /// </summary>
        public int Port { get; set; }

        /// <summary>
        /// Host used to send the message. Ex. Server: (smtp.office365.com).
        /// </summary>
        public string Host { get; set; } 
        
        /// <summary>
        /// Wheather to use SSL or not.
        /// </summary>
        public bool EnableSSL { get; set; } 

        /// <summary>
        /// Wheather to use default credentials or not.
        /// </summary>
        public bool UseDefaultCredentials { get; set; } 

        /// <summary>
        /// Username for the account sending the email. When not using default crendentials.
        /// </summary>
        public string Username { get; set; }

        /// <summary>
        /// Password for the account sending the email. When not using default crendentials.
        /// </summary>
        public string Password { get; set; }

        /// <summary>
        /// The send result. Idle before an attemp. Success or Failure after a send attempt.
        /// </summary>
        public SendResult Result { get; set; } = SendResult.Idle;

        /// <summary>
        /// String log message for send result.
        /// </summary>
        public string LogMessage { get; set; }  
        
        /// <summary>
        /// Class constructor.
        /// </summary>
        public Dispatcher()
        {

        }

        /// <summary>
        /// Send an alert.
        /// </summary>
        public void SendAlert()
        {
            try
            {
                MailMessage message = new MailMessage();
                SmtpClient smtp = new SmtpClient();
                message.From = new MailAddress(From);
                message.To.Add(new MailAddress(To));
                message.Subject = Subject;
                message.IsBodyHtml = IsBodyHtml; 
                message.Body = Body;
                smtp.Port = Port;
                smtp.Host = Host;
                smtp.EnableSsl = EnableSSL;
                smtp.UseDefaultCredentials = UseDefaultCredentials;
                smtp.Credentials = new NetworkCredential(Username, Password);
                smtp.DeliveryMethod = SmtpDeliveryMethod.Network;
                smtp.Send(message);
                Result = SendResult.Success;
                LogMessage = "Send success";
            }
            catch (Exception ex)
            {
                Result = SendResult.Failure;
                LogMessage = "Send fail" + ex.Message;
            }
        }
    }
}
