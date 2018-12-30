using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks;
using IdentityServer4.Models;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;

namespace StockChecker.IdentityServer
{
    public class Startup
    {
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            X509Certificate2 x509Certificate2 = null;
            using (var certStore = new X509Store(StoreName.My, StoreLocation.CurrentUser))
            {
                certStore.Open(OpenFlags.ReadOnly);
                var certCollection = certStore.Certificates.Find(
                    X509FindType.FindByThumbprint,
                    "CED666617B2C3E4C244B38EC3BB322191148EA92",
                    false);

                if (certCollection.Count == 0)
                    throw new Exception("No certificate found");

                x509Certificate2 = certCollection[0];
            }

            services
                .AddIdentityServer()
                //.AddDeveloperSigningCredential()
                .AddSigningCredential(x509Certificate2)
                .AddInMemoryClients(IdentityServerHelper.GetClients())
                .AddInMemoryApiResources(IdentityServerHelper.GetApiResources())
                .AddTestUsers(IdentityServerHelper.GetUsers())
                .AddInMemoryIdentityResources(new List<IdentityResource>());
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseIdentityServer();
        }
    }
}
