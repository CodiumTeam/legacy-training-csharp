using System;
using System.Collections.Generic;
using System.Diagnostics;
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
        [HttpPost]
        [Consumes("application/x-www-form-urlencoded")]
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
