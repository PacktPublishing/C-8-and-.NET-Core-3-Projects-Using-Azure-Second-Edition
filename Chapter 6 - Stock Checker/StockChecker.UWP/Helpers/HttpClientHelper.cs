using IdentityModel.Client;
using StockChecker.UWP.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace StockChecker.UWP.Helpers
{
    public class HttpClientHelper : IHttpStockClientHelper
    {
        static HttpClient _httpClient;
        private string _accessToken;

        public HttpClientHelper(Uri baseAddress)
        {
            _httpClient = new HttpClient();
            _httpClient.BaseAddress = baseAddress;
        }

        public async Task<int> GetQuantityAsync(int productId)
        {
            string path = $"api/stock/{productId}";

            string quantityString = await _httpClient.GetStringAsync(path);

            return int.Parse(quantityString);
        }

        public async Task UpdateQuantityAsync(int productId, int newQuantity)
        {
            string path = $"api/stock/{productId}";

            var httpContent = new StringContent(newQuantity.ToString());
            httpContent.Headers.ContentType = new MediaTypeHeaderValue("application/json");
            
            await _httpClient.PutAsync(path, httpContent);
        }

        public async Task<bool> Login(string username, string password)
        {            
            var disco = await _httpClient.GetDiscoveryDocumentAsync(new DiscoveryDocumentRequest
            {
                Address = "https://localhost:5001",               
                Policy =
                {                    
                    ValidateIssuerName = false,                                        
                }                
            });

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

            _accessToken = response.AccessToken;
            return true;
        }
    }
}
