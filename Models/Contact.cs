using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Bale.API.Client.Models
{
    /// <summary>
    /// این شی نشان‌دهنده یک مخاطب تلفن است.
    /// </summary>
    public class Contact
    {
        /// <summary>
        /// شماره تماس مخاطب.
        /// </summary>
        [JsonPropertyName("phone_number")]
        public string PhoneNumber { get; set; } = string.Empty;

        /// <summary>
        /// نام کوچک مخاطب.
        /// </summary>
        [JsonPropertyName("first_name")]
        public string FirstName { get; set; } = string.Empty;

        /// <summary>
        /// (اختیاری) نام خانوادگی مخاطب.
        /// </summary>
        [JsonPropertyName("last_name")]
        public string? LastName { get; set; }

        /// <summary>
        /// (اختیاری) شناسه کاربری مخاطب در بله.
        /// </summary>
        [JsonPropertyName("user_id")]
        public long? UserId { get; set; }
    }
}
