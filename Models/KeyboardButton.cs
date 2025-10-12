using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Bale.API.Client.Models
{
    /// <summary>
    /// این شی نشان‌دهنده یک دکمه از کیبورد سفارشی (Reply Keyboard) است.
    /// </summary>
    public class KeyboardButton
    {
        /// <summary>
        /// متن دکمه. این متن در صورت کلیک به عنوان پیام ارسال خواهد شد.
        /// </summary>
        [JsonPropertyName("text")]
        public string Text { get; set; } = string.Empty;

        /// <summary>
        /// (اختیاری) اگر true باشد، شماره تماس کاربر در صورت کلیک درخواست می‌شود.
        /// </summary>
        [JsonPropertyName("request_contact")]
        public bool? RequestContact { get; set; }

        /// <summary>
        /// (اختیاری) اگر true باشد، موقعیت مکانی کاربر در صورت کلیک درخواست می‌شود.
        /// </summary>
        [JsonPropertyName("request_location")]
        public bool? RequestLocation { get; set; }
    }
}
