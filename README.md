-----

# Mohammad.Bale.Bot.Client

[](https://www.google.com/search?q=https://www.nuget.org/packages/Mohammad.Bale.Bot.Client/)

**لینک گیت‌هاب:** [https://github.com/mamadgit1376/Bale.API.Client](https://github.com/mamadgit1376/Bale.API.Client)

یک کلاینت دات‌نت ساده، مدرن و قدرتمند برای کار با **API بازوی پیام‌رسان بله**. این کتابخانه تمام پیچیدگی‌های ارسال درخواست‌های HTTP را پنهان کرده و به شما اجازه می‌دهد تا به راحتی با متدها و مدل‌های کاملاً تایپ‌شده (Strongly-typed) با سرورهای بله تعامل داشته باشید.

## 🚀 ویژگی‌ها

  - **کاملاً غیرهمزمان (Async):** تمام متدها به صورت `async/await` پیاده‌سازی شده‌اند.
  - **پشتیبانی از چند ربات:** با استفاده از الگوی Factory، می‌توانید به سادگی کلاینت‌هایی برای ربات‌های مختلف با توکن‌های متفاوت در لحظه ایجاد کنید.
  - **مدل‌های Strongly-Typed:** تمام آبجکت‌های API (مانند `Message`, `Update`, `Chat`) به صورت کلاس‌های C\# مدل‌سازی شده‌اند.
  - **راه‌اندازی آسان:** با ثبت ساده `Factory` در سیستم تزریق وابستگی (Dependency Injection).
  - **مدیریت بهینه HttpClient:** با بهره‌گیری از `IHttpClientFactory` برای مدیریت بهینه ارتباطات.
  - **مدیریت خطای ساختاریافته:** پرتاب استثنای سفارشی `BaleApiException` در صورت بروز خطا از سمت API بله.

## 🔧 نصب

شما می‌توانید این پکیج را از طریق NuGet Gallery به پروژه خود اضافه کنید.

**از طریق .NET CLI:**

```bash
dotnet add package Mohammad.Bale.Bot.Client
```

**از طریق Package Manager Console:**

```powershell
Install-Package Mohammad.Bale.Bot.Client
```

## 🏁 شروع سریع

این کتابخانه برای سناریوهایی طراحی شده که شما نیاز به مدیریت یک یا چندین ربات با توکن‌های مختلف دارید.

### ۱. ثبت سرویس در `Program.cs`

ابتدا، فکتوری کلاینت را در `Program.cs` ثبت کنید. این فکتوری به شما اجازه می‌دهد در هر جای برنامه، یک کلاینت جدید برای یک ربات خاص بسازید.

```csharp
using Bale.API.Client.Factories;
using Bale.API.Client.Interface;

var builder = WebApplication.CreateBuilder(args);

// ... سایر سرویس‌ها

// ۱. ثبت IHttpClientFactory به صورت عمومی
builder.Services.AddHttpClient();

// ۲. ثبت فکتوری ربات بله به صورت Singleton
builder.Services.AddSingleton<IBaleBotClientFactory, BaleBotClientFactory>();

var app = builder.Build();

// ...
```

### ۲. استفاده در کنترلر (با دریافت توکن از کاربر)

حالا می‌توانید `IBaleBotClientFactory` را به کنترلر یا سرویس خود تزریق کرده، توکن ربات را از ورودی (مثلاً هدر درخواست یا `appsettings.json`) دریافت کنید و یک کلاینت مخصوص همان ربات بسازید.

```csharp
using Bale.API.Client.Interface;
using Bale.API.Client.Models;
using Bale.API.Client.Factories;
using Bale.API.Client.Exceptions;
using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("api/bot")]
public class BotController : ControllerBase
{
    private readonly IBaleBotClientFactory _baleBotFactory;

    public BotController(IBaleBotClientFactory baleBotFactory)
    {
        _baleBotFactory = baleBotFactory;
    }

    /// <summary>
    /// اطلاعات یک ربات را با استفاده از توکن دریافتی از هدر، استعلام می‌کند.
    /// </summary>
    [HttpGet("getMe")]
    public async Task<IActionResult> GetBotInfo([FromHeader(Name = "X-Bot-Token")] string botToken)
    {
        if (string.IsNullOrEmpty(botToken))
        {
            return BadRequest("توکن ربات در هدر 'X-Bot-Token' ارسال نشده است.");
        }

        try
        {
            // ۱. ساخت کلاینت با توکن کاربر
            IBaleBotClient botClient = _baleBotFactory.CreateClient(botToken);

            // ۲. استفاده از کلاینت ساخته‌شده
            var response = await botClient.GetMeAsync();
            
            if (response.Ok)
            {
                return Ok(response.Result);
            }
            // مدیریت خطایی که از سمت API بله گزارش شده است
            return BadRequest(new { Error = response.Description });
        }
        catch (BaleApiException ex)
        {
            // مدیریت خطاهای شبکه یا ساختاری
            return StatusCode((int)ex.StatusCode, new { Error = ex.Message, Details = ex.ErrorContent });
        }
    }

    /// <summary>
    /// یک پیام "سلام دنیا" به چت مشخص شده ارسال می‌کند.
    /// </summary>
    [HttpPost("sendMessage")]
    public async Task<IActionResult> SendHelloMessage(
        [FromHeader(Name = "X-Bot-Token")] string botToken,
        [FromQuery] string chatId)
    {
        try
        {
            IBaleBotClient botClient = _baleBotFactory.CreateClient(botToken);
            var response = await botClient.SendMessageAsync(chatId, "سلام دنیا از طرف ربات!");

            if (response.Ok)
            {
                return Ok(response.Result);
            }
            return BadRequest(new { Error = response.Description });
        }
        catch (BaleApiException ex)
        {
            return StatusCode((int)ex.StatusCode, new { Error = ex.Message, Details = ex.ErrorContent });
        }
    }
}
```

## 🤝 مشارکت

از هرگونه مشارکت در این پروژه استقبال می‌شود. لطفاً برای گزارش باگ یا ارائه پیشنهاد، یک Issue جدید در مخزن گیت‌هاب پروژه ثبت کنید.

## 📄 لایسنس

این پروژه تحت لایسنس MIT منتشر شده است.