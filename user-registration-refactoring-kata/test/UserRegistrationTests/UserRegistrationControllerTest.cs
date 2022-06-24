using System.Net;
using UserRegistration.Controllers;
using Microsoft.AspNetCore.Mvc.Testing;
using System.Text.Json.Nodes;
using UserRegistration.Infrastructure;

namespace UserRegistration
{

    public class UserRegistrationControllerTest
    {
        private HttpClient client;

        public UserRegistrationControllerTest()
        {
            var server = new WebApplicationFactory<Program>();
            
            client = server.CreateClient();
            UserRegistrationController.orm = new OrmUserRepository();
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

            
            var responseContent = JsonNode.Parse(await response.Content.ReadAsStringAsync());
            Assert.Equal("info@codium.team", responseContent?["email"]?.ToString());
        }

        [Fact]
        public async Task Should_returns_a_user_with_the_name_when_everything_is_valid()
        {
            var arguments = ValidArguments(Name: "Codium");

            var response = await client.PostAsync("/users", new FormUrlEncodedContent(arguments));
            
            var responseContent = JsonNode.Parse(await response.Content.ReadAsStringAsync());
            Assert.Equal("Codium", responseContent?["name"]?.ToString());
        }  

        [Fact]
        public async Task Should_fail_when_password_is_short()
        {
            var arguments = ValidArguments(Password: "myPs_1");

            var response = await client.PostAsync("/users", new FormUrlEncodedContent(arguments));

            Assert.Equal(HttpStatusCode.BadRequest, response.StatusCode);
            Assert.Equal("The password is not valid", await response.Content.ReadAsStringAsync());
        }

        [Fact]
        public async Task Should_fail_when_password_does_not_contains_underscore()
        {
            var arguments = ValidArguments(Password: "myPasss123123");

            var response = await client.PostAsync("/users", new FormUrlEncodedContent(arguments));

            Assert.Equal(HttpStatusCode.BadRequest, response.StatusCode);
            Assert.Equal("The password is not valid", await response.Content.ReadAsStringAsync());
        }

        [Fact]
        public async Task Should_fail_when_email_is_used()
        {
            var arguments = ValidArguments();
            await client.PostAsync("/users", new FormUrlEncodedContent(arguments));

            var response = await client.PostAsync("/users", new FormUrlEncodedContent(arguments));

            Assert.Equal(HttpStatusCode.BadRequest, response.StatusCode);
            Assert.Equal("The email is already in use", await response.Content.ReadAsStringAsync());
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