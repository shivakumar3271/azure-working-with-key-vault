using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Azure.KeyVault;
using Microsoft.Azure.KeyVault.Models;
using Microsoft.Azure.Services.AppAuthentication;

namespace WorkingWithAzureKeyVault
{
    class Program
    {
        static void Main(string[] args)
        {
            Program.GetSecretKey().GetAwaiter().GetResult();
        }
        public static async Task GetSecretKey()
        {
            string secretKey = "";
            
            try
            {
                Console.WriteLine("Fetching Secret from Azure Key Vault");
                Console.WriteLine("Demo by Avinash Seth <avinash.seth@outlook.com>");
                AzureServiceTokenProvider azureServiceTokenProvider = new AzureServiceTokenProvider();
                KeyVaultClient keyVaultClient = new KeyVaultClient(new KeyVaultClient.AuthenticationCallback(azureServiceTokenProvider.KeyVaultTokenCallback));
                var secret = await keyVaultClient.GetSecretAsync("https://<vault_name>.vault.azure.net/secrets/<key>/<token>")
                        .ConfigureAwait(false);
                secretKey = secret.Value;
                Console.WriteLine(secretKey);
                Console.ReadKey();
            }
            catch (KeyVaultErrorException keyVaultException)
            {
                
            }
        }
    }
}
