using System;
using System.Collections.Generic;
using System.Text;

namespace Bale.API.Client.Models
{
    public class BatchMessage
    {
        public List<string> phone_numbers { get; set; }
        public SafirMessageData message_data { get; set; }
    }
}
