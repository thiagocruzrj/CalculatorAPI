namespace Calculator.API.Services
{
    public interface IOperationsService
    {
        Task<decimal> Sum(string num1, string num2);
        Task<decimal> Subtract(string num1, string num2);
        Task<decimal> Multiply(string num1, string num2);
        Task<decimal> Divide(string num1, string num2);
    }
}