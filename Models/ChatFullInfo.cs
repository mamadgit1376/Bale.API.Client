using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Bale.API.Client.Models
{
    /// <summary>
    /// این شی حاوی اطلاعات کامل یک گفتگو است و از کلاس Chat ارث‌بری می‌کند.
    /// </summary>
    public class ChatFullInfo : Chat
    {
        /// <summary>
        /// (اختیاری) تصویر پروفایل گفتگو.
        /// </summary>
        [JsonPropertyName("photo")]
        public ChatPhoto? Photo { get; set; }

        /// <summary>
        /// (اختیاری) متن بخش "درباره من" (Bio) برای کاربران.
        /// </summary>
        [JsonPropertyName("bio")]
        public string? Bio { get; set; }

        /// <summary>
        /// (اختیاری) توضیحات برای گروه‌ها و کانال‌ها.
        /// </summary>
        [JsonPropertyName("description")]
        public string? Description { get; set; }

        /// <summary>
        /// (اختیاری) لینک دعوت به گروه یا کانال.
        /// </summary>
        [JsonPropertyName("invite_link")]
        public string? InviteLink { get; set; }
    }
}
