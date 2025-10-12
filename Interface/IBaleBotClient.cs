using Bale.API.Client.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bale.API.Client.Interface
{
    /// <summary>
    /// اینترفیس اصلی برای کلاینت API ربات بله.
    /// تمام متدهای موجود در مستندات بازوی بله در اینجا تعریف شده‌اند.
    /// </summary>
    public interface IBaleBotClient
    {
        #region دریافت اطلاعات و آپدیت‌ها
        Task<BaleApiResponse<User>> GetMeAsync();
        Task<BaleApiResponse<Update[]>> GetUpdatesAsync(int? offset = null, int? limit = null, int? timeout = null);
        #endregion

        #region مدیریت وب‌هوک
        Task<BaleApiResponse<bool>> SetWebhookAsync(string url);
        Task<BaleApiResponse<bool>> DeleteWebhookAsync();
        Task<BaleApiResponse<WebhookInfo>> GetWebhookInfoAsync();
        #endregion

        #region ارسال پیام و رسانه
        Task<BaleApiResponse<Message>> SendMessageAsync(string chatId, string text, int? replyToMessageId = null, object? replyMarkup = null);
        Task<BaleApiResponse<Message>> ForwardMessageAsync(string chatId, string fromChatId, int messageId);
        Task<BaleApiResponse<Message>> SendPhotoAsync(string chatId, string photo, string? caption = null, int? replyToMessageId = null, object? replyMarkup = null);
        Task<BaleApiResponse<Message>> SendAudioAsync(string chatId, string audio, string? caption = null, int? replyToMessageId = null, object? replyMarkup = null);
        Task<BaleApiResponse<Message>> SendDocumentAsync(string chatId, string document, string? caption = null, int? replyToMessageId = null, object? replyMarkup = null);
        Task<BaleApiResponse<Message>> SendVideoAsync(string chatId, string video, string? caption = null, int? replyToMessageId = null, object? replyMarkup = null);
        Task<BaleApiResponse<Message>> SendVoiceAsync(string chatId, string voice, string? caption = null, int? replyToMessageId = null, object? replyMarkup = null);
        Task<BaleApiResponse<Message>> SendLocationAsync(string chatId, float latitude, float longitude, int? replyToMessageId = null, object? replyMarkup = null);
        Task<BaleApiResponse<Message>> SendContactAsync(string chatId, string phoneNumber, string firstName, string? lastName = null, int? replyToMessageId = null, object? replyMarkup = null);
        Task<BaleApiResponse<bool>> SendChatActionAsync(string chatId, string action);
        #endregion

        #region مدیریت پیام‌ها
        Task<BaleApiResponse<Message>> EditMessageTextAsync(string chatId, int messageId, string text, object? replyMarkup = null);
        Task<BaleApiResponse<Message>> EditMessageCaptionAsync(string chatId, int messageId, string? caption = null, object? replyMarkup = null);
        Task<BaleApiResponse<bool>> DeleteMessageAsync(string chatId, int messageId);
        Task<BaleApiResponse<bool>> AnswerCallbackQueryAsync(string callbackQueryId, string? text = null, bool? showAlert = null);
        #endregion

        #region مدیریت چت و کاربران
        Task<BaleApiResponse<ChatFullInfo>> GetChatAsync(string chatId);
        Task<BaleApiResponse<int>> GetChatMembersCountAsync(string chatId);
        Task<BaleApiResponse<bool>> BanChatMemberAsync(string chatId, long userId);
        Task<BaleApiResponse<bool>> UnbanChatMemberAsync(string chatId, long userId);
        Task<BaleApiResponse<bool>> LeaveChatAsync(string chatId);
        Task<BaleApiResponse<BaleFile>> GetFileAsync(string fileId);
        #endregion
    }
}
