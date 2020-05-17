using JobApplication.Models;
using System;
using System.Net;
using System.Net.Mail;

namespace JobApplication.Services
{
    public class EmailSender : IEmailSender
    {
        private const string Hello = "Hello <strong>{0}</strong>, you apply for a <strong>{1}</strong>, at {2}.";
        private const string Text = "We will proceed you application further and send a feedback to you as soon as possible";
        private const string End = "Best regards, our team";
        private const string NewLine = "<br>";
        private string GetMessage(string name, Position position)
        {
            return NewLine + string.Format(
                Hello, name, position.ToString(), DateTime.Now) 
                + NewLine + Text + NewLine + NewLine
                + "<strong>" + End + "</strong>";
        }
        public void Send( string recepient, string name, Position position)
        {
            try
            {
                MailMessage message = new MailMessage();
                SmtpClient smtp = new SmtpClient();
                message.From = new MailAddress("CSahrp.MailClient@gmail.com");
                message.To.Add(new MailAddress(recepient));
                message.Subject = "Job application";
                message.IsBodyHtml = true; //to make message body as html  
                message.Body = GetMessage(name ,position);
                smtp.Port = 587;
                smtp.Host = "smtp.gmail.com"; //for gmail host  
                smtp.EnableSsl = true;
                smtp.UseDefaultCredentials = false;
                smtp.Credentials = new NetworkCredential("CSahrp.MailClient@gmail.com", "asdfaFRE456GRTT");
                smtp.DeliveryMethod = SmtpDeliveryMethod.Network;
                smtp.Send(message);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
