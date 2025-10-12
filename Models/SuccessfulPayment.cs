using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Bale.API.Client.Models
{
    /// <summary>
    /// این شیء شامل اطلاعات اولیه درباره یک پرداخت موفق است.
    /// </summary>
    public class SuccessfulPayment
    {
        /// <summary>
        /// واحد پول (همیشه "IRR" برای ریال).
        /// </summary>
        [JsonPropertyName("currency")]
        public string Currency { get; set; } = string.Empty;

        /// <summary>
        /// مبلغ کل پرداخت به ریال.
        /// </summary>
        [JsonPropertyName("total_amount")]
        public int TotalAmount { get; set; }

        /// <summary>
        /// اطلاعات داخلی صورتحساب که توسط بازو تعریف شده بود.
        /// </summary>
        [JsonPropertyName("invoice_payload")]
        public string InvoicePayload { get; set; } = string.Empty;

        /// <summary>
        /// شناسه یکتای پرداخت در بله.
        /// </summary>
        [JsonPropertyName("telegram_payment_charge_id")]
        public string BalePaymentChargeId { get; set; } = string.Empty;

        /// <summary>
        /// شناسه یکتای پرداخت از سمت ارائه‌دهنده سرویس پرداخت (مثلاً شماره پیگیری کیف پول).
        /// </summary>
        [JsonPropertyName("provider_payment_charge_id")]
        public string ProviderPaymentChargeId { get; set; } = string.Empty;
    }
}
