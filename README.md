```
# Bale.Bot.Client.Mr.Arbab

[](https://www.nuget.org/packages/Bale.Bot.Client.Mr.Arbab/)

**لینک گیت‌هاب:** [https://github.com/mamadgit1376/Bale.API.Client](https://github.com/mamadgit1376/Bale.API.Client)

یک کلاینت دات‌نت ساده، مدرن و قدرتمند برای کار با **API بازوی پیام‌رسان بله** و **سرویس سفیر بله**. این کتابخانه تمام پیچیدگی‌های ارسال درخواست‌های HTTP را پنهان کرده و به شما اجازه می‌دهد تا به راحتی با متدها و مدل‌های کاملاً تایپ‌شده (Strongly-typed) با سرورهای بله تعامل داشته باشید.

## 🚀 ویژگی‌ها

  - **کاملاً غیرهمزمان (Async):** تمام متدها به صورت `async/await` پیاده‌سازی شده‌اند.
  - **پشتیبانی از چند ربات:** با استفاده از الگوی Factory، می‌توانید به سادگی کلاینت‌هایی برای ربات‌های مختلف با توکن‌های متفاوت در لحظه ایجاد کنید.
  - **مدل‌های Strongly-Typed:** تمام آبجکت‌های API به صورت کلاس‌های C# مدل‌سازی شده‌اند.
  - **راه‌اندازی آسان:** با ثبت ساده سرویس‌ها در سیستم تزریق وابستگی (Dependency Injection).
  - **مدیریت بهینه HttpClient:** با بهره‌گیری از `IHttpClientFactory` برای مدیریت بهینه ارتباطات.
  - **مدیریت خطای ساختاریافته:** پرتاب استثنای سفارشی `BaleApiException` در صورت بروز خطا از سمت API بله.
  - **پشتیبانی از API ربات بله**
  - **پشتیبانی از سرویس سفیر بله** برای:
    - ارسال پیام تکی
    - ارسال پیام گروهی
    - آپلود فایل

## 🔧 نصب

شما می‌توانید این پکیج را از طریق NuGet Gallery به پروژه خود اضافه کنید.

**از طریق .NET CLI:**

```bash
dotnet add package Bale.Bot.Client.Mr.Arbab
```

**از طریق Package Manager Console:**

```powershell
Install-Package Bale.Bot.Client.Mr.Arbab
```

## 🏁 شروع سریع

این کتابخانه برای دو سناریوی اصلی مناسب است:

| سناریو | توضیح |
|--------|-------|
| API ربات بله | برای کار با توکن ربات و متدهایی مثل `SendMessageAsync` و `GetMeAsync` |
| سرویس سفیر | برای ارسال پیام به شماره موبایل، ارسال گروهی و آپلود فایل با `SafirAccessToken` |

## بخش اول: استفاده از کلاینت ربات بله

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

## بخش دوم: استفاده از SafirClient

`SafirClient` برای ارتباط با API سفیر بله طراحی شده و از `SafirAccessToken` استفاده می‌کند.

**آدرس پایه API سفیر:**

```text
https://safir.bale.ai/api/v3
```

### ۱. تنظیمات `appsettings.json`

برای استفاده از سفیر، باید `SafirAccessToken` را در تنظیمات پر��ژه تعریف کنید:

```json
{
  "BaleBotClientOptions": {
    "SafirAccessToken": "YOUR_SAFIR_ACCESS_TOKEN"
  }
}
```

### ۲. ثبت سرویس در `Program.cs`

```csharp
using Bale.API.Client;
using Bale.API.Client.Interface;
using Bale.API.Client.Models;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddHttpClient();

builder.Services.Configure<BaleBotClientOptions>(
    builder.Configuration.GetSection("BaleBotClientOptions"));

builder.Services.AddScoped<ISafirClient, SafirClient>();

var app = builder.Build();
```

### ۳. استفاده از `ISafirClient` در کنترلر

```csharp
using Bale.API.Client.Exceptions;
using Bale.API.Client.Interface;
using Bale.API.Client.Models;
using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("api/safir")]
public class SafirController : ControllerBase
{
    private readonly ISafirClient _safirClient;

    public SafirController(ISafirClient safirClient)
    {
        _safirClient = safirClient;
    }

    [HttpPost("send")]
    public async Task<IActionResult> SendMessage()
    {
        try
        {
            var messageData = new SafirMessageData
            {
                // مقداردهی مطابق مدل شما
            };

            var response = await _safirClient.SendSafirMessageAsync(
                botId: 12345,
                phoneNumber: "09123456789",
                safirMessageData: messageData,
                requestId: Guid.NewGuid().ToString());

            if (response.Ok)
            {
                return Ok(response);
            }

            return BadRequest(response);
        }
        catch (BaleApiException ex)
        {
            return StatusCode((int)ex.StatusCode, new
            {
                Error = ex.Message,
                Details = ex.ErrorContent
            });
        }
    }
}
```

### ۴. ارسال پیام تکی در سفیر

```csharp
var messageData = new SafirMessageData
{
    // مقداردهی مطابق مدل پروژه
};

