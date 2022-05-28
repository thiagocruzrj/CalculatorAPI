using Calculator.API.Configurations;
using FluentAssertions;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.VisualStudio.TestPlatform.TestHost;
using System.Net;

namespace Calculator.UnitTests.ControllerTests
{
    public class LoginControllerTests
    {
        private const string SumEndpoint = "/api/operation/sum?value1=1&value2=1";

        private WebApplicationFactory<Program>? _factory;
        private HttpClient? _client;

        public LoginControllerTests()
        {
            _factory = new WebApplicationFactory<Program>();
            _client = _factory.CreateClient();
        }

        [Fact]
        [Trait("Calculator", "LoginControllerTests")]
        public async Task ReturnUnauthorizedIfIncorrectApiKeyPassed()
        {
            var request = new HttpRequestMessage(HttpMethod.Get, SumEndpoint);
            request.Headers.Add("Authorization", "1234");
            var response = _client.SendAsync(request).Result;

            response.StatusCode.Should().Be(HttpStatusCode.Unauthorized);
        }

        [Fact]
        [Trait("Calculator", "LoginControllerTests")]
        public async Task ReturnUnauthorizedIfNoApiKeyPassed()
        {
            var request = new HttpRequestMessage(HttpMethod.Get, SumEndpoint);
            var response = _client.SendAsync(request).Result;

            response.StatusCode.Should().Be(HttpStatusCode.Unauthorized);
        }
    }
}
