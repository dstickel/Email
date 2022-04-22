using System.Collections;
using System.Net;
using System.Net.Mail;

namespace EmailTest
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void btnSend_Click(object sender, EventArgs e)
        {
            Dispatcher dispatcher = new Dispatcher();
            dispatcher.From = "sender@gmail.com";                          // The email of the account to send the message.
            dispatcher.To = "recipient@gmail.com";                         // The account to send the message to.
            dispatcher.Subject = "Class test";
            dispatcher.IsBodyHtml = true;
            dispatcher.Body = "This email class worked";
            dispatcher.Port = 587;                                         // Email server port.
            dispatcher.Host = "smtp.office365.com";                        // Email server host.
            dispatcher.EnableSSL = true;
            dispatcher.UseDefaultCredentials = false;
            dispatcher.Username = "user@gmail.com";                        // Username for the send account.
            dispatcher.Password = "password";                              // Password for the send account.
            dispatcher.SendAlert();
            txtResult.Text = dispatcher.Result.ToString();
            txtMessage.Text = dispatcher.LogMessage;
        }
    }
}