using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Net.Mail;
using System.Net;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;




namespace UserRegistration.Controllers
{
    [ApiController]
    [Route("/users")]
    public class UserRegistrationController : ControllerBase
    {
        public static OrmUserRepository orm = new OrmUserRepository();

        [HttpPost]
        [Consumes("application/x-www-form-urlencoded")]
        public IActionResult RegisterUser([FromForm] string password, [FromForm] string name, [FromForm] string email)
        {
            if (password.Length <= 8 || !password.Contains("_"))
            {
                return new BadRequestObjectResult("The password is not valid");
            }
            if (orm.FindByEmail(email.ToString()) != null)
            {
                return new BadRequestObjectResult("The email is already in use");
            }
            var rng = new Random();
            var user = new User
            {
                Id = rng.Next(1, 1000),
                Name = name,
                Password = password,
                Email = email
            };
            orm.Save(user);

            SmtpClient client = new SmtpClient("mysmtpserver");
            client.UseDefaultCredentials = false;
            client.Credentials = new NetworkCredential("smtpUsername", "smtpPassword");

            MailMessage mailMessage = new MailMessage();
            mailMessage.From = new MailAddress("noreply@codium.team");
            mailMessage.To.Add(email);
            mailMessage.Body = "This is the confirmation email";
            mailMessage.Subject = "Welcome to Codium";
            // If a proper SMTP server is configured, this line could be uncommented
            //client.Send(mailMessage);

            return new OkObjectResult(user);
        }
    }
}
