using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Bale.API.Client.Models
{
    /// <summary>
    /// این شی نشان‌دهنده یک کاربر بله یا یک بازو است.
    /// </summary>
    public class User
    {
        /// <summary>
        /// شناسه یکتای کاربر یا بازو.
        /// </summary>
        [JsonPropertyName("id")]
        public long Id { get; set; }

        /// <summary>
        /// اگر این کاربر یک بازو (ربات) باشد، true است.
        /// </summary>
        [JsonPropertyName("is_bot")]
        public bool IsBot { get; set; }

        /// <summary>
        /// نام کوچک کاربر یا بازو.
        /// </summary>
        [JsonPropertyName("first_name")]
        public string FirstName { get; set; } = string.Empty;

        /// <summary>
        /// (اختیاری) نام خانوادگی کاربر یا بازو.
        /// </summary>
        [JsonPropertyName("last_name")]
        public string? LastName { get; set; }

        /// <summary>
        /// (اختیاری) نام کاربری (username) کاربر یا بازو.
        /// </summary>
        [JsonPropertyName("username")]
        public string? Username { get; set; }
    }
}
