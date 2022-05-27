using Azure.Core;
using Azure.Identity;
using Azure.Security.KeyVault.Secrets;

namespace Calculator.API.Configurations
{
    public class ApiKeyService : IApiKeyService
    {
        private string? username;
        private string? password;
        private string? apikey;

        public SecretClient Client { get; set; }

        public ApiKeyService()
        {
            var options = new SecretClientOptions()
            {
                Retry =
                {
                    Delay = TimeSpan.FromSeconds(2),
                    MaxDelay = TimeSpan.FromSeconds(16),
                    MaxRetries = 5,
                    Mode = RetryMode.Exponential
                 }
            };

            Client = new SecretClient(new Uri("https://calculatorkv.vault.azure.net/"), new DefaultAzureCredential(), options);
        }

        public string GetApiKey()
        {
            if(string.IsNullOrEmpty(apikey))
            {
                KeyVaultSecret secret = Client.GetSecret("Token");
                apikey = secret.Value;
            }

            return apikey;
        }

        public string GetUsername()
        {
            if (string.IsNullOrEmpty(username))
            {
                KeyVaultSecret user = Client.GetSecret("username");
                username = user.Value;
            }

            return username;
        }

        public string GetPassword()
        {
            if (string.IsNullOrEmpty(password))
            {
                KeyVaultSecret pass = Client.GetSecret("password");
                password = pass.Value;
            }

            return password;
        }
    }
}