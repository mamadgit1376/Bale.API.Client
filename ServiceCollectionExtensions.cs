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
        /// <summary>
        /// سرویس کلاینت ربات بله را به همراه HttpClient پیکربندی شده ثبت می‌کند.
        /// </summary>
        public static IServiceCollection AddBaleBotClient(this IServiceCollection services, Action<BaleBotClientOptions> configureOptions)
        {
            // ۱. ثبت تنظیمات کاربر
            services.Configure(configureOptions);

            // ۲. ثبت HttpClient و پیکربندی آن با استفاده از تنظیمات ثبت شده
            services.AddHttpClient<IBaleBotClient, BaleBotClient>((serviceProvider, client) =>
            {
                // دریافت تنظیمات از سیستم تزریق وابستگی
                var options = serviceProvider.GetRequiredService<IOptions<BaleBotClientOptions>>().Value;

                // اطمینان از اینکه توکن و آدرس پایه معتبر هستند
                if (string.IsNullOrEmpty(options.BotToken))
                    throw new ArgumentNullException(nameof(options.BotToken), "BotToken cannot be empty.");

                if (!Uri.TryCreate(options.BaseUrl, UriKind.Absolute, out var baseUri))
                    throw new ArgumentException("The provided BaseUrl is not a valid absolute URI.", nameof(options.BaseUrl));

                // 🔥 تنظیم BaseAddress از طریق تنظیمات کاربر
                client.BaseAddress = baseUri;
            });

            return services;
        }
    }
}
