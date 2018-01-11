using System;
using System.Threading.Tasks;
using MobiusDotNet.Resources;
using MobiusDotNet.Resources.Tokens;
using MobiusDotNet.Resources.Tokens.Requests;
using MobiusDotNet.Resources.Tokens.Responses;
using Xunit;

namespace MobiusDotNet.Tests.Resources.Tokens
{
    public class AddressBalanceTests : ResourceTestsBase
    {
        [Fact]
        public void GetsAddressBalance()
        {
            Guid tokenUID = Guid.NewGuid();
            const string address = @"0xE94327D07Fc17907b4DB788E5aDf2ed424adDff6";
            const decimal balance = 31.531687M;
            const TokenType tokenType = TokenType.Stellar;
            const string name = "Augur";
            const string symbol = "REP";
            const string issuer = "0xE94327D07Fc17907b4DB788E5aDf2ed424adDff6";
            
            var testHttpClient = StartTestHostWithFixedResponse(GetPath("tokens", "balance"), 200, new AddressBalanceResponse
            {
                Address = address,
                Balance = balance,
                Token = new AddressBalanceResponse.TokenContainer
                {
                    TokenType = tokenType,
                    Name = name,
                    Symbol = symbol,
                    Issuer = issuer
                }
            });

            var mobius = new Mobius(testHttpClient, GetConnectionInfo());
            var response = mobius.Tokens.GetAddressBalance(new AddressBalanceRequest
            {
                TokenUID = tokenUID,
                Address = address
            });

            Assert.NotNull(response);
            Assert.Equal(address, response.Address);
            Assert.Equal(balance, response.Balance);
            Assert.Equal(tokenType, response.Token.TokenType);
            Assert.Equal(name, response.Token.Name);
            Assert.Equal(symbol, response.Token.Symbol);
            Assert.Equal(issuer, response.Token.Issuer);
        }

        [Fact]
        public async void GetsAddressBalanceAsync()
        {
            Guid tokenUID = Guid.NewGuid();
            const string address = @"0xE94327D07Fc17907b4DB788E5aDf2ed424adDff6";
            const decimal balance = 31.531687M;
            const TokenType tokenType = TokenType.Stellar;
            const string name = "Augur";
            const string symbol = "REP";
            const string issuer = "0xE94327D07Fc17907b4DB788E5aDf2ed424adDff6";

            var testHttpClient = StartTestHostWithFixedResponse(GetPath("tokens", "balance"), 200, new AddressBalanceResponse
            {
                Address = address,
                Balance = balance,
                Token = new AddressBalanceResponse.TokenContainer
                {
                    TokenType = tokenType,
                    Name = name,
                    Symbol = symbol,
                    Issuer = issuer
                }
            });

            var mobius = new Mobius(testHttpClient, GetConnectionInfo());
            var response = await mobius.Tokens.GetAddressBalanceAsync(new AddressBalanceRequest
            {
                TokenUID = tokenUID,
                Address = address
            });

            Assert.NotNull(response);
            Assert.Equal(address, response.Address);
            Assert.Equal(balance, response.Balance);
            Assert.Equal(tokenType, response.Token.TokenType);
            Assert.Equal(name, response.Token.Name);
            Assert.Equal(symbol, response.Token.Symbol);
            Assert.Equal(issuer, response.Token.Issuer);
        }


        [Fact]
        public void ThrowsExceptionOnErrorResponse()
        {
            Guid tokenUID = Guid.NewGuid();
            const string address = @"0xE94327D07Fc17907b4DB788E5aDf2ed424adDff6";

            var testHttpClient = StartTestHostWithFixedResponse(GetPath("tokens", "balance"), 400, new ErrorResponse
            {
                Error = new ErrorResponse.ErrorContainer
                {
                    Message = "Parameters are incorrect"
                }
            });

            var mobius = new Mobius(testHttpClient, GetConnectionInfo());
            Action act = () => mobius.Tokens.RegisterAddress(new RegisterAddressRequest
            {
                TokenUID = tokenUID,
                Address = address
            });
            Assert.Throws<MobiusException>(act);
        }

        [Fact]
        public async void ThrowsExceptionOnErrorResponseAsync()
        {
            Guid tokenUID = Guid.NewGuid();
            const string address = @"0xE94327D07Fc17907b4DB788E5aDf2ed424adDff6";

            var testHttpClient = StartTestHostWithFixedResponse(GetPath("tokens", "balance"), 400, new ErrorResponse
            {
                Error = new ErrorResponse.ErrorContainer
                {
                    Message = "Parameters are incorrect"
                }
            });

            var mobius = new Mobius(testHttpClient, GetConnectionInfo());
            Func<Task> func = () => mobius.Tokens.RegisterAddressAsync(new RegisterAddressRequest
            {
                TokenUID = tokenUID,
                Address = address
            });
            await Assert.ThrowsAsync<MobiusException>(func);
        }
    }
}
