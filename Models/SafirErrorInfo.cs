using System;
using System.Collections.Generic;
using System.Text;

namespace Bale.API.Client.Models
{
    public class SafirErrorInfo
    {
        /// <summary>
        /// 2	InternalServerError	خطای داخلی سرور
        /// 3	RateLimitExceeded بیش از حد مجاز پیام ارسال شده
        /// 20	PaymentRequired اعتبار کافی وجود ندارد
        /// 4    InvalidInput ورودی JSON نامعتبر
        /// 
        /// 8   InvalidPhone شماره اشتباه
        /// 17	NotBaleUser کاربر اکانت بله ندارد
        /// </summary>
        public int? code { get; set; }

        public string? phone_number { get; set; }
        public string? description { get; set; }
        public int? message_index { get; set; }
    }
}
