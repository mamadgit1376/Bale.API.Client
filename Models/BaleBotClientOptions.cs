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
        public string? BotToken { get; set; } = string.Empty;
        public string? SafirAccessToken {  get; set; } = string.Empty;
    }
}
