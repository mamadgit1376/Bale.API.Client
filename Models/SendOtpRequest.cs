using System.Text.Json.Serialization;

namespace Bale.API.Client.Models
{
    public class SendOtpRequest
    {
        [JsonPropertyName("phone")]
        public string Phone { get; set; } = string.Empty;

        [JsonPropertyName("otp")]
        public int Otp { get; set; }
    }
}
