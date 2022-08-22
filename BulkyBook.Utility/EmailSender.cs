using MailKit.Net.Smtp;
using Microsoft.AspNetCore.Identity.UI.Services;
using MimeKit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BulkyBook.Utility
{
    public class EmailSender:IEmailSender
    {
        public Task SendEmailAsync(string email,string subject,string htmlMessage)
        {
            var emailToSend = new MimeMessage();
            emailToSend.From.Add(MailboxAddress.Parse("hello@firstApp.com"));
            emailToSend.To.Add(MailboxAddress.Parse(email));
            emailToSend.Subject = subject;
            emailToSend.Body=new TextPart(MimeKit.Text.TextFormat.Html){ Text=htmlMessage};

            //send email using smtp
            using(var emailClient=new SmtpClient()){
                emailClient.Connect("smtp.gmail.com",587,MailKit.Security.SecureSocketOptions.StartTls);
                emailClient.Authenticate("puspamkarna69@gmail.com", "xanzkstuwxvawhvv");
                emailClient.Send(emailToSend);
                emailClient.Disconnect(true);


            }
            return Task.CompletedTask;
        }
    }
}
