using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Bale.API.Client.Models
{
    /// <summary>
    /// استثنایی که برای خطاهای دریافتی از API بله پرتاب می‌شود.
    /// </summary>
    /// <summary>
    /// استثنایی که برای خطاهای مشخص و قابل انتظار از API بله پرتاب می‌شود.
    /// </summary>
    public class BaleApiException : Exception
    {
        /// <summary>
        /// کد وضعیت HTTP پاسخ که از سرور دریافت شده است.
        /// </summary>
        public HttpStatusCode StatusCode { get; }

        /// <summary>
        /// محتوای متنی پاسخ خطا از سرور (معمولاً یک آبجکت JSON).
        /// </summary>
        public string? ErrorContent { get; }

        /// <summary>
        /// سازنده اصلی برای ساخت یک استثنای API بله.
        /// </summary>
        /// <param name="message">پیام اصلی خطا.</param>
        /// <param name="statusCode">کد وضعیت HTTP.</param>
        /// <param name="errorContent">محتوای پاسخ از سرور.</param>
        /// <param name="innerException">استثنای داخلی که باعث این خطا شده است.</param>
        public BaleApiException(string message, HttpStatusCode statusCode, string? errorContent = null, Exception? innerException = null)
            : base(message, innerException)
        {
            StatusCode = statusCode;
            ErrorContent = errorContent;
        }
    }
}
