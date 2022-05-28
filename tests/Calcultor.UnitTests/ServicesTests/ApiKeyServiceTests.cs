using Calculator.API.Configurations;
using FluentAssertions;

namespace Calculator.UnitTests.ServicesTests
{
    public class ApiKeyServiceTests
    {
        IApiKeyService _service;

        public ApiKeyServiceTests()
        {
            _service = new ApiKeyService();
        }

        [Fact]
        [Trait("Calculator", "ApiKeyServiceTests")]
        public void Calculator_UsingGetApiKey_ShouldReturnToken()
        {
            var result = _service.GetApiKey();
            result.Should().Be("secretkeyforcalculatorapi");
        }

        [Fact]
        [Trait("Calculator", "ApiKeyServiceTests")]
        public void Calculator_UsingGetApiKey_ShouldReturnUsername()
        {
            var result = _service.GetUsername();
            result.Should().Be("flyuser");
        }

        [Fact]
        [Trait("Calculator", "ApiKeyServiceTests")]
        public void Calculator_UsingGetApiKey_ShouldReturnPassword()
        {
            var result = _service.GetPassword();
            result.Should().Be("b6t1erf1y");
        }
    }
}