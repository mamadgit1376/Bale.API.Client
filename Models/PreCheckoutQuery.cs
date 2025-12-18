using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Bale.API.Client.Models
{
    /// <summary>
    /// شامل اطلاعاتی درباره پرداخت است که بازو باید آن را تأیید کند.
    /// </summary>
    public class PreCheckoutQuery
    {
        /// <summary>
        /// شناسه یکتای تراکنش.
        /// </summary>
        [JsonPropertyName("id")]
        public string Id { get; set; } = string.Empty;

        /// <summary>
        /// اطلاعات فرد پرداخت‌کننده.
        /// </summary>
        [JsonPropertyName("from")]
        public User From { get; set; } = null!;

        /// <summary>
        /// واحد پول (ریال - IRR).
        /// </summary>
        [JsonPropertyName("currency")]
        public string Currency { get; set; } = string.Empty;

        /// <summary>
        /// قیمت کل به ریال.
        /// </summary>
        [JsonPropertyName("total_amount")]
        public int TotalAmount { get; set; }

        /// <summary>
        /// اطلاعات صورتحسابی که شما هنگام ساخت فاکتور ارسال کردید.
        /// </summary>
        [JsonPropertyName("invoice_payload")]
        public string InvoicePayload { get; set; } = string.Empty;
    }
}
