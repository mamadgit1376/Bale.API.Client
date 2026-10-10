using System.Text.Json.Serialization;

namespace Bale.API.Client.Models
{
    public class SendOtpResponse
    {
        [JsonPropertyName("balance")]
        public int? Balance { get; set; }

        [JsonPropertyName("type")]
        public int? Type { get; set; }

        [JsonPropertyName("code")]
        public int? Code { get; set; }

        [JsonPropertyName("message")]
        public string? Message { get; set; }
    }
}
