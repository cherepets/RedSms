# RedSms
.Net client for redsms.ru HTTPS API

Supports only sending messages for now.
Usage:
```javascript
var client = new RedSmsClient("Login", "Sender", "ApiKey");
var message = new Message("79991234567", "Some text");
await client.SendAsync(message);
```

[Download from NuGet Gallery](https://www.nuget.org/packages/RedSms/ "Download from NuGet Gallery")

License: [WTFPL](http://www.wtfpl.net/txt/copying/ "WTFPL")
