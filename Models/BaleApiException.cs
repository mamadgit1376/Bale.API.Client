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
    public class BaleApiException : Exception
    {
        /// <summary>
        /// کد وضعیت HTTP پاسخ.
        /// </summary>
        public HttpStatusCode StatusCode { get; }

        /// <summary>
        /// محتوای پاسخ خطا از سرور.
        /// </summary>
        public string? ErrorContent { get; }

        public BaleApiException(string message, HttpStatusCode statusCode, string? errorContent = null)
            : base(message)
        {
            StatusCode = statusCode;
            ErrorContent = errorContent;
        }
    }
}
