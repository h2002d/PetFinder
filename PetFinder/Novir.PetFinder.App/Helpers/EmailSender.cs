using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Threading.Tasks;

namespace Novir.PetFinder.App.Helpers
{
    public class EmailSender : IEmailSender
    {
        private readonly EmailSettings _emailSettings;

        public EmailSender(IOptions<EmailSettings> emailSettings)
        {
            _emailSettings = emailSettings.Value;
        }

        public async Task SendEmailAsync(string email, string subject, string htmlMessage)
        {
            try
            {
                MailMessage mail = new MailMessage();
                SmtpClient SmtpServer = new SmtpClient(_emailSettings.MailServer);

                mail.From = new MailAddress(_emailSettings.Sender);
                mail.To.Add(email);
                mail.Subject = subject;
                mail.Body = htmlMessage;
                mail.IsBodyHtml = true;

                SmtpServer.Port = _emailSettings.MailPort;
                SmtpServer.Credentials = new System.Net.NetworkCredential(_emailSettings.Sender, "dD341044*");
                SmtpServer.EnableSsl = false;

                SmtpServer.SendAsync(mail,null);
            }
            catch (Exception ex)
            {
                //throw ex;Identity/Account/Manage
            }
        }
    }

    public class EmailSettings
    {
        public string MailServer { get; set; }
        public int MailPort { get; set; }
        public string SenderName { get; set; }
        public string Sender { get; set; }
        public string Password { get; set; }
    }
}
