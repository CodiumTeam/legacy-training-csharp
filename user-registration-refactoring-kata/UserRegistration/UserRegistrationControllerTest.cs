using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.TestHost;
using Xunit;

namespace UserRegistration
{

    public class UserRegistrationControllerTest 
    {
        [Fact]
        public async Task Register_user()
        {
            // Arrange
            var server = new TestServer(new WebHostBuilder().UseStartup<UserRegistration.Startup>());
            var client = server.CreateClient();

            // Act
            var response = await client.PostAsync("/users", null);

            // Assert
            response.EnsureSuccessStatusCode(); // Status Code 200-299
        }
    }
}