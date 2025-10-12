# Mohammad.Bale.Bot.Client

GitHub:
https://github.com/mamadgit1376/Bale.API.Client

یک کلاینت دات‌نت ساده، مدرن و قدرتمند برای کار با **API بازوی پیام‌رسان بله**. این کتابخانه تمام پیچیدگی‌های ارسال درخواست‌های HTTP را پنهان کرده و به شما اجازه می‌دهد تا به راحتی با متدها و مدل‌های کاملاً تایپ‌شده (Strongly-typed) با سرورهای بله تعامل داشته باشید.

## 🚀 ویژگی‌ها

  - **کاملاً غیرهمزمان (Async):** تمام متدها به صورت `async/await` پیاده‌سازی شده‌اند.
  - **پشتیبانی کامل از API:** تمام متدهای اصلی مستندات رسمی بازوی بله را پوشش می‌دهد.
  - **مدل‌های Strongly-Typed:** تمام آبجکت‌های API (مانند `Message`, `Update`, `Chat`) به صورت کلاس‌های C\# مدل‌سازی شده‌اند.
  - **راه‌اندازی آسان:** با استفاده از یک متد کمکی (Extension Method) به راحتی در سیستم تزریق وابستگی (Dependency Injection) پروژه‌های ASP.NET Core ثبت می‌شود.
  - **مدیریت بهینه HttpClient:** با بهره‌گیری از `IHttpClientFactory` برای مدیریت بهینه ارتباطات و جلوگیری از خطاهای رایج.
  - **بدون وابستگی اضافی:** بسیار سبک و با حداقل وابستگی‌ها.

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

ابتدا توکن ربات خود را که از `@BotFather` دریافت کرده‌اید، در فایل `appsettings.json` قرار دهید.

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
using Bale.Bot.Client; // using مربوط به کتابخانه را اضافه کنید

var builder = WebApplication.CreateBuilder(args);

// ... سایر سرویس‌ها

// ثبت کلاینت ربات بله
builder.Services.AddBaleBotClient(options =>
{
    options.BotToken = builder.Configuration["BaleBotSettings:BotToken"];
});

var app = builder.Build();

// ...
```

### ۳. استفاده در کنترلر

حالا می‌توانید اینترفیس `IBaleBotClient` را به هر کنترلر یا سرویسی تزریق کرده و از متدهای آن استفاده کنید.

```csharp
using Bale.Bot.Client.Interfaces;
using Bale.Bot.Client.Models; // برای دسترسی به مدل‌ها
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
            return Ok(response.Result);
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
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
            return Ok(response.Result);
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }
}
```

## مثال‌های بیشتر

### ارسال پیام همراه با کیبورد شیشه‌ای (Inline Keyboard)

```csharp
[HttpPost("send-with-keyboard")]
public async Task<IActionResult> SendMessageWithKeyboard([FromQuery] string chatId)
{
    var inlineKeyboard = new InlineKeyboardMarkup
    {
        InlineKeyboard = new[]
        {
            // ردیف اول
            new[]
            {
                new InlineKeyboardButton { Text = "گوگل", Url = "https://google.com" },
                new InlineKeyboardButton { Text = "کلیک کن!", CallbackData = "button1_clicked" }
            },
            // ردیف دوم
            new[]
            {
                new InlineKeyboardButton { Text = "اطلاعات بیشتر", CallbackData = "show_more_info" }
            }
        }
    };

    try
    {
        await _baleClient.SendMessageAsync(chatId, "یک گزینه را انتخاب کنید:", replyMarkup: inlineKeyboard);
        return Ok("پیام با کیبورد ارسال شد.");
    }
    catch (Exception ex)
    {
        return BadRequest(ex.Message);
    }
}
```

### مدیریت خطاها

این کتابخانه در صورت بروز خطا از سمت API بله، یک استثنا از نوع `BaleApiException` پرتاب می‌کند که می‌توانید آن را برای مدیریت بهتر خطاها `catch` کنید.

```csharp
using Bale.Bot.Client.Exceptions;

// ...

[HttpGet("me-safe")]
public async Task<IActionResult> GetMeSafely()
{
    try
    {
        var response = await _baleClient.GetMeAsync();
        return Ok(response.Result);
    }
    catch (BaleApiException ex)
    {
        // خطاهای مشخص از سمت API بله (مانند توکن نامعتبر)
        return StatusCode((int)ex.StatusCode, new { message = ex.Message, details = ex.ErrorContent });
    }
    catch (HttpRequestException ex)
    {
        // خطاهای کلی شبکه
        return StatusCode(503, "سرویس بله در دسترس نیست.");
    }
}
```

## 🤝 مشارکت

از هرگونه مشارکت در این پروژه استقبال می‌شود. لطفاً برای گزارش باگ یا ارائه پیشنهاد، یک Issue جدید در مخزن گیت‌هاب پروژه ثبت کنید.


