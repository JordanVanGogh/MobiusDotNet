# Unofficial Mobius .NET Core (C#) API Client

Unofficial community backed Mobius API client for .NET Core 2.0. Strongly typed and async & awaitable. Provides ease of access to the Mobius API for applications written in C#/.NET Core. 

**Important:**
The .NET Framework, Mono and Xamarin runtimes are currently not supported as of yet. This is because their HttpClient class implementation doesn't support GET requests with a body, which is a requirement when using the Mobius API. I'm working on creating a separate version of MobiusDotNet for those with an alternate http client package.

## Installation

There is a NuGet package available that you can install directly from within Visual Studio or JetBrains Rider. Optionally you could also use command line tools:

Install the package with `Package Manager`:
```
PM> Install-Package MobiusDotNet
```
or with `.NET CLI`
```
> dotnet add package MobiusDotNet
```

## Usage

You can start by importing the namespace on top of your C# code file(s):
```csharp
using MobiusDotNet;
```

The Mobius API client class needs to be initialized with an API key which you can get at the [Mobius DApp Store](https://mobius.network/store/developer). You can instantiate the API with the following lines of code:
```csharp
var connectionInfo = new MobiusConnectionInfo("YOUR_API_KEY");
var mobius = new Mobius(connectionInfo);
```

### Async & blocking

Every API method comes in two flavors: async and sync/blocking. All async methods are suffixed with "Async", and they are the way to go nowadays in .NET. You can use them in conjunction with the async/await keywords.

Async:
```csharp
try
{
    var appUID = Guid.Parse("7949c369-6db7-4313-bef8-08e94d166de5");
    var email = "mail@example.com";

    var balance = await mobius.AppStore
        .GetBalanceAsync(new BalanceParameters
        {
            AppUID = appUID,
            Email = email
        });
    if (balance.NumberOfCredits > 0)
    {
        await mobius.AppStore
            .UseAsync(new UseParameters
            {
                AppUID = appUID,
                Email = email,
                NumberOfCredits = 1
            });
    }
}
catch (MobiusException e)
{
    Console.WriteLine(e.ToString());
}
```

Sync/blocking:
```csharp
try
{
    var appUID = Guid.Parse("7949c369-6db7-4313-bef8-08e94d166de5");
    var email = "mail@example.com";

    var balance = mobius.AppStore
        .GetBalance(new BalanceParameters
        {
            AppUID = appUID,
            Email = email
        });
    if (balance.NumberOfCredits > 0)
    {
        mobius.AppStore
            .Use(new UseParameters
            {
                AppUID = appUID,
                Email = email,
                NumberOfCredits = 1
            });
    }
}
catch (MobiusException e)
{
    Console.WriteLine(e.ToString());
}
```


## Methods

**App Store > Balance:** Get the balance of credits for specified app & email:
```csharp
var appUID = Guid.Parse("7949c369-6db7-4313-bef8-08e94d166de5");
var email = "mail@example.com";

var balance = await mobius.AppStore
  .GetBalanceAsync(new BalanceParameters
  {
      AppUID = appUID,
      Email = email
  });
```

**App Store > Use:** use credits on specified app using user's email address:
```csharp
var result = await mobius.AppStore
  .UseAsync(new UseParameters
  {
      AppUID = appUID,
      Email = email,
      NumberOfCredits = 1
  });
```

## More information

See the [REST API docs](https://mobius.network/docs/)

## Development

Integration tests with an embedded webserver are provided for each of the API methods. You can run them directly from within most IDE's (such as Visual Studio), or you can use the xunit console runner.