var result = await _safirClient.SendSafirMessageAsync(
    botId: 12345,
    phoneNumber: "09123456789",
    safirMessageData: messageData,
    requestId: "req-001");
```

### ۵. ارسال گروهی در سفیر

```csharp
var messages = new List<BatchMessage>
{
    new BatchMessage
    {
        // phone_number = ...
        // message_data = ...
    },
    new BatchMessage
    {
        // phone_number = ...
        // message_data = ...
    }
};

var result = await _safirClient.SendGroupSafirMessagesAsync(
    botId: 12345,
    batchMessages: messages,
    requestId: "batch-001");
```

### ۶. آپلود فایل در سفیر

```csharp
using var stream = System.IO.File.OpenRead("sample.pdf");

var result = await _safirClient.UploadSafirFileAsync(
    fileStream: stream,
    fileName: "sample.pdf",
    contentType: "application/pdf");
```

## متدهای `SafirClient`

| متد | توضیح |
|--------|-------|
| `SendSafirMessageAsync` | ارسال پیام به یک شماره موبایل |
| `SendGroupSafirMessagesAsync` | ارسال گروهی پیام |
| `UploadSafirFileAsync` | آپلود فایل |

## پارامترهای متدهای سفیر

### `SendSafirMessageAsync`

| پارامتر | نوع | توضیح |
|--------|-----|-------|
| `botId` | `int` | شناسه ربات |
| `phoneNumber` | `string` | شمارهایل گیرنده |
| `safirMessageData` | `SafirMessageData` | محتوای پیام |
| `requestId` | `string?` | شناسه یکتای اختیاری برای رهگیری درخواست |

### `SendGroupSafirMessagesAsync`

| پارامتر | نوع | توضیح |
|--------|-----|-------|
| `botId` | `int` | شناسه ربات |
| `batchMessages` | `List<BatchMessage>` | لیست پیام‌ها برای ارسال |
| `requestId` | `string?` | شناسه یکتای اختیاری درخواست |

### `UploadSafirFileAsync`

| پارامتر | نوع | توضیح |
|--------|-----|-------|
| `fileStream` | `Stream` | استریم فایل |
| `fileName` | `string` | نام فایل |
| `contentType` | `string` | نوع فایل مانند `image/png` یا `application/pdf` |

## مدیریت خطاها

در این کتابخانه، خطاهای شبکه، خطاهای ساختاری و خطاهای برگشتی از API معمولاً با `BaleApiException` مدیریت می‌شوند.

```csharp
try
{
    var response = await _safirClient.UploadSafirFileAsync(stream, "file.pdf", "application/pdf");
}
catch (BaleApiException ex)
{
    Console.WriteLine($"StatusCode: {ex.StatusCode}");
    Console.WriteLine($"Message: {ex.Message}");
    Console.WriteLine($"Details: {ex.ErrorContent}");
}
```

## نکات مهم

| نکته | توضیح |
|--------|-------|
| `SafirAccessToken` | برای تمام متدهای سفیر الزامی است |
| `botId` | نباید صفر باشد |
| `phoneNumber` | نباید خالی باشد |
| `fileStream` | باید معتبر، قابل خواندن و باز باشد |
| `requestId` | اختیاری است اما برای رهگیری درخواست‌ها پیشنهاد می‌شود |

## ساختار کلی پروژه

| بخش | توضیح |
|--------|-------|
| `IBaleBotClient` | اینترفیس کلاینت ربات بله |
| `IBaleBotClientFactory` | فکتوری ساخت کلاینت برای توکن‌های مختلف |
| `ISafirClient` | اینترفیس سرویس سفیر |
| `BaleBotClientOptions` | تنظیمات مربوط به کلاینت |
| `BaleApiException` | استثنای سفارشی برای مدیریت خطاها |
| `Models` | مدل‌های درخواست و پاسخ |

## مثال ثبت همزمان BotClient و SafirClient

```csharp
using Bale.API.Client;
using Bale.API.Client.Factories;
using Bale.API.Client.Interface;
using Bale.API.Client.Models;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddHttpClient();

builder.Services.AddSingleton<IBaleBotClientFactory, BaleBotClientFactory>();

builder.Services.Configure<BaleBotClientOptions>(
    builder.Configuration.GetSection("BaleBotClientOptions"));

builder.Services.AddScoped<ISafirClient, SafirClient>();

var app = builder.Build();
```

## 🤝 مشارکت

از هرگونه مشارکت در این پروژه استقبال می‌شود. لطفاً برای گزارش باگ یا ارائه پیشنهاد، یک Issue جدید در مخزن گیت‌هاب پروژه ثبت کنید.

## 📄 لایسنس

این پروژه تحت لایسنس MIT منتشر شده است.
```