# Unofficial Mobius .NET Core (C#) API Client

Unofficial community backed Mobius API client for the cross-platform open source .NET Core 2.0. Strongly typed and async / awaitable. Provides ease of access to the Mobius API for .NET Core developers.

**Please note:**
the .NET Framework, Mono and Xamarin runtimes are currently not supported as of yet. This is because their HttpClient class implementation doesn't support GET requests with a body/payload, which is a requirement when using the Mobius API. I'm working on creating a separate version of MobiusDotNet for those with an alternate http client package.

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

### Async vs sync/blocking

Every API method comes in two flavors: async and sync/blocking. Which to use is up to the developer. All async methods are suffixed with "Async", and they are definitely the way forward in .NET. You can use them in conjunction with the async/await keywords.

Async:
```csharp
try
{
    var appUID = Guid.Parse("7949c369-6db7-4313-bef8-08e94d166de5");
    var email = "mail@example.com";

    var balance = await mobius.AppStore
        .GetBalanceAsync(new BalanceRequest
        {
            AppUID = appUID,
            Email = email
        });
    if (balance.NumberOfCredits > 0)
    {
        await mobius.AppStore
            .UseAsync(new UseRequest
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
        .GetBalance(new BalanceRequest
        {
            AppUID = appUID,
            Email = email
        });
    if (balance.NumberOfCredits > 0)
    {
        mobius.AppStore
            .Use(new UseRequest
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

**App Store > Balance:** get the balance of credits for a specified app and user (specified by email):
```csharp
var balance = await mobius.AppStore
    .GetBalanceAsync(new BalanceRequest
    {
        AppUID = Guid.Parse("7949c369-6db7-4313-bef8-08e94d166de5"),
        Email = "mail@example.com"
    });
```

**App Store > Use:** use credits on specified app for user (specified by email):
```csharp
var balance = await mobius.AppStore
    .UseAsync(new UseRequest
    {
        AppUID = Guid.Parse("7949c369-6db7-4313-bef8-08e94d166de5"),
        Email = "mail@example.com",
        NumberOfCredits = 1
    });
```

**Tokens > Register token:** register a token so you can use it with the other Tokens API calls:
```csharp
var registeredToken = await mobius.Tokens
    .RegisterTokenAsync(new RegisterTokenRequest
    {
        TokenType = TokenType.Erc20,
        Name = "Augur",
        Symbol = "REP",
        Issuer = "0xE94327D07Fc17907b4DB788E5aDf2ed424adDff6"
    });
```

**Tokens > Create address:** create an address for the token specified by TokenUID:
```csharp
var createdAddress = await mobius.Tokens
    .CreateAddressAsync(new CreateAddressRequest
    {
        TokenUID = Guid.Parse("e562be31-da3f-4f11-946f-ba340df995b9")
    });
```

**Tokens > Register address:** register an address for the token specified by TokenUID. Registered addresses, like created addresses, are monitored for incoming transfers of the token specified via TokenUID. When new tokens are transferred into the address, you are alerted via the token/transfer webhook callback:
```csharp
var registeredAddress = await mobius.Tokens
    .RegisterAddressAsync(new RegisterAddressRequest
    {
        TokenUID = Guid.Parse("e562be31-da3f-4f11-946f-ba340df995b9"),
        Address = "0xe89bb230b39f11e9c870e3115b9e0f569952a2fd"
    });
```

**Tokens > Get address balance:** query the number of tokens specified by the token with TokenUID that address has:
```csharp
var addressBalance = await mobius.Tokens
    .GetAddressBalanceAsync(new AddressBalanceRequest
    {
        TokenUID = Guid.Parse("4dd4341a-493a-4bf9-b1c2-406a2336e58b"),
        Address = "0xe89bb230b39f11e9c870e3115b9e0f569952a2fd"
    });
```

**Tokens > Create transfer:** transfer tokens from a Mobius managed address to a specified address. You must have a high enough balance to cover the transaction fees — on Ethereum this means paying the gas costs. Currently Mobius does not charge any fees itself:
```csharp
var transfered = await mobius.Tokens
    .TransferManagedAsync(new TransferManagedRequest
    {
        TokenAddressUID = Guid.Parse("d1df1ba7-261b-4af9-9a1a-f49ae641aa7a"),
        AddressTo = "0xe89bb230b39f11e9c870e3115b9e0f569952a2fd",
        NumberOfTokens = 200
    });
```

**Tokens > Get transfer info:** get the status and transaction hash of a Mobius managed token transfer:
```csharp
var transferInfo = await mobius.Tokens
    .GetTransferInfoAsync(new TransferInfoRequest
    {
        TokenAddressTransferUID = Guid.Parse("f8a32950-7a24-493f-a6d2-02d255f746b6")
    });
```

## More information

See the [REST API docs](https://mobius.network/docs/)

## Development

Integration tests with an embedded test web server are provided for each of the API methods. You can run them directly from within most IDE's (such as Visual Studio), or you can use the xunit console runner.