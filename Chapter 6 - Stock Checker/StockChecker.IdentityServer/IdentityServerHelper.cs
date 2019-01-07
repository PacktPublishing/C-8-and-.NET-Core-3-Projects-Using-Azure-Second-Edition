using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using IdentityModel;
using IdentityServer4;
using IdentityServer4.Models;
using IdentityServer4.Test;

namespace StockChecker.IdentityServer
{
    public class IdentityServerHelper
    {
        internal static IEnumerable<Client> GetClients()
        {
            var clients = new List<Client>
            {
                new Client
                {
                    ClientId = "StockChecker",                    
                    AllowedGrantTypes = GrantTypes.ResourceOwnerPassword,                    
                    ClientSecrets =
                    {
                        new Secret("secret".Sha256())
                    },
                    AllowedScopes =
                    {
                        "StockCheckerApi",
                        "roles",
                        IdentityServerConstants.StandardScopes.OpenId
                    }
                    
                }
            };

            return clients;
        }

        internal static IEnumerable<ApiResource> GetApiResources()
        {
            var resources = new List<ApiResource>
            {
                new ApiResource("StockCheckerApi", "Stock Checker API")
            };

            return resources;
        }

        internal static List<TestUser> GetUsers()
        {
            var users = new List<TestUser>
            {
                new TestUser
                {
                    SubjectId = "1",
                    Username = "Lucy",
                    Password = "password123",
                    Claims = new List<Claim>()
                    {
                        new Claim(JwtClaimTypes.Role, "Sales")
                    }
                },
                new TestUser
                {
                    SubjectId = "2",
                    Username = "Morris",
                    Password = "password123",
                    Claims = new List<Claim>()
                    {
                        new Claim(JwtClaimTypes.Role, "Maintenance")
                    }
                },
                new TestUser
                {                    
                    SubjectId = "3",
                    Username = "Graham",
                    Password = "password123",
                    Claims = new List<Claim>()
                    {
                        new Claim(JwtClaimTypes.Role, "Administrator")
                    }
                }
            };

            return users;
        }

        internal static IEnumerable<IdentityResource> GetIdentityResources()
        {
            return new List<IdentityResource>
            {
                new IdentityResource
                {
                    Name = "roles",
                    UserClaims = new List<string> { JwtClaimTypes.Role }                    
                },
                new IdentityResources.OpenId()
            };
        }
    }
}
