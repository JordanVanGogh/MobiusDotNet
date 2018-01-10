using System.Net.Http;
using System.Threading.Tasks;
using MobiusDotNet.Resources.AppStore.Parameters;
using MobiusDotNet.Resources.AppStore.Responses;

namespace MobiusDotNet.Resources.AppStore
{
    /// <summary>
    ///     The client for App Store resource requests.
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
        /// <param name="parameters">The parameters.</param>
        /// <returns>The response that was returned by the API.</returns>
        public BalanceResponse GetBalance(BalanceParameters parameters)
        {
            return Get<BalanceParameters, BalanceResponse>(@"balance", parameters);
        }

        /// <summary>
        ///     Gets the current balance.
        /// </summary>
        /// <param name="parameters">The parameters.</param>
        /// <returns>The response that was returned by the API.</returns>
        public Task<BalanceResponse> GetBalanceAsync(BalanceParameters parameters)
        {
            return GetAsync<BalanceParameters, BalanceResponse>(@"balance", parameters);
        }

        /// <summary>
        ///     Use some of the current balance.
        /// </summary>
        /// <param name="parameters">The parameters.</param>
        /// <returns>The response that was returned by the API.</returns>
        public UseResponse Use(UseParameters parameters)
        {
            return Post<UseParameters, UseResponse>(@"use", parameters);
        }
        
        /// <summary>
        ///     Use some of the current balance.
        /// </summary>
        /// <param name="parameters">The parameters.</param>
        /// <returns>The response that was returned by the API.</returns>
        public Task<UseResponse> UseAsync(UseParameters parameters)
        {
            return PostAsync<UseParameters, UseResponse>(@"use", parameters);
        }
    }
}
