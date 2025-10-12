using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Bale.API.Client.Models
{
    /// <summary>
    /// این شی نشان‌دهنده یک نقطه روی نقشه است.
    /// </summary>
    public class Location
    {
        /// <summary>
        /// طول جغرافیایی.
        /// </summary>
        [JsonPropertyName("longitude")]
        public float Longitude { get; set; }

        /// <summary>
        /// عرض جغرافیایی.
        /// </summary>
        [JsonPropertyName("latitude")]
        public float Latitude { get; set; }

        /// <summary>
        /// (اختیاری) شعاع عدم قطعیت برای موقعیت مکانی به متر.
        /// </summary>
        [JsonPropertyName("horizontal_accuracy")]
        public float? HorizontalAccuracy { get; set; }
    }
}
