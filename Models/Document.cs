using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Bale.API.Client.Models
{
    /// <summary>
    /// این شی به طور کلی نشان‌دهنده یک فایل است.
    /// </summary>
    public class Document
    {
        [JsonPropertyName("file_id")]
        public string FileId { get; set; } = string.Empty;

        [JsonPropertyName("file_unique_id")]
        public string FileUniqueId { get; set; } = string.Empty;

        /// <summary>
        /// (اختیاری) تصویر بندانگشتی (thumbnail) سند.
        /// </summary>
        [JsonPropertyName("thumbnail")]
        public PhotoSize? Thumbnail { get; set; }

        /// <summary>
        /// (اختیاری) نام اصلی فایل.
        /// </summary>
        [JsonPropertyName("file_name")]
        public string? FileName { get; set; }

        /// <summary>
        /// (اختیاری) نوع MIME فایل.
        /// </summary>
        [JsonPropertyName("mime_type")]
        public string? MimeType { get; set; }

        /// <summary>
        /// (اختیاری) حجم فایل به بایت.
        /// </summary>
        [JsonPropertyName("file_size")]
        public long? FileSize { get; set; }
    }
}
