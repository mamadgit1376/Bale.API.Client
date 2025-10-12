using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Bale.API.Client.Models
{
    /// <summary>
    /// این شی نشان‌دهنده یک پیام است.
    /// </summary>
    public class Message
    {
        /// <summary>
        /// شناسه یکتای پیام در داخل گفتگو.
        /// </summary>
        [JsonPropertyName("message_id")]
        public int MessageId { get; set; }

        /// <summary>
        /// (اختیاری) ارسال‌کننده پیام. برای پیام‌های کانال خالی است.
        /// </summary>
        [JsonPropertyName("from")]
        public User? From { get; set; }

        /// <summary>
        /// تاریخ ارسال پیام (در قالب زمان یونیکس).
        /// </summary>
        [JsonPropertyName("date")]
        public long Date { get; set; }

        /// <summary>
        /// گفتگویی که پیام به آن تعلق دارد.
        /// </summary>
        [JsonPropertyName("chat")]
        public Chat Chat { get; set; } = null!;

        /// <summary>
        /// (اختیاری) برای پیام‌های باز ارسال شده (Forwarded)، ارسال‌کننده اصلی پیام.
        /// </summary>
        [JsonPropertyName("forward_from")]
        public User? ForwardFrom { get; set; }

        /// <summary>
        /// (اختیاری) برای پیام‌های باز ارسال شده از کانال‌ها، اطلاعات کانال اصلی.
        /// </summary>
        [JsonPropertyName("forward_from_chat")]
        public Chat? ForwardFromChat { get; set; }

        /// <summary>
        /// (اختیاری) تاریخ ارسال پیام اصلی به زمان یونیکس برای پیام‌های باز ارسال شده.
        /// </summary>
        [JsonPropertyName("forward_date")]
        public long? ForwardDate { get; set; }

        /// <summary>
        /// (اختیاری) برای پاسخ‌ها (Replies)، پیام اصلی که به آن پاسخ داده شده.
        /// </summary>
        [JsonPropertyName("reply_to_message")]
        public Message? ReplyToMessage { get; set; }

        /// <summary>
        /// (اختیاری) تاریخ آخرین ویرایش پیام به زمان یونیکس.
        /// </summary>
        [JsonPropertyName("edit_date")]
        public long? EditDate { get; set; }

        /// <summary>
        /// (اختیاری) برای پیام‌های متنی، متن واقعی پیام.
        /// </summary>
        [JsonPropertyName("text")]
        public string? Text { get; set; }

        /// <summary>
        /// (اختیاری) برای پیام‌های متنی، بخش‌های خاصی از متن مانند منشن‌ها یا دستورات.
        /// </summary>
        [JsonPropertyName("entities")]
        public MessageEntity[]? Entities { get; set; }

        /// <summary>
        /// (اختیاری) اطلاعات فایل صوتی (موسیقی).
        /// </summary>
        [JsonPropertyName("audio")]
        public Audio? Audio { get; set; }

        /// <summary>
        /// (اختیاری) اطلاعات فایل عمومی (سند).
        /// </summary>
        [JsonPropertyName("document")]
        public Document? Document { get; set; }

        /// <summary>
        /// (اختیاری) آرایه‌ای از سایزهای مختلف عکس موجود.
        /// </summary>
        [JsonPropertyName("photo")]
        public PhotoSize[]? Photo { get; set; }

        /// <summary>
        /// (اختیاری) اطلاعات فایل ویدیویی.
        /// </summary>
        [JsonPropertyName("video")]
        public Video? Video { get; set; }

        /// <summary>
        /// (اختیاری) اطلاعات مخاطب اشتراک‌گذاری شده.
        /// </summary>
        [JsonPropertyName("contact")]
        public Contact? Contact { get; set; }

        /// <summary>
        /// (اختیاری) اطلاعات موقعیت مکانی اشتراک‌گذاری شده.
        /// </summary>
        [JsonPropertyName("location")]
        public Location? Location { get; set; }

        /// <summary>
        /// (اختیاری) اطلاعات مربوط به پرداخت موفق.
        /// </summary>
        [JsonPropertyName("successful_payment")]
        public SuccessfulPayment? SuccessfulPayment { get; set; }
    }
}
