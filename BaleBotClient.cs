using Bale.API.Client.Interface;
using Bale.API.Client.Models;
using Microsoft.Extensions.Options;
using System.Net;
using System.Net.Http.Json;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace Bale.API.Client
{
    /// <summary>
    /// پیاده‌سازی کامل کلاینت API ربات بله (نسخه بدون لاگ داخلی).
    /// </summary>
    public class BaleBotClient : IBaleBotClient
    {
        private readonly HttpClient _httpClient;
        private readonly BaleBotClientOptions _options;
        private readonly JsonSerializerOptions _jsonSerializerOptions;

        public BaleBotClient(HttpClient httpClient, IOptions<BaleBotClientOptions> options)
        {
            _httpClient = httpClient;
            _options = options.Value;
            _jsonSerializerOptions = new JsonSerializerOptions
            {
                DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull
            };
        }

        #region دریافت اطلاعات و آپدیت‌ها
        public async Task<BaleApiResponse<User>> GetMeAsync()
            => await GetAsync<User>("getMe");

        public async Task<BaleApiResponse<Update[]>> GetUpdatesAsync(int? offset = null, int? limit = null, int? timeout = null)
        {
            var payload = new { offset, limit, timeout };
            return await PostAsync<Update[]>("getUpdates", payload);
        }
        #endregion

        #region مدیریت وب‌هوک
        public async Task<BaleApiResponse<bool>> SetWebhookAsync(string url)
        {
            var payload = new { url };
            return await PostAsync<bool>("setWebhook", payload);
        }

        public async Task<BaleApiResponse<bool>> DeleteWebhookAsync()
            => await GetAsync<bool>("deleteWebhook");

        public async Task<BaleApiResponse<WebhookInfo>> GetWebhookInfoAsync()
            => await GetAsync<WebhookInfo>("getWebhookInfo");
        #endregion

        #region ارسال پیام و رسانه
        public async Task<BaleApiResponse<Message>> SendMessageAsync(string chatId, string text, int? replyToMessageId = null, object? replyMarkup = null)
        {
            var payload = new { chat_id = chatId, text, reply_to_message_id = replyToMessageId, reply_markup = replyMarkup };
            return await PostAsync<Message>("sendMessage", payload);
        }

        public async Task<BaleApiResponse<Message>> ForwardMessageAsync(string chatId, string fromChatId, int messageId)
        {
            var payload = new { chat_id = chatId, from_chat_id = fromChatId, message_id = messageId };
            return await PostAsync<Message>("forwardMessage", payload);
        }

        public async Task<BaleApiResponse<Message>> SendPhotoAsync(string chatId, string photo, string? caption = null, int? replyToMessageId = null, object? replyMarkup = null)
        {
            var payload = new { chat_id = chatId, photo, caption, reply_to_message_id = replyToMessageId, reply_markup = replyMarkup };
            return await PostAsync<Message>("sendPhoto", payload);
        }

        public async Task<BaleApiResponse<Message>> SendAudioAsync(string chatId, string audio, string? caption = null, int? replyToMessageId = null, object? replyMarkup = null)
        {
            var payload = new { chat_id = chatId, audio, caption, reply_to_message_id = replyToMessageId, reply_markup = replyMarkup };
            return await PostAsync<Message>("sendAudio", payload);
        }

        public async Task<BaleApiResponse<Message>> SendDocumentAsync(string chatId, string document, string? caption = null, int? replyToMessageId = null, object? replyMarkup = null)
        {
            var payload = new { chat_id = chatId, document, caption, reply_to_message_id = replyToMessageId, reply_markup = replyMarkup };
            return await PostAsync<Message>("sendDocument", payload);
        }

        public async Task<BaleApiResponse<Message>> SendVideoAsync(string chatId, string video, string? caption = null, int? replyToMessageId = null, object? replyMarkup = null)
        {
            var payload = new { chat_id = chatId, video, caption, reply_to_message_id = replyToMessageId, reply_markup = replyMarkup };
            return await PostAsync<Message>("sendVideo", payload);
        }

        public async Task<BaleApiResponse<Message>> SendVoiceAsync(string chatId, string voice, string? caption = null, int? replyToMessageId = null, object? replyMarkup = null)
        {
            var payload = new { chat_id = chatId, voice, caption, reply_to_message_id = replyToMessageId, reply_markup = replyMarkup };
            return await PostAsync<Message>("sendVoice", payload);
        }

        public async Task<BaleApiResponse<Message>> SendLocationAsync(string chatId, float latitude, float longitude, int? replyToMessageId = null, object? replyMarkup = null)
        {
            var payload = new { chat_id = chatId, latitude, longitude, reply_to_message_id = replyToMessageId, reply_markup = replyMarkup };
            return await PostAsync<Message>("sendLocation", payload);
        }

        public async Task<BaleApiResponse<Message>> SendContactAsync(string chatId, string phoneNumber, string firstName, string? lastName = null, int? replyToMessageId = null, object? replyMarkup = null)
        {
            var payload = new { chat_id = chatId, phone_number = phoneNumber, first_name = firstName, last_name = lastName, reply_to_message_id = replyToMessageId, reply_markup = replyMarkup };
            return await PostAsync<Message>("sendContact", payload);
        }

        public async Task<BaleApiResponse<bool>> SendChatActionAsync(string chatId, string action)
        {
            var payload = new { chat_id = chatId, action };
            return await PostAsync<bool>("sendChatAction", payload);
        }
        #endregion

        #region مدیریت پیام‌ها
        public async Task<BaleApiResponse<Message>> EditMessageTextAsync(string chatId, int messageId, string text, object? replyMarkup = null)
        {
            var payload = new { chat_id = chatId, message_id = messageId, text, reply_markup = replyMarkup };
            return await PostAsync<Message>("editMessageText", payload);
        }

        public async Task<BaleApiResponse<Message>> EditMessageCaptionAsync(string chatId, int messageId, string? caption = null, object? replyMarkup = null)
        {
            var payload = new { chat_id = chatId, message_id = messageId, caption, reply_markup = replyMarkup };
            return await PostAsync<Message>("editMessageCaption", payload);
        }

        public async Task<BaleApiResponse<bool>> DeleteMessageAsync(string chatId, int messageId)
        {
            var payload = new { chat_id = chatId, message_id = messageId };
            return await PostAsync<bool>("deleteMessage", payload);
        }

        public async Task<BaleApiResponse<bool>> AnswerCallbackQueryAsync(string callbackQueryId, string? text = null, bool? showAlert = null)
        {
            var payload = new { callback_query_id = callbackQueryId, text, show_alert = showAlert };
            return await PostAsync<bool>("answerCallbackQuery", payload);
        }
        #endregion

        #region مدیریت چت و کاربران
        public async Task<BaleApiResponse<ChatFullInfo>> GetChatAsync(string chatId)
        {
            var payload = new { chat_id = chatId };
            return await PostAsync<ChatFullInfo>("getChat", payload);
        }

        public async Task<BaleApiResponse<int>> GetChatMembersCountAsync(string chatId)
        {
            var payload = new { chat_id = chatId };
            return await PostAsync<int>("getChatMembersCount", payload);
        }

        public async Task<BaleApiResponse<bool>> BanChatMemberAsync(string chatId, long userId)
        {
            var payload = new { chat_id = chatId, user_id = userId };
            return await PostAsync<bool>("banChatMember", payload);
        }

        public async Task<BaleApiResponse<bool>> UnbanChatMemberAsync(string chatId, long userId)
        {
            var payload = new { chat_id = chatId, user_id = userId };
            return await PostAsync<bool>("unbanChatMember", payload);
        }

        public async Task<BaleApiResponse<bool>> LeaveChatAsync(string chatId)
        {
            var payload = new { chat_id = chatId };
            return await PostAsync<bool>("leaveChat", payload);
        }

        public async Task<BaleApiResponse<BaleFile>> GetFileAsync(string fileId)
        {
            var payload = new { file_id = fileId };
            return await PostAsync<BaleFile>("getFile", payload);
        }
        #endregion


        #region متدهای کمکی خصوصی (Private Helper Methods)

        private async Task<BaleApiResponse<TResponse>> GetAsync<TResponse>(string method)
        {
            // 🔥 تغییر: حالا از آدرس نسبی استفاده می‌کنیم چون BaseAddress از قبل تنظیم شده
            var response = await _httpClient.GetAsync($"bot{_options.BotToken}/{method}");
            return await ProcessResponse<TResponse>(response);
        }

        private async Task<BaleApiResponse<TResponse>> PostAsync<TResponse>(string method, object payload)
        {
            var jsonContent = new StringContent(JsonSerializer.Serialize(payload, _jsonSerializerOptions), Encoding.UTF8, "application/json");
            // 🔥 تغییر: حالا از آدرس نسبی استفاده می‌کنیم
            var response = await _httpClient.PostAsync($"bot{_options.BotToken}/{method}", jsonContent);
            return await ProcessResponse<TResponse>(response);
        }

        private async Task<BaleApiResponse<TResponse>> ProcessResponse<TResponse>(HttpResponseMessage response)
        {
            // این متد بدون تغییر باقی می‌ماند
            if (response.IsSuccessStatusCode)
            {
                var baleResponse = await response.Content.ReadFromJsonAsync<BaleApiResponse<TResponse>>();
                if (baleResponse != null && baleResponse.Ok)
                {
                    return baleResponse;
                }

                var errorDesc = (await response.Content.ReadFromJsonAsync<BaleErrorResponse>())?.Description;
                throw new BaleApiException(errorDesc ?? "Bale API returned OK=false but no description.", response.StatusCode);
            }

            var errorContent = await response.Content.ReadAsStringAsync();
            throw new BaleApiException($"Request failed with status code {response.StatusCode}.", response.StatusCode, errorContent);
        }

        #endregion    
    }
}