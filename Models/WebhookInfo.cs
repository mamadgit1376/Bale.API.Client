using System.Text.Json.Serialization;

namespace Bale.API.Client.Models
{
    /// <summary>
    /// وضعیت فعلی یک وب‌هوک را نمایش می‌دهد.
    /// </summary>
    public class WebhookInfo
    {
        /// <summary>
        /// آدرس URL وب‌هوک. اگر وب‌هوک تنظیم نشده باشد، این فیلد خالی خواهد بود.
        /// </summary>
        [JsonPropertyName("url")]
        public string Url { get; set; } = string.Empty;
    }
}
