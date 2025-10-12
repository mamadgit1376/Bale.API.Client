using Bale.API.Client.Interface;
using Bale.API.Client.Models;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bale.API.Client
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddBaleBotClient(this IServiceCollection services, Action<BaleBotClientOptions> configureOptions)
        {
            // 1. Register the options from user configuration
            services.Configure(configureOptions);

            // 2. Ensure IHttpClientFactory is available
            services.AddHttpClient();

            // 3. Register your client service
            services.AddScoped<IBaleBotClient, BaleBotClient>();

            return services;
        }
    }
}
