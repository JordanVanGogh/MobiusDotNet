using System.Net.Http;
using System.Threading.Tasks;
using MobiusDotNet.Resources.AppStore.Requests;
using MobiusDotNet.Resources.AppStore.Responses;

namespace MobiusDotNet.Resources.AppStore
{
    /// <summary>
    ///     The client for App Store resource request.
    /// </summary>
    public class AppStoreClient : ClientBase
    {
        /// <inheritdoc />
        protected override string ResourceName => @"app_store";

        /// <inheritdoc />
        internal AppStoreClient(HttpClient httpClient, MobiusConnectionInfo connectionInfo = null) : base(httpClient, connectionInfo)
        {
        }

        /// <summary>
        ///     Gets the current balance.
        /// </summary>
        /// <param name="request">The request.</param>
        /// <returns>The response that was returned by the API.</returns>
        public BalanceResponse GetBalance(BalanceRequest request)
        {
            return Get<BalanceRequest, BalanceResponse>(@"balance", request);
        }

        /// <summary>
        ///     Gets the current balance.
        /// </summary>
        /// <param name="request">The request.</param>
        /// <returns>The response that was returned by the API.</returns>
        public Task<BalanceResponse> GetBalanceAsync(BalanceRequest request)
        {
            return GetAsync<BalanceRequest, BalanceResponse>(@"balance", request);
        }

        /// <summary>
        ///     Use some of the current balance.
        /// </summary>
        /// <param name="request">The request.</param>
        /// <returns>The response that was returned by the API.</returns>
        public UseResponse Use(UseRequest request)
        {
            return Post<UseRequest, UseResponse>(@"use", request);
        }
        
        /// <summary>
        ///     Use some of the current balance.
        /// </summary>
        /// <param name="request">The request.</param>
        /// <returns>The response that was returned by the API.</returns>
        public Task<UseResponse> UseAsync(UseRequest request)
        {
            return PostAsync<UseRequest, UseResponse>(@"use", request);
        }
    }
}
