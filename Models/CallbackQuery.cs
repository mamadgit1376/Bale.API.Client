using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Bale.API.Client.Models
{
    /// <summary>
    /// نشان‌دهنده یک درخواست بازگشتی (Callback) از یک دکمه شیشه‌ای است.
    /// </summary>
    public class CallbackQuery
    {
        /// <summary>
        /// شناسه یکتای این درخواست.
        /// </summary>
        [JsonPropertyName("id")]
        public string Id { get; set; } = string.Empty;

        /// <summary>
        /// کاربری که روی دکمه کلیک کرده است.
        /// </summary>
        [JsonPropertyName("from")]
        public User From { get; set; } = null!;

        /// <summary>
        /// (اختیاری) پیامی که دکمه به آن متصل بوده است.
        /// </summary>
        [JsonPropertyName("message")]
        public Message? Message { get; set; }

        /// <summary>
        /// (اختیاری) داده‌ای که هنگام تعریف دکمه در فیلد callback_data قرار داده شده بود.
        /// </summary>
        [JsonPropertyName("data")]
        public string? Data { get; set; }
    }
}
