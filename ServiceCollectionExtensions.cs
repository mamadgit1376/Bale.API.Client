using Bale.API.Client.Interface;
using Bale.API.Client.Models;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bale.API.Client
{
    public static class ServiceCollectionExtensions
    {
        /// <summary>
        /// سرویس کلاینت ربات بله را به همراه HttpClient پیکربندی شده ثبت می‌کند.
        /// </summary>
        public static IServiceCollection AddBaleBotClient(this IServiceCollection services, Action<BaleBotClientOptions> configureOptions)
        {
            // ثبت تنظیمات
            services.Configure(configureOptions);

            // ثبت HttpClient با BaseAddress و ثبت سرویس اصلی
            services.AddHttpClient<IBaleBotClient, BaleBotClient>((serviceProvider, client) =>
            {
                client.BaseAddress = new Uri("https://tapi.bale.ai/");
            });

            return services;
        }
    }
}
