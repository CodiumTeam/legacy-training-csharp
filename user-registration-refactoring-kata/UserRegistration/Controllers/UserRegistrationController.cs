using System;
using System.Collections.Generic;
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
        [HttpPost]
        public User RegisterUser(IFormCollection FormData)
        {
            var rng = new Random();
            return new User
            {
                Id = rng.Next(1,1000),
                Name = FormData["name"],
                Password = FormData["password"],
                Email = FormData["email"]
            };
        }
    }
}
