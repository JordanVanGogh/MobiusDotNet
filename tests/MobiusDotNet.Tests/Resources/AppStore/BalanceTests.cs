using System;
using System.Threading.Tasks;
using MobiusDotNet.Resources;
using MobiusDotNet.Resources.AppStore.Parameters;
using MobiusDotNet.Resources.AppStore.Responses;
using Xunit;

namespace MobiusDotNet.Tests.Resources.AppStore
{
    public class BalanceTests : ResourceTestsBase
    {
        [Fact]
        public void GetsBalance()
        {
            int numberOfCredits = 500;

            var testHttpClient = StartWebHostWithFixedResponse(GetPath("app_store", "balance"), 200, new BalanceResponse
            {
                NumberOfCredits = numberOfCredits
            });

            var mobius = new Mobius(testHttpClient, GetConnectionInfo());
            var balance = mobius.AppStore.GetBalance(new BalanceParameters
            {
                AppUID = Guid.NewGuid(),
                Email = "test@test.local"
            });

            Assert.NotNull(balance);
            Assert.Equal(numberOfCredits, balance.NumberOfCredits);
        }

        [Fact]
        public async void GetsBalanceAsync()
        {
            int numberOfCredits = 500;

            var testHttpClient = StartWebHostWithFixedResponse(GetPath("app_store", "balance"), 200, new BalanceResponse
            {
                NumberOfCredits = numberOfCredits
            });
            
            var mobius = new Mobius(testHttpClient, GetConnectionInfo());
            var balance = await mobius.AppStore.GetBalanceAsync(new BalanceParameters
            {
                AppUID = Guid.NewGuid(),
                Email = "test@test.local"
            });

            Assert.NotNull(balance);
            Assert.Equal(numberOfCredits, balance.NumberOfCredits);
        }

        [Fact]
        public void ThrowsExceptionOnErrorResponse()
        {
            var testHttpClient = StartWebHostWithFixedResponse(GetPath("app_store", "balance"), 400, new ErrorResponse
            {
                Error = new ErrorResponse.ErrorContainer
                {
                    Message = "Parameters are incorrect"
                }
            });

            var mobius = new Mobius(testHttpClient, GetConnectionInfo());
            Action getBalance = () => mobius.AppStore.GetBalance(new BalanceParameters
            {
                AppUID = Guid.NewGuid(),
                Email = "test@test.local"
            });
            Assert.Throws<MobiusException>(getBalance);
        }
        
        [Fact]
        public async void ThrowsExceptionOnErrorResponseAsync()
        {
            var testHttpClient = StartWebHostWithFixedResponse(GetPath("app_store", "balance"), 400, new ErrorResponse
            {
                Error = new ErrorResponse.ErrorContainer
                {
                    Message = "Parameters are incorrect"
                }
            });

            var mobius = new Mobius(testHttpClient, GetConnectionInfo());
            Func<Task> getBalance = () => mobius.AppStore.GetBalanceAsync(new BalanceParameters
            {
                AppUID = Guid.NewGuid(),
                Email = "test@test.local"
            });
            await Assert.ThrowsAsync<MobiusException>(getBalance);
        }
    }
}
