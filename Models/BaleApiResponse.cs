using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Bale.API.Client.Models
{
    /// <summary>
    /// ساختار استاندارد پاسخ‌های موفق از API بله را مدل می‌کند.
    /// </summary>
    /// <typeparam name="T">نوع داده‌ای که در فیلد 'result' قرار می‌گیرد.</typeparam>
    public class BaleApiResponse<T>
    {
        /// <summary>
        /// نشان‌دهنده موفقیت‌آمیز بودن درخواست است.
        /// </summary>
        [JsonPropertyName("ok")]
        public bool Ok { get; set; }

        /// <summary>
        /// نتیجه اصلی درخواست در صورت موفقیت.
        /// </summary>
        [JsonPropertyName("result")]
        public T? Result { get; set; }
    }
}
