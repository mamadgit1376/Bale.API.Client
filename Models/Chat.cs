using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Bale.API.Client.Models
{
    /// <summary>
    /// این شی نشان‌دهنده یک گفتگو است.
    /// </summary>
    public class Chat
    {
        /// <summary>
        /// شناسه یکتای گفتگو.
        /// </summary>
        [JsonPropertyName("id")]
        public long Id { get; set; }

        /// <summary>
        /// نوع گفتگو که می‌تواند 'private', 'group' یا 'channel' باشد.
        /// </summary>
        [JsonPropertyName("type")]
        public string Type { get; set; } = string.Empty;

        /// <summary>
        /// (اختیاری) عنوان برای گروه‌ها و کانال‌ها.
        /// </summary>
        [JsonPropertyName("title")]
        public string? Title { get; set; }

        /// <summary>
        /// (اختیاری) نام کاربری برای چت‌های خصوصی، گروه‌ها و کانال‌ها.
        /// </summary>
        [JsonPropertyName("username")]
        public string? Username { get; set; }

        /// <summary>
        /// (اختیاری) نام کوچک طرف مقابل در یک گفتگوی خصوصی.
        /// </summary>
        [JsonPropertyName("first_name")]
        public string? FirstName { get; set; }

        /// <summary>
        /// (اختیاری) نام خانوادگی طرف مقابل در یک گفتگوی خصوصی.
        /// </summary>
        [JsonPropertyName("last_name")]
        public string? LastName { get; set; }
    }
}
