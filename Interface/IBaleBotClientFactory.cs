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

        /// <summary>
        /// ساخت یک نمومه از کلایت سامانه سفیر
        /// </summary>
        /// <param name="safirAccessToken"></param>
        /// <returns></returns>
        ISafirClient CreateSafirClient(string safirAccessToken);
    }
}
