using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Bale.API.Client.Models
{
    /// <summary>
    /// این شیء نمایانگر یک بخش خاص از متن پیام است؛ مانند نام کاربری، لینک، دستور و غیره.
    /// </summary>
    public class MessageEntity
    {
        /// <summary>
        /// نوع بخش خاص. می‌تواند یکی از مقادیر "mention", "hashtag", "cashtag", "bot_command", "url", "email", "phone_number", "bold", "italic", "underline", "strikethrough", "code", "pre" باشد.
        /// </summary>
        [JsonPropertyName("type")]
        public string Type { get; set; } = string.Empty;

        /// <summary>
        /// موقعیت شروع بخش مورد نظر در متن پیام (بر حسب واحدهای UTF-16).
        /// </summary>
        [JsonPropertyName("offset")]
        public int Offset { get; set; }

        /// <summary>
        /// طول بخش مورد نظر در متن پیام (بر حسب واحدهای UTF-16).
        /// </summary>
        [JsonPropertyName("length")]
        public int Length { get; set; }
    }
}
