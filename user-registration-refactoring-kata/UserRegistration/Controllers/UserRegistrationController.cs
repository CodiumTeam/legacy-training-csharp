using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace UserRegistration.Controllers
{
    [ApiController]
    [Route("/users")]
    public class UserRegistrationController : ControllerBase
    {
        private static readonly string[] Summaries = new[]
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

        [HttpGet]
        public User Get()
        {
            var rng = new Random();
            return new User
            {
                Id = rng.Next(1,1000),
                Name = "Jordi",
                Password = "aPassword",
                Email = "jordi@codium.team"
            };
        }
    }
}
