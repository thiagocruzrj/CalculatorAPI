namespace Calculator.API.Configurations
{
    public interface IApiKeyService
    {
        public string GetApiKey();
        public string GetUsername();
        public string GetPassword();
    }
}