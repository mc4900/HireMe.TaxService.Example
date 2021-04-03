using HireMe.Infrastructure.Mapper;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Net.Http.Headers;


namespace HireMe.Infrastructure
{
    public class Startup
    {
        //urls should be pulled from appsettings.json file. Bearer Token should be implemented in a more secure way using something like an identity server or azure key vault.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddHttpClient("TaxJarApi", client =>
            {
                client.BaseAddress = new Uri("https://api.taxjar.com/v2");
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Add("Accept", "application/json");
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", "5da2f821eee4035db4771edab942a4cc"); //**need to move api key to configs
            });
            services.AddScoped<IEntityMapper, EntityMapper>();
        }

    }
}
