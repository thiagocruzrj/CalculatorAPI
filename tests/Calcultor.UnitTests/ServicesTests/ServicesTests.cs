using Calculator.API.Services;
using Calculator.API.Validators;

namespace Calculator.UnitTests.ServicesTests
{
    public class ServicesTests
    {
        IValidation _validation;

        public ServicesTests()
        {
            _validation = new Validation();
        }

        [Theory(DisplayName = "Validating null or empty expression throw exception")]
        [InlineData("","")]
        [InlineData(null, null)]
        [InlineData(null, "")]
        [InlineData("", null)]
        [Trait("Calculator", "ToolsTests")]
        public void Calculator_UsingValidation_ShouldThrowFormatException(string num1, string num2)
        {
            Assert.Throws<FormatException>(() => _validation.Validate(num1, num2));
        }
    }
}