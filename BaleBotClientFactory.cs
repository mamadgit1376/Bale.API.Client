using Bale.API.Client.Interface;
using Bale.API.Client.Models;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Bale.API.Client
{
    /// <summary>
    /// پیاده‌سازی کارخانه ساخت کلاینت‌های ربات بله.
    /// </summary>
    public class BaleBotClientFactory : IBaleBotClientFactory
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public BaleBotClientFactory(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        /// <summary>
        /// یک نمونه جدید از کلاینت ربات بله را با توکن دلخواه می‌سازد.
        /// </summary>
        public IBaleBotClient CreateClient(string botToken)
        {
            // ۱. یک HttpClient از استخر (pool) دریافت می‌کنیم.
            var httpClient = _httpClientFactory.CreateClient();
            httpClient.BaseAddress = new Uri("https://tapi.bale.ai/");

            // ۲. تنظیمات (Options) را به صورت دستی با توکن ورودی می‌سازیم.
            var options = Options.Create(new BaleBotClientOptions { BotToken = botToken });

            // ۳. یک نمونه جدید از BaleBotClient با HttpClient و تنظیمات ساخته شده ایجاد می‌کنیم.
            // چون در اینجا لاگر نداریم، null پاس می‌دهیم.
            return new BaleBotClient(httpClient, options);
        }
    }
}
