using System;
using System.Collections.Generic;
using System.Text;

namespace Bale.API.Client.Models
{
    public class SafirMessage
    {
        /// <summary>
        /// متن پیام
        /// </summary>
        public string? text { get; set; }
        /// <summary>
        /// آیدی فایل
        /// </summary>
        public string? file_id { get; set; }
        /// <summary>
        /// دکمه رونوشت
        /// </summary>
        public string? copy_text { get; set; }
    }
}
