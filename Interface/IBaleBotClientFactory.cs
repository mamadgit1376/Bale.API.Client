using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bale.API.Client.Interface
{
    /// <summary>
    /// اینترفیسی برای کارخانه ساخت کلاینت‌های ربات بله.
    /// </summary>
    public interface IBaleBotClientFactory
    {
        /// <summary>
        /// یک نمونه جدید از کلاینت ربات بله را با استفاده از توکن مشخص شده ایجاد می‌کند.
        /// </summary>
        /// <param name="botToken">توکن احراز هویت ربات.</param>
        /// <returns>یک نمونه آماده از IBaleBotClient.</returns>
        IBaleBotClient CreateClient(string botToken);
    }
}
