using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Bale.API.Client.Models
{
    /// <summary>
    /// این شی نشان‌دهنده یک فایل صوتی (موسیقی) است.
    /// </summary>
    public class Audio
    {
        [JsonPropertyName("file_id")]
        public string FileId { get; set; } = string.Empty;

        [JsonPropertyName("file_unique_id")]
        public string FileUniqueId { get; set; } = string.Empty;

        /// <summary>
        /// مدت زمان فایل صوتی به ثانیه.
        /// </summary>
        [JsonPropertyName("duration")]
        public int Duration { get; set; }

        /// <summary>
        /// (اختیاری) عنوان فایل صوتی.
        /// </summary>
        [JsonPropertyName("title")]
        public string? Title { get; set; }

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
        public long? FileSize { get; set; } // از long استفاده می‌کنیم چون ممکن است بزرگ باشد
    }
}
