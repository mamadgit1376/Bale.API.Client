using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Bale.API.Client.Models
{
    /// <summary>
    /// این شی نشان‌دهنده تصویر پروفایل یک گفتگو است.
    /// </summary>
    public class ChatPhoto
    {
        /// <summary>
        /// شناسه فایل برای تصویر کوچک (۱۶۰×۱۶۰).
        /// </summary>
        [JsonPropertyName("small_file_id")]
        public string SmallFileId { get; set; } = string.Empty;

        /// <summary>
        /// شناسه یکتای فایل برای تصویر کوچک.
        /// </summary>
        [JsonPropertyName("small_file_unique_id")]
        public string SmallFileUniqueId { get; set; } = string.Empty;

        /// <summary>
        /// شناسه فایل برای تصویر بزرگ (۶۴۰×۶۴۰).
        /// </summary>
        [JsonPropertyName("big_file_id")]
        public string BigFileId { get; set; } = string.Empty;

        /// <summary>
        /// شناسه یکتای فایل برای تصویر بزرگ.
        /// </summary>
        [JsonPropertyName("big_file_unique_id")]
        public string BigFileUniqueId { get; set; } = string.Empty;
    }
}
