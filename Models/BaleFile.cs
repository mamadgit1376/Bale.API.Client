using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Bale.API.Client.Models
{
    /// <summary>
    /// این شی نشان‌دهنده یک فایل آماده برای دانلود است.
    /// نام آن به BaleFile تغییر کرده تا با کلاس سیستمی System.IO.File تداخل نداشته باشد.
    /// </summary>
    public class BaleFile
    {
        /// <summary>
        /// شناسه فایل که می‌توان برای دانلود یا استفاده مجدد از آن استفاده کرد.
        /// </summary>
        [JsonPropertyName("file_id")]
        public string FileId { get; set; } = string.Empty;

        /// <summary>
        /// شناسه یکتای فایل که در تمام بازوها یکسان است.
        /// </summary>
        [JsonPropertyName("file_unique_id")]
        public string FileUniqueId { get; set; } = string.Empty;

        /// <summary>
        /// (اختیاری) حجم فایل به بایت.
        /// </summary>
        [JsonPropertyName("file_size")]
        public long? FileSize { get; set; }

        /// <summary>
        /// (اختیاری) مسیر فایل برای دانلود از طریق API.
        /// </summary>
        [JsonPropertyName("file_path")]
        public string? FilePath { get; set; }
    }
}
