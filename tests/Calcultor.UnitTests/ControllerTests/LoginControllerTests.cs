using FluentAssertions;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.VisualStudio.TestPlatform.TestHost;
using System.Net;

namespace Calculator.UnitTests.ControllerTests
{
    public class LoginControllerTests
    {
        private bool _disposed;

        private WebApplicationFactory<Program>? _factory;
        private HttpClient? _client;
        private readonly string apiKey = "eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCIsImN0eSI6IkpXVCJ9.eyJleHAiOjE2NTM2ODk3OTd9.Lj8KqX-G2swXaSqh8zuk4_pKhEejN4YpIUDtbSGyF3I";

        public LoginControllerTests()
        {
            _factory = new WebApplicationFactory<Program>();
            _client = _factory.CreateClient();
        }

        [Fact]
        [Trait("Calculator", "LoginControllerTests")]
        public async Task AddValuesSuccessfully()
        {
            var request = new HttpRequestMessage(HttpMethod.Get, "/api/operation/sum?value1=1&value2=1");
            request.Headers.Add("Authorization", apiKey);
            var response = _client.SendAsync(request).Result;

            var calcResult = await response.Content.ReadAsStringAsync();

            response.StatusCode.Should().Be(HttpStatusCode.OK);
            calcResult.Should().Be("2");
        }

        [Fact]
        [Trait("Calculator", "LoginControllerTests")]
        public async Task SubtractValuesSuccessfully()
        {
            var request = new HttpRequestMessage(HttpMethod.Get, "/api/operation/subtract?value1=1&value2=1");
            request.Headers.Add("Authorization", apiKey);
            var response = _client.SendAsync(request).Result;

            var calcResult = await response.Content.ReadAsStringAsync();

            response.StatusCode.Should().Be(HttpStatusCode.OK);
            calcResult.Should().Be("0");
        }

        [Fact]
        [Trait("Calculator", "LoginControllerTests")]
        public async Task MultiplyValuesSuccessfully()
        {
            var request = new HttpRequestMessage(HttpMethod.Get, "/api/operation/multiply?value1=1&value2=1");
            request.Headers.Add("Authorization", apiKey);
            var response = _client.SendAsync(request).Result;

            var calcResult = await response.Content.ReadAsStringAsync();

            response.StatusCode.Should().Be(HttpStatusCode.OK);
            calcResult.Should().Be("1");
        }

        [Fact]
        [Trait("Calculator", "LoginControllerTests")]
        public async Task DivideValuesSuccessfully()
        {
            var request = new HttpRequestMessage(HttpMethod.Get, "/api/operation/divide?value1=1&value2=2");
            request.Headers.Add("Authorization", apiKey);
            var response = _client.SendAsync(request).Result;

            var calcResult = await response.Content.ReadAsStringAsync();

            response.StatusCode.Should().Be(HttpStatusCode.OK);
            calcResult.Should().Be("0.5");
        }

        [Fact]
        [Trait("Calculator", "LoginControllerTests")]
        public async Task ReturnUnauthorizedIfIncorrectApiKeyPassed()
        {
            var request = new HttpRequestMessage(HttpMethod.Get, "/api/operation/sum?value1=1&value2=1");
            request.Headers.Add("Authorization", "1234");
            var response = _client.SendAsync(request).Result;

            response.StatusCode.Should().Be(HttpStatusCode.Unauthorized);
        }

        [Fact]
        [Trait("Calculator", "LoginControllerTests")]
        public async Task ReturnUnauthorizedIfNoApiKeyPassed()
        {
            var request = new HttpRequestMessage(HttpMethod.Get, "/api/operation/sum?value1=1&value2=1");
            var response = _client.SendAsync(request).Result;

            response.StatusCode.Should().Be(HttpStatusCode.Unauthorized);
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (_disposed)
                return;

            if (disposing)
            {
                _client?.Dispose();
                _factory?.Dispose();
            }

            _disposed = true;
        }
    }
}
