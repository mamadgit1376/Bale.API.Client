using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

namespace Bale.API.Client.Models
{
    public class ReplyKeyboardRemove
    {
        /// <summary>
        /// با true دادن کیبورد پایین پاک میشود به حالت پیشفرض /start 
        /// </summary>
        [JsonPropertyName("remove_keyboard")]
        public bool? RemoveKeyboard { get; set; }
    }
}
