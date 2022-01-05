using System;
using System.Net;
using System.Net.Mail;

public class sendEmail
    {
        public static bool Send(string to, string subject, string body)
        {
            try
            {
                MailMessage message = new MailMessage("mohammadarzhangi.2022@gmail.com", to);
                message.Body = body;
                message.Subject = subject;
                message.IsBodyHtml = true;
                NetworkCredential mailAuthentication = new NetworkCredential("mohammadarzhangi.2022@gmail.com", "m350377m");
                SmtpClient mailClient = new SmtpClient("smtp.gmail.com", 587);
                mailClient.EnableSsl = true;
                mailClient.UseDefaultCredentials = false;
                mailClient.Credentials = mailAuthentication;
                mailClient.Send(message);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
    }