using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

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
