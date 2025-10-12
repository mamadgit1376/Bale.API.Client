using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Bale.API.Client.Models
{
    /// <summary>
    /// این شی یک کیبورد سفارشی را نشان می‌دهد.
    /// </summary>
    public class ReplyKeyboardMarkup
    {
        /// <summary>
        /// آرایه‌ای از ردیف‌های دکمه‌ها. هر ردیف خود یک آرایه از KeyboardButton است.
        /// </summary>
        [JsonPropertyName("keyboard")]
        public KeyboardButton[][] Keyboard { get; set; } = null!;
    }
}
