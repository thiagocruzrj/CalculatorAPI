using Calculator.API.Services;
using Calculator.API.Validators;

namespace Calculator.UnitTests.ServicesTests
{
    public class ServicesTests
    {
        IOperationsService _service;
        IValidation _validation;

        public ServicesTests()
        {
            _service = new OperationsService();
            _validation = new Validation();
        }

        [Theory(DisplayName = "Validating null or empty expression throw exception")]
        [InlineData("","")]
        [InlineData(null, null)]
        [InlineData(null, "")]
        [InlineData("", null)]
        [InlineData("3", "")]
        [Trait("Calculator", "ServiceTests")]
        public void Calculator_UsingValidation_ShouldThrowFormatException(string num1, string num2)
        {
            Assert.Throws<FormatException>(() => _validation.Validate(num1, num2));
        }

        [Fact]
        [Trait("Calculator", "ServiceTests")]
        public async Task Calculator_DivideOperatorByZero_ShouldThrowDivideByZeroException()
        {
            //Assert
            await Assert.ThrowsAsync<DivideByZeroException>(async () => await _service.Divide("0", "3"));
        }
    }
}