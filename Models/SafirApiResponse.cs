using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

namespace Bale.API.Client.Models
{
    public class SafirApiResponse
    {
        public string? message_id { get; set; } = null;
        public string? request_id { get; set; } = null;
        public string? file_id { get; set; } = null;
        public List<SafirErrorInfo>? error_data { get; set; } = null;
    }

}
