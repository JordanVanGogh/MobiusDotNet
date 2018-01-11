using System;
using System.Threading.Tasks;
using MobiusDotNet.Resources;
using MobiusDotNet.Resources.AppStore.Requests;
using MobiusDotNet.Resources.AppStore.Responses;
using Xunit;

namespace MobiusDotNet.Tests.Resources.AppStore
{
    public class UseTests : ResourceTestsBase
    {
        [Fact]
        public void Uses()
        {
            bool isSuccess = true;
            int numberOfCredits = 200;

            var testHttpClient = StartTestHostWithFixedResponse(GetPath("app_store", "use"), 200, new UseResponse
            {
                IsSuccess = isSuccess,
                NumberOfCredits = numberOfCredits
            });

            var mobius = new Mobius(testHttpClient, GetConnectionInfo());
            var response = mobius.AppStore.Use(new UseRequest
            {
                AppUID = Guid.NewGuid(),
                Email = "test@test.local",
                NumberOfCredits = 50
            });

            Assert.NotNull(response);
            Assert.Equal(isSuccess, response.IsSuccess);
            Assert.Equal(numberOfCredits, response.NumberOfCredits);
        }

        [Fact]
        public async void UsesAsync()
        {
            bool isSuccess = true;
            int numberOfCredits = 200;

            var testHttpClient = StartTestHostWithFixedResponse(GetPath("app_store", "use"), 200, new UseResponse
            {
                IsSuccess = isSuccess,
                NumberOfCredits = numberOfCredits
            });

            var mobius = new Mobius(testHttpClient, GetConnectionInfo());
            var response = await mobius.AppStore.UseAsync(new UseRequest
            {
                AppUID = Guid.NewGuid(),
                Email = "test@test.local",
                NumberOfCredits = 50
            });

            Assert.NotNull(response);
            Assert.Equal(isSuccess, response.IsSuccess);
            Assert.Equal(numberOfCredits, response.NumberOfCredits);
        }

        [Fact]
        public void ThrowsExceptionOnErrorResponse()
        {
            var testHttpClient = StartTestHostWithFixedResponse(GetPath("app_store", "use"), 400, new ErrorResponse
            {
                Error = new ErrorResponse.ErrorContainer
                {
                    Message = "Parameters are incorrect"
                }
            });

            var mobius = new Mobius(testHttpClient, GetConnectionInfo());
            Action act = () => mobius.AppStore.Use(new UseRequest
            {
                AppUID = Guid.NewGuid(),
                Email = "test@test.local",
                NumberOfCredits = 200
            });
            Assert.Throws<MobiusException>(act);
        }

        [Fact]
        public async void ThrowsExceptionOnErrorResponseAsync()
        {
            var testHttpClient = StartTestHostWithFixedResponse(GetPath("app_store", "use"), 400, new ErrorResponse
            {
                Error = new ErrorResponse.ErrorContainer
                {
                    Message = "Parameters are incorrect"
                }
            });

            var mobius = new Mobius(testHttpClient, GetConnectionInfo());
            Func<Task> func = () => mobius.AppStore.UseAsync(new UseRequest
            {
                AppUID = Guid.NewGuid(),
                Email = "test@test.local",
                NumberOfCredits = 200
            });
            await Assert.ThrowsAsync<MobiusException>(func);
        }
    }
}
