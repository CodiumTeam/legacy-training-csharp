﻿using System.Net.Mail;
using System.Net;
using Microsoft.AspNetCore.Mvc;
using UserRegistration.Domain;
using UserRegistration.Infrastructure;

namespace UserRegistration.Controllers
{
    [ApiController]
    [Route("/users")]
    public class UserRegistrationController : ControllerBase
    {
        public static OrmUserRepository orm = new OrmUserRepository();

        [HttpPost]
        [Consumes("application/x-www-form-urlencoded")]
        public IActionResult RegisterUser(IFormCollection formData)
        {
            if (formData["password"].ToString().Length <= 8 || !formData["password"].ToString().Contains("_"))
            {
                return new BadRequestObjectResult("The password is not valid");
            }
            if (orm.FindByEmail(formData["email"].ToString()) != null)
            {
                return new BadRequestObjectResult("The email is already in use");
            }
            var rng = new Random();
            var user = new User
            {
                Id = rng.Next(1, 1000),
                Name = formData["name"].ToString(),
                Password = formData["password"].ToString(),
                Email = formData["email"].ToString()
            };
            orm.Save(user);

            SmtpClient client = new SmtpClient("mysmtpserver");
            client.UseDefaultCredentials = false;
            client.Credentials = new NetworkCredential("smtpUsername", "smtpPassword");

            MailMessage mailMessage = new MailMessage();
            mailMessage.From = new MailAddress("noreply@codium.team");
            mailMessage.To.Add(formData["email"].ToString());
            mailMessage.Body = "This is the confirmation email";
            mailMessage.Subject = "Welcome to Codium";
            // If a proper SMTP server is configured, this line could be uncommented
            //client.Send(mailMessage);

            return new OkObjectResult(user);
        }
    }
}
