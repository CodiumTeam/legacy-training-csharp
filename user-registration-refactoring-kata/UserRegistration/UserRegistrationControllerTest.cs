using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.TestHost;
using Newtonsoft.Json;
using Xunit;

namespace UserRegistration
{

    public class UserRegistrationControllerTest
    {
        private HttpClient client;

        public UserRegistrationControllerTest()
        {
            var server = new TestServer(new WebHostBuilder().UseStartup<UserRegistration.Startup>());
            client = server.CreateClient();
        }

        [Fact]
        public async Task Should_success_when_everything_is_valid()
        {
            var arguments = ValidArguments();

            var response = await client.PostAsync("/users", new FormUrlEncodedContent(arguments));

            response.EnsureSuccessStatusCode();
        }

        [Fact]
        public async Task Should_returns_a_user_with_the_email_when_everything_is_valid()
        {
            var arguments = ValidArguments(Email: "info@codium.team");

            var response = await client.PostAsync("/users", new FormUrlEncodedContent(arguments));

            var responseContent = JsonConvert.DeserializeObject<Dictionary<string, string>>(await response.Content.ReadAsStringAsync());
            Assert.Equal("info@codium.team", responseContent["email"]);
        }

        public Dictionary<string, string> ValidArguments(string Name = "Codium", string Email = "info@codium.team", string Password = "myPass_123123" )
        {
            return new Dictionary<string, string>()
            {
                { "name", Name } ,
                { "email", Email } ,
                { "password", Password } ,
            };
        }
    }
}