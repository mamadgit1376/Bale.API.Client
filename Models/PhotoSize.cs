using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Bale.API.Client.Models
{
    /// <summary>
    /// این شی یک اندازه از تصویر یا یک تصویر بندانگشتی (thumbnail) را نشان می‌دهد.
    /// </summary>
    public class PhotoSize
    {
        /// <summary>
        /// شناسه فایل که برای دانلود یا استفاده مجدد به کار می‌رود.
        /// </summary>
        [JsonPropertyName("file_id")]
        public string FileId { get; set; } = string.Empty;

        /// <summary>
        /// شناسه یکتای فایل که در تمام بازوها یکسان است.
        /// </summary>
        [JsonPropertyName("file_unique_id")]
        public string FileUniqueId { get; set; } = string.Empty;

        /// <summary>
        /// عرض تصویر.
        /// </summary>
        [JsonPropertyName("width")]
        public int Width { get; set; }

        /// <summary>
        /// ارتفاع تصویر.
        /// </summary>
        [JsonPropertyName("height")]
        public int Height { get; set; }

        /// <summary>
        /// (اختیاری) حجم فایل به بایت.
        /// </summary>
        [JsonPropertyName("file_size")]
        public int? FileSize { get; set; }
    }
}
