namespace Calculator.API.Validators
{
    public class Validation : IValidation
    {
        public virtual bool Validate(string num1, string num2)
        {
            if(string.IsNullOrEmpty(num1))
                throw new FormatException("First number is empty, try again !");

            if (string.IsNullOrEmpty(num2))
                throw new FormatException("Second number empty, try again !");

            return true;
        }
    }
}