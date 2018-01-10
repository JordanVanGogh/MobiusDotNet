using System;
using System.Threading.Tasks;
using MobiusDotNet.Resources;
using MobiusDotNet.Resources.Tokens;
using MobiusDotNet.Resources.Tokens.Parameters;
using MobiusDotNet.Resources.Tokens.Reponses;
using Xunit;

namespace MobiusDotNet.Tests.Resources.Tokens
{
    public class TransferInfoTests : ResourceTestsBase
    {
        [Fact]
        public void GetsTransferInfo()
        {
            Guid tokenAddressTransferUID = Guid.NewGuid();
            Guid UID = Guid.NewGuid();
            TransferStatus status = TransferStatus.Complete;
            string transactionHash = "asdujasd32409892345893485";

            var testHttpClient = StartWebHostWithFixedResponse(GetPath("tokens", "transfer/info"), 200, new TransferInfoResponse
            {
                UID = UID,
                Status = status,
                TransactionHash = transactionHash
            });

            var mobius = new Mobius(testHttpClient, GetConnectionInfo());
            var response = mobius.Tokens.GetTransferInfo(new TransferInfoParameters
            {
                TokenAddressTransferUID = tokenAddressTransferUID
            });

            Assert.NotNull(response);
            Assert.Equal(UID, response.UID);
            Assert.Equal(status, response.Status);
            Assert.Equal(transactionHash, response.TransactionHash);
        }

        [Fact]
        public async void GetsTransferInfoAsync()
        {
            Guid tokenAddressTransferUID = Guid.NewGuid();
            Guid UID = Guid.NewGuid();
            TransferStatus status = TransferStatus.Complete;
            string transactionHash = "asdujasd32409892345893485";

            var testHttpClient = StartWebHostWithFixedResponse(GetPath("tokens", "transfer/info"), 200, new TransferInfoResponse
            {
                UID = UID,
                Status = status,
                TransactionHash = transactionHash
            });

            var mobius = new Mobius(testHttpClient, GetConnectionInfo());
            var response = await mobius.Tokens.GetTransferInfoAsync(new TransferInfoParameters
            {
                TokenAddressTransferUID = tokenAddressTransferUID
            });

            Assert.NotNull(response);
            Assert.Equal(UID, response.UID);
            Assert.Equal(status, response.Status);
            Assert.Equal(transactionHash, response.TransactionHash);
        }

        [Fact]
        public void ThrowsExceptionOnErrorResponse()
        {
            Guid tokenAddressTransferUID = Guid.NewGuid();

            var testHttpClient = StartWebHostWithFixedResponse(GetPath("tokens", "transfer/info"), 400, new ErrorResponse
            {
                Error = new ErrorResponse.ErrorContainer
                {
                    Message = "Parameters are incorrect"
                }
            });

            var mobius = new Mobius(testHttpClient, GetConnectionInfo());
            Action act = () => mobius.Tokens.GetTransferInfo(new TransferInfoParameters
            {
                TokenAddressTransferUID = tokenAddressTransferUID
            });
            Assert.Throws<MobiusException>(act);
        }

        [Fact]
        public async void ThrowsExceptionOnErrorResponseAsync()
        {
            Guid tokenAddressTransferUID = Guid.NewGuid();

            var testHttpClient = StartWebHostWithFixedResponse(GetPath("tokens", "transfer/info"), 400, new ErrorResponse
            {
                Error = new ErrorResponse.ErrorContainer
                {
                    Message = "Parameters are incorrect"
                }
            });

            var mobius = new Mobius(testHttpClient, GetConnectionInfo());
            Func<Task> func = () => mobius.Tokens.GetTransferInfoAsync(new TransferInfoParameters
            {
                TokenAddressTransferUID = tokenAddressTransferUID
            });
            await Assert.ThrowsAsync<MobiusException>(func);
        }
    }
}
