// File: Interfaces/IBaleBotClient.cs
using Bale.API.Client.Models;

namespace Bale.API.Client.Interface
{
    /// <summary>
    /// اینترفیس کامل برای کلاینت API ربات بله (بازوی بله).
    /// </summary>
    public interface IBaleBotClient
    {
        #region دریافت اطلاعات و آپدیت‌ها
        /// <summary>
        /// اطلاعات پایه ربات را برای تست توکن و ارتباط دریافت می‌کند.
        /// </summary>
        Task<BaleApiResponse<User>> GetMeAsync();

        /// <summary>
        /// آخرین آپدیت‌های ارسال شده به ربات را با استفاده از Long Polling دریافت می‌کند.
        /// </summary>
        Task<BaleApiResponse<Update[]>> GetUpdatesAsync(int? offset = null, int? limit = null, int? timeout = null);
        #endregion

        #region مدیریت وب‌هوک
        /// <summary>
        /// یک آدرس URL برای دریافت آپدیت‌ها از طریق وبهوک تنظیم می‌کند.
        /// </summary>
        Task<BaleApiResponse<bool>> SetWebhookAsync(string url);

        /// <summary>
        /// وبهوک فعلی ربات را حذف می‌کند.
        /// </summary>
        Task<BaleApiResponse<bool>> DeleteWebhookAsync();

        /// <summary>
        /// اطلاعات وبهوک فعلی را دریافت می‌کند.
        /// </summary>
        Task<BaleApiResponse<WebhookInfo>> GetWebhookInfoAsync();
        #endregion

        #region ارسال پیام و رسانه
        /// <summary>
        /// یک پیام متنی ارسال می‌کند.
        /// </summary>
        Task<BaleApiResponse<Message>> SendMessageAsync(string chatId, string text, int? replyToMessageId = null, object? replyMarkup = null);

        /// <summary>
        /// یک پیام را از چتی به چت دیگر فوروارد می‌کند.
        /// </summary>
        Task<BaleApiResponse<Message>> ForwardMessageAsync(string chatId, string fromChatId, int messageId);

        /// <summary>
        /// یک تصویر ارسال می‌کند.
        /// </summary>
        Task<BaleApiResponse<Message>> SendPhotoAsync(string chatId, string photo, string? caption = null, int? replyToMessageId = null, object? replyMarkup = null);

        /// <summary>
        /// یک فایل صوتی (موسیقی) ارسال می‌کند.
        /// </summary>
        Task<BaleApiResponse<Message>> SendAudioAsync(string chatId, string audio, string? caption = null, int? replyToMessageId = null, object? replyMarkup = null);

        /// <summary>
        /// یک فایل عمومی (سند) ارسال می‌کند.
        /// </summary>
        Task<BaleApiResponse<Message>> SendDocumentAsync(string chatId, string document, string? caption = null, int? replyToMessageId = null, object? replyMarkup = null);

        /// <summary>
        /// یک فایل ویدیویی ارسال می‌کند.
        /// </summary>
        Task<BaleApiResponse<Message>> SendVideoAsync(string chatId, string video, string? caption = null, int? replyToMessageId = null, object? replyMarkup = null);

        /// <summary>
        /// یک پیام صوتی (ویس) ارسال می‌کند.
        /// </summary>
        Task<BaleApiResponse<Message>> SendVoiceAsync(string chatId, string voice, string? caption = null, int? replyToMessageId = null, object? replyMarkup = null);

        /// <summary>
        /// یک موقعیت مکانی روی نقشه ارسال می‌کند.
        /// </summary>
        Task<BaleApiResponse<Message>> SendLocationAsync(string chatId, float latitude, float longitude, int? replyToMessageId = null, object? replyMarkup = null);

        /// <summary>
        /// یک مخاطب تلفن ارسال می‌کند.
        /// </summary>
        Task<BaleApiResponse<Message>> SendContactAsync(string chatId, string phoneNumber, string firstName, string? lastName = null, int? replyToMessageId = null, object? replyMarkup = null);

        /// <summary>
        /// وضعیت "در حال انجام کاری" را برای ربات نمایش می‌دهد (مثلاً typing...).
        /// </summary>
        Task<BaleApiResponse<bool>> SendChatActionAsync(string chatId, string action);
        #endregion

        #region مدیریت پیام‌ها
        /// <summary>
        /// متن یک پیام را ویرایش می‌کند.
        /// </summary>
        Task<BaleApiResponse<Message>> EditMessageTextAsync(string chatId, int messageId, string text, object? replyMarkup = null);

        /// <summary>
        /// زیرنویس (caption) یک پیام رسانه‌ای را ویرایش می‌کند.
        /// </summary>
        Task<BaleApiResponse<Message>> EditMessageCaptionAsync(string chatId, int messageId, string? caption = null, object? replyMarkup = null);

        /// <summary>
        /// یک پیام را حذف می‌کند.
        /// </summary>
        Task<BaleApiResponse<bool>> DeleteMessageAsync(string chatId, int messageId);

        /// <summary>
        /// به یک درخواست بازگشتی (Callback Query) از دکمه‌های شیشه‌ای پاسخ می‌دهد.
        /// </summary>
        Task<BaleApiResponse<bool>> AnswerCallbackQueryAsync(string callbackQueryId, string? text = null, bool? showAlert = null);
        #endregion

        #region مدیریت چت و کاربران
        /// <summary>
        /// اطلاعات کامل یک چت را دریافت می‌کند.
        /// </summary>
        Task<BaleApiResponse<ChatFullInfo>> GetChatAsync(string chatId);

        /// <summary>
        /// تعداد اعضای یک چت را دریافت می‌کند.
        /// </summary>
        Task<BaleApiResponse<int>> GetChatMembersCountAsync(string chatId);

        /// <summary>
        /// یک کاربر را در گروه یا کانال مسدود می‌کند.
        /// </summary>
        Task<BaleApiResponse<bool>> BanChatMemberAsync(string chatId, long userId);

        /// <summary>
        /// یک کاربر را از حالت مسدود خارج می‌کند.
        /// </summary>
        Task<BaleApiResponse<bool>> UnbanChatMemberAsync(string chatId, long userId);

        /// <summary>
        /// ربات را از یک گروه یا کانال خارج می‌کند.
        /// </summary>
        Task<BaleApiResponse<bool>> LeaveChatAsync(string chatId);

        /// <summary>
        /// اطلاعات یک فایل را برای دانلود دریافت می‌کند.
        /// </summary>
        Task<BaleApiResponse<BaleFile>> GetFileAsync(string fileId);
        #endregion
    }
}