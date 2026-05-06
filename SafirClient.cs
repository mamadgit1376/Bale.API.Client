using Bale.API.Client.Interface;
using Bale.API.Client.Models;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http.Headers;
using System.Net.Http.Json;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace Bale.API.Client
{
    public class SafirClient : ISafirClient
    {
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly BaleBotClientOptions _options;
        private readonly JsonSerializerOptions _jsonSerializerOptions;

        // آدرس پایه API بله به صورت ثابت در اینجا تعریف شده است.
        private const string SafirApiBaseUrl = "https://safir.bale.ai/api/v3";

        public SafirClient(IHttpClientFactory httpClientFactory, IOptions<BaleBotClientOptions> options)
        {
            _httpClientFactory = httpClientFactory;
            _options = options.Value;
            _jsonSerializerOptions = new JsonSerializerOptions
            {
                // این گزینه باعث می‌شود فیلدهای null در زمان ارسال JSON نادیده گرفته شوند.
                DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull
            };
        }



        public async Task<SafirApiResponse> SendSafirMessageAsync(int botId, string phoneNumber, SafirMessageData safirMessageData, string? requestId)
        {
            if (string.IsNullOrWhiteSpace(_options?.SafirAccessToken))
                throw new InvalidOperationException("Access token is missing.");
            if (botId == 0)
                throw new ArgumentNullException(nameof(botId), "ایدی ربات نمی‌تواند خالی باشد.");
            if (string.IsNullOrWhiteSpace(phoneNumber))
                throw new ArgumentNullException(nameof(phoneNumber), "شماره تماس نمی‌تواند خالی باشد.");

            var payload = new { bot_id = botId, request_id = requestId, phone_number = phoneNumber, message_data = safirMessageData };
            return await SafirPostAsync("send_message", payload);
        }


        public async Task<(SafirBatchMessageApiResponse? res, HttpStatusCode Status)> SendGroupSafirMessagesAsync(int botId, List<BatchMessage> batchMessages, string? requestId)
        {
            if (string.IsNullOrWhiteSpace(_options?.SafirAccessToken))
                throw new InvalidOperationException("Access token is missing.");
            if (botId == 0)
                throw new ArgumentNullException(nameof(botId), "ایدی ربات نمی‌تواند خالی باشد.");

            var payload = new { bot_id = botId, request_id = requestId, messages = batchMessages };
            return await SafirBatchPostAsync("send_batch", payload);
        }

        public async Task<SafirApiResponse> UploadSafirFileAsync(Stream fileStream, string fileName, string contentType)
        {
            if (string.IsNullOrWhiteSpace(_options?.SafirAccessToken))
                throw new InvalidOperationException("Access token is missing.");
            if (fileStream == null)
                throw new ArgumentNullException(nameof(fileStream), "استریم فایل نمی‌تواند خالی باشد.");

            if (string.IsNullOrWhiteSpace(fileName))
                throw new ArgumentException("نام فایل الزامی است.", nameof(fileName));

            return await SafirFormDataPostAsync("upload_file", fileStream, fileName, contentType);
        }

        /// <summary>
        /// متد کمکی برای ارسال درخواست‌های فرمی (Multipart/Form-Data) مخصوص آپلود فایل
        /// </summary>
        private async Task<SafirApiResponse> SafirFormDataPostAsync(string method, Stream fileStream, string fileName, string contentType)
        {
            try
            {
                var client = _httpClientFactory.CreateClient();
                var fullUrl = $"{SafirApiBaseUrl}/{method}";

                // ایجاد محتوای چند بخشی برای فرم دیتا
                var formData = new MultipartFormDataContent();

                // افزودن فایل به فرم
                // نکته فنی: استفاده از StreamContent برای جلوگیری از لود کردن کل فایل در حافظه (RAM) اگر فایل بزرگ باشد
                var streamContent = new StreamContent(fileStream);

                // تنظیم هدر Content-Type برای خود فایل
                streamContent.Headers.ContentType = new MediaTypeHeaderValue(contentType);

                // افزودن فایل به فرم با نام فیلد "file" (طبق مستندات معمول APIها)
                // اگر نام فیلد متفاوت است، باید در آرگومان دوم تغییر کند
                formData.Add(streamContent, "file", fileName);

                // ساخت درخواست HTTP
                var request = new HttpRequestMessage(HttpMethod.Post, fullUrl)
                {
                    Content = formData
                };

                // افزودن هدر دسترسی
                request.Headers.Add("api-access-key", _options.SafirAccessToken);

                // ارسال درخواست
                var response = await client.SendAsync(request);

                return await ProcessResponse(response);
            }
            catch (Exception ex)
            {
                throw new BaleApiException($"File upload failed for method '{method}'. Ensure the stream is readable and not disposed.", HttpStatusCode.InternalServerError, ex.Message, ex);
            }
        }

        private async Task<SafirApiResponse> SafirPostAsync(string method, object payload)
        {
            try
            {
                var client = _httpClientFactory.CreateClient();
                var fullUrl = $"{SafirApiBaseUrl}/{method}";

                // محتوای JSON
                var json = JsonSerializer.Serialize(payload, _jsonSerializerOptions);
                var content = new StringContent(json, Encoding.UTF8, "application/json");

                // ساخت پیام درخواست
                var request = new HttpRequestMessage(HttpMethod.Post, fullUrl)
                {
                    Content = content
                };

                // افزودن هدر مخصوص فقط این درخواست
                request.Headers.Add("api-access-key", _options.SafirAccessToken);

                // ارسال
                var response = await client.SendAsync(request);
                return await ProcessResponse(response);

            }
            catch (Exception ex)
            {
                throw new BaleApiException($"Request failed for method '{method}'. See inner exception for details.", HttpStatusCode.ServiceUnavailable, ex.Message, ex);
            }
        }
        private async Task<(SafirBatchMessageApiResponse? res, HttpStatusCode Status)> SafirBatchPostAsync(string method, object payload)
        {
            try
            {
                var client = _httpClientFactory.CreateClient();
                var fullUrl = $"{SafirApiBaseUrl}/{method}";

                // محتوای JSON
                var json = JsonSerializer.Serialize(payload, _jsonSerializerOptions);
                var content = new StringContent(json, Encoding.UTF8, "application/json");

                // ساخت پیام درخواست
                var request = new HttpRequestMessage(HttpMethod.Post, fullUrl)
                {
                    Content = content
                };

                // افزودن هدر مخصوص فقط این درخواست
                request.Headers.Add("api-access-key", _options.SafirAccessToken);

                // ارسال
                var response = await client.SendAsync(request);
                SafirBatchMessageApiResponse? res = null;
                if (response.StatusCode == HttpStatusCode.OK)
                {
                    res = await ProcessBatchResponse(response);
                }
                return (res, response.StatusCode);

            }
            catch (Exception ex)
            {
                throw new BaleApiException($"Request failed for method '{method}'. See inner exception for details.", HttpStatusCode.ServiceUnavailable, ex.Message, ex);
            }
        }

        private async Task<SafirApiResponse> ProcessResponse(HttpResponseMessage response)
        {
            try
            {
                var baleResponse = await response.Content.ReadFromJsonAsync<SafirApiResponse>();
                if (baleResponse != null)
                {
                    // چه موفق باشد (Ok=true) چه نباشد، آبجکت کامل را برمی‌گردانیم
                    return baleResponse;
                }
            }
            catch { }
            var errorContent = await response.Content.ReadAsStringAsync();
            throw new BaleApiException($"Request failed with status code {response.StatusCode}.", response.StatusCode, errorContent);
        }
        private async Task<SafirBatchMessageApiResponse> ProcessBatchResponse(HttpResponseMessage response)
        {
            try
            {
                var baleResponse = await response.Content.ReadFromJsonAsync<SafirBatchMessageApiResponse>();
                if (baleResponse != null)
                {
                    // چه موفق باشد (Ok=true) چه نباشد، آبجکت کامل را برمی‌گردانیم
                    return baleResponse;
                }
            }
            catch { }
            var errorContent = await response.Content.ReadAsStringAsync();
            throw new BaleApiException($"Request failed with status code {response.StatusCode}.", response.StatusCode, errorContent);
        }
    }
}
