
-----

# Mohammad.Bale.Bot.Client

[](https://www.google.com/search?q=https://www.nuget.org/packages/Mohammad.Bale.Bot.Client/)

**لینک گیت‌هاب:** [https://github.com/mamadgit1376/Bale.API.Client](https://github.com/mamadgit1376/Bale.API.Client)

یک کلاینت دات‌نت ساده، مدرن و قدرتمند برای کار با **API بازوی پیام‌رسان بله**. این کتابخانه تمام پیچیدگی‌های ارسال درخواست‌های HTTP را پنهان کرده و به شما اجازه می‌دهد تا به راحتی با متدها و مدل‌های کاملاً تایپ‌شده (Strongly-typed) با سرورهای بله تعامل داشته باشید.

## 🚀 ویژگی‌ها

  - **کاملاً غیرهمزمان (Async):** تمام متدها به صورت `async/await` پیاده‌سازی شده‌اند.
  - **پشتیبانی کامل از API:** تمام متدهای اصلی مستندات رسمی بازوی بله را پوشش می‌دهد.
  - **مدل‌های Strongly-Typed:** تمام آبجکت‌های API (مانند `Message`, `Update`, `Chat`) به صورت کلاس‌های C\# مدل‌سازی شده‌اند.
  - **راه‌اندازی آسان:** با استفاده از یک متد کمکی (Extension Method) به راحتی در سیستم تزریق وابستگی (Dependency Injection) پروژه‌های ASP.NET Core ثبت می‌شود.
  - **مدیریت بهینه HttpClient:** با بهره‌گیری از `IHttpClientFactory` برای مدیریت بهینه ارتباطات.
  - **URL قابل تنظیم (Configurable URL):** امکان تغییر آدرس پایه API برای سازگاری با محیط‌های مختلف یا آپدیت‌های آینده.
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

استفاده از این کتابخانه در یک پروژه ASP.NET Core بسیار ساده است.

### ۱. پیکربندی `appsettings.json`

ابتدا توکن ربات خود را در فایل `appsettings.json` قرار دهید.

```json
{
  "BaleBotSettings": {
    "BotToken": "YOUR_UNIQUE_BOT_TOKEN_FROM_BOTFATHER"
  }
}
```

### ۲. ثبت سرویس در `Program.cs`

سپس، با استفاده از متد کمکی `AddBaleBotClient`، سرویس را در `Program.cs` ثبت کنید.

```csharp
// using مربوط به کتابخانه را اضافه کنید
using Bale.API.Client; 

var builder = WebApplication.CreateBuilder(args);

// ... سایر سرویس‌ها

// ثبت کلاینت ربات بله (روش استاندارد)
builder.Services.AddBaleBotClient(options =>
{
    // خواندن توکن از appsettings.json
    options.BotToken = builder.Configuration["BaleBotSettings:BotToken"];

    // (اختیاری) در صورت نیاز می‌توانید آدرس پایه API را تغییر دهید
    // options.BaseUrl = "https://new.api.bale.ai/"; 
});

var app = builder.Build();

// ...
```

### ۳. استفاده در کنترلر

حالا می‌توانید اینترفیس `IBaleBotClient` را به هر کنترلر یا سرویسی تزریق کرده و از متدهای آن استفاده کنید.

```csharp
using Bale.API.Client.Interfaces;
using Bale.API.Client.Models;
using Bale.API.Client.Exceptions;
using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("api/[controller]")]
public class BotController : ControllerBase
{
    private readonly IBaleBotClient _baleClient;

    public BotController(IBaleBotClient baleClient)
    {
        _baleClient = baleClient;
    }

    /// <summary>
    /// اطلاعات ربات را برای تست ارتباط دریافت می‌کند.
    /// </summary>
    [HttpGet("me")]
    public async Task<IActionResult> GetMe()
    {
        try
        {
            var response = await _baleClient.GetMeAsync();
            if (response.Ok)
            {
                return Ok(response.Result);
            }
            return BadRequest(response.Description);
        }
        catch (BaleApiException ex)
        {
            return StatusCode((int)ex.StatusCode, new { Error = ex.Message, Details = ex.ErrorContent });
        }
    }

    /// <summary>
    /// یک پیام "سلام دنیا" به چت مشخص شده ارسال می‌کند.
    /// </summary>
    [HttpPost("send-hello")]
    public async Task<IActionResult> SendHelloMessage([FromQuery] string chatId)
    {
        try
        {
            var response = await _baleClient.SendMessageAsync(chatId, "سلام دنیا از طرف ربات!");
            if (response.Ok)
            {
                return Ok(response.Result);
            }
            return BadRequest(response.Description);
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