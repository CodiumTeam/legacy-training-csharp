using System.Net;
using System.Net.Mail;
using UserRegistration.Domain;

namespace UserRegistration.UseCase;

public class SmtpEmailSender: EmailSender
{
    public void SendEmail(Email email)
    {
        SmtpClient client = new SmtpClient("mysmtpserver");
        client.UseDefaultCredentials = false;
        client.Credentials = new NetworkCredential("smtpUsername", "smtpPassword");

        MailMessage mailMessage = new MailMessage();
        mailMessage.From = new MailAddress(email.From);
        mailMessage.To.Add(email.To);
        mailMessage.Body = email.Body;
        mailMessage.Subject = email.Subject;
        // If a proper SMTP server is configured, this line could be uncommented
        //client.Send(mailMessage);
    }

}