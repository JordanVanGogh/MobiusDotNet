using System;
using System.Threading.Tasks;
using MobiusDotNet.Resources;
using MobiusDotNet.Resources.Tokens;
using MobiusDotNet.Resources.Tokens.Parameters;
using MobiusDotNet.Resources.Tokens.Responses;
using Xunit;

namespace MobiusDotNet.Tests.Resources.Tokens
{
    public class RegisterTokenTests : ResourceTestsBase
    {
        [Fact]
        public void RegistersToken()
        {
            Guid UID = Guid.NewGuid();
            const TokenType tokenType = TokenType.Stellar;
            const string name = @"Augur";
            const string symbol = @"REP";
            const string issuer = @"0xE94327D07Fc17907b4DB788E5aDf2ed424adDff6";

            var testHttpClient = StartWebHostWithFixedResponse(GetPath("tokens", "register"), 200, new RegisterTokenResponse
            {
                UID = UID,
                TokenType = tokenType,
                Name = name,
                Symbol = symbol,
                Issuer = issuer
            });

            var mobius = new Mobius(testHttpClient, GetConnectionInfo());
            var response = mobius.Tokens.RegisterToken(new RegisterTokenParameters
            {
                TokenType = tokenType,
                Issuer = issuer,
                Name = name,
                Symbol = symbol
            });

            Assert.NotNull(response);
            Assert.Equal(UID, response.UID);
            Assert.Equal(tokenType, response.TokenType);
            Assert.Equal(name, response.Name);
            Assert.Equal(symbol, response.Symbol);
            Assert.Equal(issuer, response.Issuer);
        }

        [Fact]
        public async void RegistersTokenAsync()
        {
            Guid UID = Guid.NewGuid();
            const TokenType tokenType = TokenType.Stellar;
            const string name = @"Augur";
            const string symbol = @"REP";
            const string issuer = @"0xE94327D07Fc17907b4DB788E5aDf2ed424adDff6";

            var testHttpClient = StartWebHostWithFixedResponse(GetPath("tokens", "register"), 200, new RegisterTokenResponse
            {
                UID = UID,
                TokenType = tokenType,
                Name = name,
                Symbol = symbol,
                Issuer = issuer
            });

            var mobius = new Mobius(testHttpClient, GetConnectionInfo());
            var response = await mobius.Tokens.RegisterTokenAsync(new RegisterTokenParameters
            {
                TokenType = tokenType,
                Issuer = issuer,
                Name = name,
                Symbol = symbol
            });

            Assert.NotNull(response);
            Assert.Equal(UID, response.UID);
            Assert.Equal(tokenType, response.TokenType);
            Assert.Equal(name, response.Name);
            Assert.Equal(symbol, response.Symbol);
            Assert.Equal(issuer, response.Issuer);
        }

        [Fact]
        public void ThrowsExceptionOnErrorResponse()
        {
            var testHttpClient = StartWebHostWithFixedResponse(GetPath("tokens", "register"), 400, new ErrorResponse
            {
                Error = new ErrorResponse.ErrorContainer
                {
                    Message = "Parameters are incorrect"
                }
            });

            var mobius = new Mobius(testHttpClient, GetConnectionInfo());
            Action act = () => mobius.Tokens.RegisterToken(new RegisterTokenParameters
            {
                TokenType = TokenType.Erc20,
                Issuer = "Test Corp",
                Name = "TEST",
                Symbol = "TST"
            });
            Assert.Throws<MobiusException>(act);
        }

        [Fact]
        public async void ThrowsExceptionOnErrorResponseAsync()
        {
            var testHttpClient = StartWebHostWithFixedResponse(GetPath("tokens", "register"), 400, new ErrorResponse
            {
                Error = new ErrorResponse.ErrorContainer
                {
                    Message = "Parameters are incorrect"
                }
            });

            var mobius = new Mobius(testHttpClient, GetConnectionInfo());
            Func<Task> func = () => mobius.Tokens.RegisterTokenAsync(new RegisterTokenParameters
            {
                TokenType = TokenType.Erc20,
                Issuer = "Test Corp",
                Name = "TEST",
                Symbol = "TST"
            });
            await Assert.ThrowsAsync<MobiusException>(func);
        }
    }
}
