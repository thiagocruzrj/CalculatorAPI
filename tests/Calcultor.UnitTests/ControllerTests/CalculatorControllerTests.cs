using Calculator.API.Controllers.V1;
using Calculator.API.Services;
using Microsoft.AspNetCore.Mvc;

namespace Calculator.UnitTests.ControllerTests
{
    public class CalculatorControllerTests
    {
        CalculatorController _controller;
        IOperationsService _service;

        public CalculatorControllerTests()
        {
            _service = new OperationsService();
            _controller = new CalculatorController(_service);
        }

        [Theory]
        [InlineData("1", "2")]
        [InlineData("10", "20")]
        [InlineData("100", "200")]
        [Trait("Calculator", "ApiTests")]
        public void Calculator_SumOperator_ResultOk(string num1, string num2)
        {
            //Act
            var OkResponse = _controller.Add(num1, num2);
            //Assert
            Assert.IsType<OkObjectResult>(OkResponse.Result);
        }

        [Theory]
        [InlineData("1", "2")]
        [InlineData("10", "20")]
        [InlineData("100", "200")]
        [Trait("Calculator", "ApiTests")]
        public void Calculator_SubtractOperator_ResultOk(string num1, string num2)
        {
            //Act
            var OkResponse = _controller.Subtract(num1, num2);

            //Assert
            Assert.IsType<OkObjectResult>(OkResponse.Result);
        }

        [Theory]
        [InlineData("1", "2")]
        [InlineData("10", "20")]
        [InlineData("100", "200")]
        [Trait("Calculator", "ApiTests")]
        public void Calculator_Multiplyperator_ResultOk(string num1, string num2)
        {
            //Act
            var OkResponse = _controller.Multiply(num1, num2);

            //Assert
            Assert.IsType<OkObjectResult>(OkResponse.Result);
        }


        [Theory]
        [InlineData("1", "2")]
        [InlineData("10", "20")]
        [InlineData("100", "200")]
        [Trait("Calculator", "ApiTests")]
        public void Calculator_DivideOperator_ResultOk(string num1, string num2)
        {
            //Act
            var OkResponse = _controller.Divide(num1, num2);

            //Assert
            Assert.IsType<OkObjectResult>(OkResponse.Result);
        }
    }
}