using MailKit.Net.Smtp;
using MailKit.Security;
using MimeKit;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//using Microsoft.Extensions.Configuration;

namespace EmailService
{
    public class EmailSender: IEmailSender
    {
        private readonly EmailConfiguration _emailConfig;

        public EmailSender(EmailConfiguration emailConfig)
        {
            _emailConfig = emailConfig;
        }

        public void SendEmail(Message message)
        {
            var emailMessage = CreateEmailMessage(message);

            Send(emailMessage);
        }

        public async Task SendEmailAsync(Message message)
        {
            var mailMessage = CreateEmailMessage(message);

            await SendAsync(mailMessage);
        }

        private MimeMessage CreateEmailMessage(Message message)
         {
            var emailMessage = new MimeMessage();
            emailMessage.From.Add(new MailboxAddress(_emailConfig.From));
            emailMessage.To.AddRange(message.To);
            emailMessage.Subject = message.Subject;

            //-----Send attachment with email-----
            //emailMessage.Body = new TextPart(MimeKit.Text.TextFormat.Text) { Text = message.Content };
            //emailMessage.Body = new TextPart(MimeKit.Text.TextFormat.Html)
            //    { Text = string.Format("<h2 style='color:red'>{0}</h2>", message.Content) };

            var bodyBuilder = new BodyBuilder { HtmlBody = string.Format("{0}", message.Content) };

            //-----Send attachment with email-----
            //if (message.Attachments != null && message.Attachments.Any())
            //{
            //    byte[] fileBytes;
            //    foreach (var attachment in message.Attachments)
            //    {
            //        using (var memoryStream = new MemoryStream())
            //        {
            //            attachment.CopyTo(memoryStream);
            //            fileBytes = memoryStream.ToArray();
            //        }

            //        bodyBuilder.Attachments.Add(attachment.FileName, fileBytes, ContentType.Parse(attachment.ContentType));
            //    }
            //}

            emailMessage.Body = bodyBuilder.ToMessageBody();

            return emailMessage;
        }

        private void Send(MimeMessage mailMessage)
        {
            //using (var client = new MailKit.Net.Smtp.SmtpClient())
            using (var client = new SmtpClient())
            {
                try
                {
                    //client.SslProtocols = System.Security.Authentication.SslProtocols.Tls11;
                    //client.Connect(_emailConfig.SmtpServer, _emailConfig.Port, SecureSocketOptions.Auto);

                    client.ServerCertificateValidationCallback = (s, c, h, e) => true;

                    client.Connect(_emailConfig.SmtpServer, _emailConfig.Port, SecureSocketOptions.SslOnConnect);
                    client.AuthenticationMechanisms.Remove("XOAUTH2");
                    client.Authenticate(_emailConfig.UserName, _emailConfig.Password);

                    client.Send(mailMessage);
                }
                catch
                {
                    throw;
                }
                finally
                {
                    client.Disconnect(true);
                    client.Dispose();
                }
            }
        }

        private async Task SendAsync(MimeMessage emailMessage)
        {
            using (var client = new SmtpClient())
            {
                try
                {
                    // client.CheckCertificateRevocation = false;
                    //_emailConfig.Port = _emailConfig.Port == 0 ? 25 : _emailConfig.Port;

                    client.ServerCertificateValidationCallback = (s, c, h, e) => true;

                    await client.ConnectAsync(_emailConfig.SmtpServer, _emailConfig.Port, SecureSocketOptions.SslOnConnect);
                    client.AuthenticationMechanisms.Remove("XOAUTH2");
                    await client.AuthenticateAsync(_emailConfig.UserName, _emailConfig.Password);

                    await client.SendAsync(emailMessage);
                }
                catch(Exception e)
                {
                    throw;
                }
                finally
                {
                    await client.DisconnectAsync(true);
                    client.Dispose();
                }
            }

        }
    }
}
