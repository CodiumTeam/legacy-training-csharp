using System.Net;
using System.Net.Mail;
using Microsoft.AspNetCore.Mvc;
using UserRegistration.Controllers;
using UserRegistration.Domain;

namespace UserRegistration.UseCase;

public class RegisterUser
{
    public IActionResult Execute(string Password, string Email, string Name)
    {
        if (Password.Length <= 8 || !Password.Contains("_"))
        {
            return new BadRequestObjectResult("The password is not valid");
        }

        if (UserRegistrationController.orm.FindByEmail(Email) != null)
        {
            return new BadRequestObjectResult("The email is already in use");
        }

        var rng = new Random();
        var user = new User
        {
            Id = rng.Next(1, 1000),
            Name = Name,
            Password = Password,
            Email = Email
        };
        UserRegistrationController.orm.Save(user);

        SmtpClient client = new SmtpClient("mysmtpserver");
        client.UseDefaultCredentials = false;
        client.Credentials = new NetworkCredential("smtpUsername", "smtpPassword");

        MailMessage mailMessage = new MailMessage();
        mailMessage.From = new MailAddress("noreply@codium.team");
        mailMessage.To.Add(Email);
        mailMessage.Body = "This is the confirmation email";
        mailMessage.Subject = "Welcome to Codium";
        // If a proper SMTP server is configured, this line could be uncommented
        //client.Send(mailMessage);

        return new OkObjectResult(user);
    }
}