using System;
using System.ComponentModel;
using System.Net;
using System.Net.Mail;
using System.Threading.Tasks;
using accesscontrol.Service;
using accesscontrol.Util;
using AutoMapper.Configuration;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

namespace accesscontrol.Service
{
    public class EmailSender : IEmailSender
    {
        private readonly IOptions<EmailSettings> settings;
        private static ILogger logger;

        public EmailSender(IOptions<EmailSettings> settings, ILoggerFactory loggerfactory)
        {
            logger = loggerfactory.CreateLogger("EmailSender"); ;
            this.settings = settings;
        }

        private static void SendCompletedCallback(object sender, AsyncCompletedEventArgs e)
        {
            string token = (string)e.UserState;

            if (e.Cancelled)
            {
                logger.LogError($"Send canceled. Email [{token}]");

                Console.WriteLine();
            }
            if (e.Error != null)
            {
                logger.LogError($"[{token}] {e.Error.ToString()}");
            }
            else
            {
                logger.LogInformation("Message sent. [{token}]");
            }
        }

        public void SendEmail(string body, string email)
        {
            var fromAddress = new MailAddress(settings.Value.From);

            MailMessage mailMessage = new MailMessage();
            mailMessage.From = fromAddress;
            mailMessage.SubjectEncoding = System.Text.Encoding.UTF8;
            mailMessage.To.Add(email);
            mailMessage.Body = body;
            mailMessage.Subject = settings.Value.Subject;

            var client = new SmtpClient(settings.Value.SmtpClient, settings.Value.Port);
            client.EnableSsl = settings.Value.EnableSsl;
            client.DeliveryMethod = System.Net.Mail.SmtpDeliveryMethod.Network;
            client.UseDefaultCredentials = settings.Value.UseDefaultCredentials;
            client.Credentials = new NetworkCredential(fromAddress.Address, settings.Value.Password);
            client.SendCompleted += new
           SendCompletedEventHandler(SendCompletedCallback);
            client.SendAsync(mailMessage, email);
        }
    }
}