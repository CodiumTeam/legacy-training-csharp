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
            try
            {
                var user = new RegisterUser().Execute(formData["password"].ToString(), formData["email"].ToString(),
                    formData["name"].ToString());
                return new OkObjectResult(user);
            }
            catch (InvalidPasswordException e)
            {
                return new BadRequestObjectResult("The password is not valid");
            }
            catch (UserAlreadyExistsException e)
            {
                return new BadRequestObjectResult("The email is already in use");
            }
        }
    }
}