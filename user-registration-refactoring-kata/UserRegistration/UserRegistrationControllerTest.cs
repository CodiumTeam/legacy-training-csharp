using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.TestHost;
using Xunit;

namespace UserRegistration
{

    public class UserRegistrationControllerTest 
    {
        [Fact]
        public async Task Should_success_when_everything_is_valid()
        {
            var server = new TestServer(new WebHostBuilder().UseStartup<UserRegistration.Startup>());
            var client = server.CreateClient();

            var response = await client.PostAsync("/users", null);

            response.EnsureSuccessStatusCode();
        }
    }
}