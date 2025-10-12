using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Bale.API.Client.Models
{
    /// <summary>
    /// این شی یک کیبورد شیشه‌ای (Inline Keyboard) را نشان می‌دهد.
    /// </summary>
    public class InlineKeyboardMarkup
    {
        /// <summary>
        /// آرایه‌ای از ردیف‌های دکمه‌ها. هر ردیف خود یک آرایه از InlineKeyboardButton است.
        /// </summary>
        [JsonPropertyName("inline_keyboard")]
        public InlineKeyboardButton[][] InlineKeyboard { get; set; } = null!;
    }
}
