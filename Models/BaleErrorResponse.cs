using System.Text.Json.Serialization;

namespace Bale.API.Client.Models
{
    /// <summary>
    /// ساختار استاندارد پاسخ‌های ناموفق از API بله را مدل می‌کند.
    /// </summary>
    public class BaleErrorResponse
    {
        /// <summary>
        /// همیشه false است.
        /// </summary>
        [JsonPropertyName("ok")]
        public bool Ok { get; set; }

        /// <summary>
        /// کد خطای عددی.
        /// </summary>
        [JsonPropertyName("error_code")]
        public int ErrorCode { get; set; }

        /// <summary>
        /// توضیحات متنی خطا.
        /// </summary>
        [JsonPropertyName("description")]
        public string Description { get; set; } = string.Empty;
    }
}
