using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Bale.API.Client.Models
{

    /// <summary>
    /// این شی بیانگر یک رویداد یا آپدیت دریافتی است.
    /// حداکثر یکی از فیلدهای اختیاری در هر آپدیت وجود خواهد داشت.
    /// </summary>
    public class Update
    {
        /// <summary>
        /// شناسه یکتای آپدیت.
        /// </summary>
        [JsonPropertyName("update_id")]
        public int UpdateId { get; set; }

        /// <summary>
        /// (اختیاری) یک پیام جدید از هر نوعی.
        /// </summary>
        [JsonPropertyName("message")]
        public Message? Message { get; set; }

        /// <summary>
        /// (اختیاری) نسخه ویرایش‌شده یک پیام.
        /// </summary>
        [JsonPropertyName("edited_message")]
        public Message? EditedMessage { get; set; }

        /// <summary>
        /// (اختیاری) یک درخواست بازگشتی (Callback) جدید از یک دکمه شیشه‌ای.
        /// </summary>
        [JsonPropertyName("callback_query")]
        public CallbackQuery? CallbackQuery { get; set; }

        // سایر انواع آپدیت مانند pre_checkout_query و ... نیز می‌توانند در اینجا اضافه شوند.
    }
}
