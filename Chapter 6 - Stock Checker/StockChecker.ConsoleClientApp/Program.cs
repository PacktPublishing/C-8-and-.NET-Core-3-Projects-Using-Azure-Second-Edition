using IdentityModel.Client;
using Newtonsoft.Json.Linq;
using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace StockChecker.ConsoleClientApp
{
    class Program
    {
        static HttpClient _httpClient;

        static async Task Main(string[] args)
        {
            _httpClient = new HttpClient();

            var success = await Login("Lucy", "password123");

            Console.ReadLine();
        }

        private static async Task<bool> Login(string username, string password)
        {
            var disco = await _httpClient.GetDiscoveryDocumentAsync(new DiscoveryDocumentRequest
            {
                Address = "https://localhost:5001",
                Policy =
                {
                    ValidateIssuerName = false,
                }
            });

            Console.WriteLine($"Endpoint: {disco.TokenEndpoint}");

            var response = await _httpClient.RequestPasswordTokenAsync(new PasswordTokenRequest
            {
                Address = disco.TokenEndpoint,
                ClientId = "StockChecker",
                ClientSecret = "secret",
                Scope = "StockCheckerApi",

                UserName = username,
                Password = password
            });

            if (response.IsError)
            {
                // ToDo: Log error
                return false;
            }

            Console.WriteLine($"Access Token: {response.AccessToken}");

            return true;
        }

    }
}