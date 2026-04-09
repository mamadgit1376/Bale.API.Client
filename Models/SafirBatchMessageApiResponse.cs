using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

namespace Bale.API.Client.Models
{
    public class SafirBatchMessageApiResponse
    {
        /// <summary>
        /// این لیست شامل آبجکت‌هایی است که هر کدام یک دیکشنری از شناسه پیام‌ها را نگه می‌دارند.
        /// در الگوی JSON ورودی شما، response یک آرایه از آبجکت‌هاست که هر کدام یک خاصیت phone_message_id دارند.
        /// </summary>
        [JsonPropertyName("response")]
        public List<ResponseItem> Response { get; set; } = new List<ResponseItem>();
        [JsonPropertyName("error_data")]

        public List<SafirErrorInfo>? ErrorData { get; set; } = null;
    }
    public class ResponseItem
    {
        [JsonPropertyName("phone_message_id")]
        public Dictionary<string, string> PhoneMessageId { get; set; } = new Dictionary<string, string>();
    }
}
