using Calculator.API.Validators;

namespace Calculator.API.Services
{
    public class OperationsService : IOperationsService
    {
        private decimal _value1;
        private decimal _value2;
        private readonly IValidation _validate;

        public OperationsService()
        {
            _validate = new Validation();
        }

        public async Task<decimal> Sum(string num1, string num2)
        {
            ConvertToDecimal(num1, num2);
            return await Task.FromResult(_value1 + _value2);
        }

        public async Task<decimal> Subtract(string num1, string num2)
        {
            ConvertToDecimal(num1, num2);
            return await Task.FromResult(_value1 - _value2);
        }

        public async Task<decimal> Multiply(string num1, string num2)
        {
            ConvertToDecimal(num1, num2);
            return await Task.FromResult(_value1 * _value2);
        }

        public async Task<decimal> Divide(string num1, string num2)
        {
            ConvertToDecimal(num1, num2);

            if(_value1 == 0)
                throw new DivideByZeroException();

            return await Task.FromResult(_value1 / _value2);
        }

        private void ConvertToDecimal(string value1, string value2)
        {
            if (_validate.Validate(value1, value2))
            {
                _value1 = Convert.ToDecimal(value1);
                _value2 = Convert.ToDecimal(value2);
            }
        }
    }
}