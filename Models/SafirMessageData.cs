using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

namespace Bale.API.Client.Models
{
    public class SafirMessageData
    {
        /// <summary>
        /// مدل پیام اختیاری
        /// </summary>
        public SafirMessage? message { get; set; }
        /// <summary>
        /// مدل otp اختیاری
        /// </summary>
        [JsonPropertyName("otp_message")]
        public SafirOTPMessage? OTPMessage { get; set; }
        /// <summary>
        /// پیام امن ارسال بشه ؟
        /// </summary>
        public bool is_secure {get; set; } = false;
    }
}
