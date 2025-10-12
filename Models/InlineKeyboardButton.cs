using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Bale.API.Client.Models
{
    /// <summary>
    /// یک دکمه از کیبورد شیشه‌ای (Inline Keyboard) را نشان می‌دهد.
    /// </summary>
    public class InlineKeyboardButton
    {
        /// <summary>
        /// متن روی دکمه.
        /// </summary>
        [JsonPropertyName("text")]
        public string Text { get; set; } = string.Empty;

        /// <summary>
        /// (اختیاری) آدرسی که با کلیک روی دکمه باز می‌شود.
        /// </summary>
        [JsonPropertyName("url")]
        public string? Url { get; set; }

        /// <summary>
        /// (اختیاری) داده‌ای که با کلیک روی دکمه به ربات شما ارسال می‌شود (Callback).
        /// </summary>
        [JsonPropertyName("callback_data")]
        public string? CallbackData { get; set; }
    }
}
