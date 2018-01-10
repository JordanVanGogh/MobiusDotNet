using System;
using System.Threading.Tasks;
using MobiusDotNet.Resources;
using MobiusDotNet.Resources.Tokens.Parameters;
using MobiusDotNet.Resources.Tokens.Responses;
using Xunit;

namespace MobiusDotNet.Tests.Resources.Tokens
{
    public class CreateAddressTests : ResourceTestsBase
    {
        [Fact]
        public void CreatesAddress()
        {
            Guid tokenUID = Guid.NewGuid();
            Guid UID = Guid.NewGuid();
            const string address = @"0xE94327D07Fc17907b4DB788E5aDf2ed424adDff6";

            var testHttpClient = StartWebHostWithFixedResponse(GetPath("tokens", "create_address"), 200, new CreateAddressResponse
            {
                UID = UID,
                Address = address
            });

            var mobius = new Mobius(testHttpClient, GetConnectionInfo());
            var response = mobius.Tokens.CreateAddress(new CreateAddressParameters
            {
                TokenUID = tokenUID
            });

            Assert.NotNull(response);
            Assert.Equal(UID, response.UID);
            Assert.Equal(address, response.Address);
        }

        [Fact]
        public async void CreatesAddressAsync()
        {
            Guid tokenUID = Guid.NewGuid();
            Guid UID = Guid.NewGuid();
            const string address = @"0xE94327D07Fc17907b4DB788E5aDf2ed424adDff6";

            var testHttpClient = StartWebHostWithFixedResponse(GetPath("tokens", "create_address"), 200, new CreateAddressResponse
            {
                UID = UID,
                Address = address
            });

            var mobius = new Mobius(testHttpClient, GetConnectionInfo());
            var response = await mobius.Tokens.CreateAddressAsync(new CreateAddressParameters
            {
                TokenUID = tokenUID
            });

            Assert.NotNull(response);
            Assert.Equal(UID, response.UID);
            Assert.Equal(address, response.Address);
        }

        [Fact]
        public void ThrowsExceptionOnErrorResponse()
        {
            Guid tokenUID = Guid.NewGuid();

            var testHttpClient = StartWebHostWithFixedResponse(GetPath("tokens", "create_address"), 400, new ErrorResponse
            {
                Error = new ErrorResponse.ErrorContainer
                {
                    Message = "Parameters are incorrect"
                }
            });

            var mobius = new Mobius(testHttpClient, GetConnectionInfo());
            Action act = () => mobius.Tokens.CreateAddress(new CreateAddressParameters
            {
                TokenUID = tokenUID
            });
            Assert.Throws<MobiusException>(act);
        }

        [Fact]
        public async void ThrowsExceptionOnErrorResponseAsync()
        {
            Guid tokenUID = Guid.NewGuid();

            var testHttpClient = StartWebHostWithFixedResponse(GetPath("tokens", "create_address"), 400, new ErrorResponse
            {
                Error = new ErrorResponse.ErrorContainer
                {
                    Message = "Parameters are incorrect"
                }
            });

            var mobius = new Mobius(testHttpClient, GetConnectionInfo());
            Func<Task> func = () => mobius.Tokens.CreateAddressAsync(new CreateAddressParameters
            {
                TokenUID = tokenUID
            });
            await Assert.ThrowsAsync<MobiusException>(func);
        }
    }
}
