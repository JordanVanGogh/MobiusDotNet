using System;
using System.Threading.Tasks;
using MobiusDotNet.Resources;
using MobiusDotNet.Resources.Tokens.Requests;
using MobiusDotNet.Resources.Tokens.Responses;
using Xunit;

namespace MobiusDotNet.Tests.Resources.Tokens
{
    public class RegisterAddressTests : ResourceTestsBase
    {
        [Fact]
        public void RegistersAddress()
        {
            Guid tokenUID = Guid.NewGuid();
            const string address = @"0xE94327D07Fc17907b4DB788E5aDf2ed424adDff6";
            Guid UID = Guid.NewGuid();

            var testHttpClient = StartTestHostWithFixedResponse(GetPath("tokens", "register_address"), 200, new RegisterAddressResponse
            {
                UID = UID
            });

            var mobius = new Mobius(testHttpClient, GetConnectionInfo());
            var response = mobius.Tokens.RegisterAddress(new RegisterAddressRequest
            {
                TokenUID = tokenUID,
                Address = address
            });

            Assert.NotNull(response);
            Assert.Equal(UID, response.UID);
        }

        [Fact]
        public async void RegistersAddressAsync()
        {
            Guid tokenUID = Guid.NewGuid();
            const string address = @"0xE94327D07Fc17907b4DB788E5aDf2ed424adDff6";
            Guid UID = Guid.NewGuid();

            var testHttpClient = StartTestHostWithFixedResponse(GetPath("tokens", "register_address"), 200, new RegisterAddressResponse
            {
                UID = UID
            });

            var mobius = new Mobius(testHttpClient, GetConnectionInfo());
            var response = await mobius.Tokens.RegisterAddressAsync(new RegisterAddressRequest
            {
                TokenUID = tokenUID,
                Address = address
            });

            Assert.NotNull(response);
            Assert.Equal(UID, response.UID);
        }

        [Fact]
        public void ThrowsExceptionOnErrorResponse()
        {
            Guid tokenUID = Guid.NewGuid();
            const string address = @"0xE94327D07Fc17907b4DB788E5aDf2ed424adDff6";

            var testHttpClient = StartTestHostWithFixedResponse(GetPath("tokens", "register_address"), 400, new ErrorResponse
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

            var testHttpClient = StartTestHostWithFixedResponse(GetPath("tokens", "register_address"), 400, new ErrorResponse
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
