using System;
using System.Threading.Tasks;
using MobiusDotNet.Resources;
using MobiusDotNet.Resources.Tokens.Parameters;
using MobiusDotNet.Resources.Tokens.Responses;
using Xunit;

namespace MobiusDotNet.Tests.Resources.Tokens
{
    public class TransferManagedTests : ResourceTestsBase
    {
        [Fact]
        public void TransfersManaged()
        {
            Guid tokenAddressUID = Guid.NewGuid();
            const string addressTo = @"0xE94327D07Fc17907b4DB788E5aDf2ed424adDff6";
            decimal numberOfTokens = 20.233M;
            Guid tokenAddressTransferUID = Guid.NewGuid();

            var testHttpClient = StartWebHostWithFixedResponse(GetPath("tokens", "transfer/managed"), 200, new TransferManagedResponse
            {
                TokenAddressTransferUID = tokenAddressTransferUID
            });

            var mobius = new Mobius(testHttpClient, GetConnectionInfo());
            var response = mobius.Tokens.TransferManaged(new TransferManagedParameters
            {
                TokenAddressUID = tokenAddressUID,
                AddressTo = addressTo,
                NumberOfTokens = numberOfTokens
            });

            Assert.NotNull(response);
            Assert.Equal(tokenAddressTransferUID, response.TokenAddressTransferUID);
        }

        [Fact]
        public async void TransfersManagedAsync()
        {
            Guid tokenAddressUID = Guid.NewGuid();
            const string addressTo = @"0xE94327D07Fc17907b4DB788E5aDf2ed424adDff6";
            decimal numberOfTokens = 20.233M;
            Guid tokenAddressTransferUID = Guid.NewGuid();

            var testHttpClient = StartWebHostWithFixedResponse(GetPath("tokens", "transfer/managed"), 200, new TransferManagedResponse
            {
                TokenAddressTransferUID = tokenAddressTransferUID
            });

            var mobius = new Mobius(testHttpClient, GetConnectionInfo());
            var response = await mobius.Tokens.TransferManagedAsync(new TransferManagedParameters
            {
                TokenAddressUID = tokenAddressUID,
                AddressTo = addressTo,
                NumberOfTokens = numberOfTokens
            });

            Assert.NotNull(response);
            Assert.Equal(tokenAddressTransferUID, response.TokenAddressTransferUID);
        }

        [Fact]
        public void ThrowsExceptionOnErrorResponse()
        {
            Guid tokenAddressUID = Guid.NewGuid();
            const string addressTo = @"0xE94327D07Fc17907b4DB788E5aDf2ed424adDff6";
            decimal numberOfTokens = 20.233M;

            var testHttpClient = StartWebHostWithFixedResponse(GetPath("tokens", "transfer/managed"), 400, new ErrorResponse
            {
                Error = new ErrorResponse.ErrorContainer
                {
                    Message = "Parameters are incorrect"
                }
            });

            var mobius = new Mobius(testHttpClient, GetConnectionInfo());
            Action act = () => mobius.Tokens.TransferManaged(new TransferManagedParameters
            {
                TokenAddressUID = tokenAddressUID,
                AddressTo = addressTo,
                NumberOfTokens = numberOfTokens
            });
            Assert.Throws<MobiusException>(act);
        }

        [Fact]
        public async void ThrowsExceptionOnErrorResponseAsync()
        {
            Guid tokenAddressUID = Guid.NewGuid();
            const string addressTo = @"0xE94327D07Fc17907b4DB788E5aDf2ed424adDff6";
            decimal numberOfTokens = 20.233M;

            var testHttpClient = StartWebHostWithFixedResponse(GetPath("tokens", "transfer/managed"), 400, new ErrorResponse
            {
                Error = new ErrorResponse.ErrorContainer
                {
                    Message = "Parameters are incorrect"
                }
            });

            var mobius = new Mobius(testHttpClient, GetConnectionInfo());
            Func<Task> func = () => mobius.Tokens.TransferManagedAsync(new TransferManagedParameters
            {
                TokenAddressUID = tokenAddressUID,
                AddressTo = addressTo,
                NumberOfTokens = numberOfTokens
            });
            await Assert.ThrowsAsync<MobiusException>(func);
        }
    }
}
