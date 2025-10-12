using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bale.API.Client.Models
{
    /// <summary>
    /// تنظیمات مورد نیاز برای کلاینت ربات بله را نگهداری می‌کند.
    /// </summary>
    public class BaleBotClientOptions
    {
        /// <summary>
        /// توکن احراز هویت ربات که از BotFather دریافت می‌شود.
        /// </summary>
        public string BotToken { get; set; } = string.Empty;

        /// <summary>
        /// آدرس پایه API بازوی بله.
        /// این مقدار به صورت پیش‌فرض تنظیم شده است اما توسط کاربر قابل تغییر است.
        /// </summary>
        public string BaseUrl { get; set; } = "https://tapi.bale.ai/";
    }
}
