using IdentityModel;
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
        static string _accessToken;
        static DiscoveryResponse _discoveryResponse;

        public HttpClientHelper(Uri baseAddress)
        {
            _httpClient = new HttpClient();
            _httpClient.BaseAddress = baseAddress;
        }

        public async Task<int?> GetQuantityAsync(int productId)
        {
            string path = $"api/stock/{productId}";

            _httpClient.SetBearerToken(_accessToken);            
            var response = await _httpClient.GetAsync(path);
            if (response.IsSuccessStatusCode)
            {
                string quantityString = await response.Content.ReadAsStringAsync();
                return int.Parse(quantityString);
            }
            return null;
        }

        public async Task UpdateQuantityAsync(int productId, int newQuantity)
        {
            string path = $"api/stock/{productId}";

            _httpClient.SetBearerToken(_accessToken);
            var httpContent = new StringContent(newQuantity.ToString());
            httpContent.Headers.ContentType = new MediaTypeHeaderValue("application/json");
            
            await _httpClient.PutAsync(path, httpContent);
        }

        public async Task<bool> Login(string username, string password)
        {            
            _discoveryResponse = await _httpClient.GetDiscoveryDocumentAsync(new DiscoveryDocumentRequest
            {
                Address = "https://localhost:5001",               
                Policy =
                {                    
                    ValidateIssuerName = false,
                }                
            });

            var response = await _httpClient.RequestPasswordTokenAsync(new PasswordTokenRequest
            {
                Address = _discoveryResponse.TokenEndpoint,
                ClientId = "StockChecker",
                ClientSecret = "secret",
                Scope = "openid roles StockCheckerApi",

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

        public async Task<string> GetUserRole()
        {
            var userInfo = await _httpClient.GetUserInfoAsync(new UserInfoRequest()
            {
                Address = _discoveryResponse.UserInfoEndpoint,
                Token = _accessToken
            });

            string role = userInfo.Claims.First(a => a.Type == JwtClaimTypes.Role).Value;
            return role;
        }
    }
}
