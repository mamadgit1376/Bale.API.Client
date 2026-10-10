using Bale.API.Client.Models;
using System;
using System.Collections.Generic;
using System.Net;
using System.Text;

namespace Bale.API.Client.Interface
{
    public interface ISafirClient
    {
        /// <summary>
        /// دریافت توکن سفیر v2 با نام کاربری و رمز عبور؛ در پاسخ HTTP ناموفق، null برمی‌گرداند.
        /// </summary>
        Task<AuthenticationResponse?> AuthenticateAsync(string clientId, string clientSecret);

        /// <summary>
        /// ارسال OTP با سفیر v2 و توکن Bearer؛ پاسخ موفق یا خطای API را برمی‌گرداند.
        /// </summary>
        Task<SendOtpResponse?> SendOtpAsync(SendOtpRequest request, string accessToken);

        /// <summary>
        /// ارسال پیام تکی با سفیر  به شماره همراه 
        /// </summary>
        /// <param name="botId"></param>
        /// <param name="phoneNumber">+98 or 98</param>
        /// <param name="safirMessageData"></param>
        /// <param name="requestId">اختیاری</param>
        /// <returns></returns>
        Task<SafirApiResponse> SendSafirMessageAsync(int botId, string phoneNumber, SafirMessageData safirMessageData, string? requestId);

        /// <summary>
        /// ارسال رمز یک‌بارمصرف عددی با سفیر
        /// </summary>
        /// <param name="botId">شناسه بازوی ارسال‌کننده</param>
        /// <param name="phoneNumber">+98 or 98</param>
        /// <param name="otp">رمز شامل ارقام 0 تا 9</param>
        /// <param name="requestId">شناسه اختیاری برای جلوگیری از ارسال تکراری</param>
        Task<SafirApiResponse> SendSafirOtpAsync(int botId, string phoneNumber, string otp, string? requestId = null);

        /// <summary>
        /// ارسال پیام گروهی با سفیر
        /// </summary>
        /// <param name="botId">ایدی ربات متصل شده</param>
        /// <param name="batchMessages">پیام ها</param>
        /// <param name="requestId">شماره درخواست </param>
        /// <returns></returns>
        Task<(SafirBatchMessageApiResponse? res, HttpStatusCode Status)> SendGroupSafirMessagesAsync(int botId, List<BatchMessage> batchMessages, string? requestId);

        /// <summary>
        /// آپلود فایل به سرور بله به صورت Multipart/Form-Data
        /// </summary>
        /// <param name="fileStream">استریم فایل برای ارسال</param>
        /// <param name="fileName">نام فایل (شامل پسوند)</param>
        /// <param name="contentType">نوع محتوای فایل (مثلاً image/jpeg, application/pdf)</param>
        /// <returns>پاسخ API</returns>
        Task<SafirApiResponse> UploadSafirFileAsync(Stream fileStream, string fileName, string contentType);
    }
}
