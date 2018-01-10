# Unofficial Mobius .NET (C# / Visual Basic) API Client

Unofficial community backed Mobius API client for modern .NET Framework, .NET Core, Mono and Xamarin. Strongly typed and async & awaitable. Provides ease of access to the Mobius API for web, mobile and desktop applications written in C#, Visual Basic, F#, Powershell or any other CLR language.

## Installation

There is a NuGet package available that you can install from Visual Studio, VSCode, JetBrains Rider or LinqPad. Optionally you could also use the NuGet command line tools to install it.

## Usage

You can start by importing the namespace on top of your code file:
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

Get the balance of credits for specified app & email:
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

Use credits on specified app using user's email address:
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