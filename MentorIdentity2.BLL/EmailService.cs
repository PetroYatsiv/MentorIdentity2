using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using MimeKit;
using MailKit.Net.Smtp;

namespace MentorIdentity2.BLL
{
    public class EmailService
    {
        //public async Task SendEmailAsync(string email, string subject, string message)
        //{
        //    var emailMessage = new MimeMessage();

        //    emailMessage.From.Add(new MailboxAddress("Admin", "yatsiv01@gmail.com"));
        //    emailMessage.To.Add(new MailboxAddress("", email));
        //    emailMessage.Subject = subject;
        //    emailMessage.Body = new TextPart(MimeKit.Text.TextFormat.Html)
        //    {
        //        Text = message
        //    };

        //    using (var client = new SmtpClient())
        //    {
        //        await client.ConnectAsync("smtp.gmail.com", 25, false);
        //        await client.AuthenticateAsync("yatsiv01@gmail.com", "@@#!&&#PETRO");
        //        await client.SendAsync(emailMessage);

        //        await client.DisconnectAsync(true);
        //    }


        //}
    }
}
