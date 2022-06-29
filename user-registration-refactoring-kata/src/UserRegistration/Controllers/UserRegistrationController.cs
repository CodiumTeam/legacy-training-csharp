using System.Net.Mail;
using System.Net;
using Microsoft.AspNetCore.Mvc;
using UserRegistration.Domain;
using UserRegistration.Infrastructure;
using UserRegistration.UseCase;

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
            return new RegisterUser().Execute(formData);
        }
    }
}
