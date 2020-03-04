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
using Newtonsoft.Json;



namespace UserRegistration.Controllers
{
    [ApiController]
    [Route("/users")]
    public class UserRegistrationController : ControllerBase
    {
        public static OrmUserRepository orm = new OrmUserRepository();

        [HttpPost]
        [Consumes("application/x-www-form-urlencoded")]
        public IActionResult RegisterUser(IFormCollection FormData)
        {
            if (FormData["password"].ToString().Length <= 8 || !FormData["password"].ToString().Contains("_"))
            {
                return new BadRequestObjectResult("The password is not valid");
            }
            if (orm.FindByEmail(FormData["email"].ToString()) != null)
            {
                return new BadRequestObjectResult("The email is already in use");
            }
            var rng = new Random();
            var user = new User
            {
                Id = rng.Next(1, 1000),
                Name = FormData["name"],
                Password = FormData["password"],
                Email = FormData["email"]
            };
            orm.Save(user);

            SmtpClient client = new SmtpClient("mysmtpserver");
            client.UseDefaultCredentials = false;
            client.Credentials = new NetworkCredential("smtpUsername", "smtpPassword");

            MailMessage mailMessage = new MailMessage();
            mailMessage.From = new MailAddress("noreply@codium.team");
            mailMessage.To.Add(FormData["email"]);
            mailMessage.Body = "This is the confirmation email";
            mailMessage.Subject = "Welcome to Codium";
            // If a proper SMTP server is configured, this line could be uncommented
            //client.Send(mailMessage);

            return new OkObjectResult(user);
        }
    }
}
