using Bale.API.Client.Interface;
using Bale.API.Client.Models;
using Microsoft.Extensions.Options;
using System.Net.Http;

namespace Bale.API.Client.Factories
{
    public class BaleBotClientFactory : IBaleBotClientFactory
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public BaleBotClientFactory(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public IBaleBotClient CreateClient(string botToken)
        {
            var options = Options.Create(new BaleBotClientOptions { BotToken = botToken });

            // 🔥 تغییر اصلی: به جای ساخت HttpClient، خودِ فکتوری را به سازنده پاس می‌دهیم
            return new BaleBotClient(_httpClientFactory, options);
        }
    }
}