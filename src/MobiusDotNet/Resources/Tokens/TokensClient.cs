using System.Net.Http;
using System.Threading.Tasks;
using MobiusDotNet.Resources.Tokens.Requests;
using MobiusDotNet.Resources.Tokens.Responses;

namespace MobiusDotNet.Resources.Tokens
{
    /// <summary>
    ///     The client for Tokens resource request.
    /// </summary>
    public class TokensClient : ClientBase
    {
        /// <inheritdoc />
        protected override string ResourceName => @"tokens";

        /// <inheritdoc />
        internal TokensClient(HttpClient httpClient, MobiusConnectionInfo connectionInfo = null) : base(httpClient, connectionInfo)
        {
        }

        /// <summary>
        ///     Register a token so you can use it with the other Token API calls.
        /// </summary>
        /// <param name="request">The request.</param>
        /// <returns>The response that was returned by the API.</returns>
        public RegisterTokenResponse RegisterToken(RegisterTokenRequest request)
        {
            return Post<RegisterTokenRequest, RegisterTokenResponse>(@"register", request);
        }

        /// <summary>
        ///     Register a token so you can use it with the other Token API calls.
        /// </summary>
        /// <param name="request">The request.</param>
        /// <returns>The response that was returned by the API.</returns>
        public Task<RegisterTokenResponse> RegisterTokenAsync(RegisterTokenRequest request)
        {
            return PostAsync<RegisterTokenRequest, RegisterTokenResponse>(@"register", request);
        }

        /// <summary>
        ///     Create an address for the token specified by TokenUID.
        /// </summary>
        /// <param name="request">The request.</param>
        /// <returns>The response that was returned by the API.</returns>
        public CreateAddressResponse CreateAddress(CreateAddressRequest request)
        {
            return Post<CreateAddressRequest, CreateAddressResponse>(@"create_address", request);
        }

        /// <summary>
        ///     Create an address for the token specified by TokenUID.
        /// </summary>
        /// <param name="request">The request.</param>
        /// <returns>The response that was returned by the API.</returns>
        public Task<CreateAddressResponse> CreateAddressAsync(CreateAddressRequest request)
        {
            return PostAsync<CreateAddressRequest, CreateAddressResponse>(@"create_address", request);
        }

        /// <summary>
        ///     Register an address for the token specified by TokenUID. Registered addresses, like 
        ///     created addresses, are monitored for incoming transfers of the token specified via TokenUID. 
        ///     When new tokens are transferred into the address, you are alerted via the token/transfer webhook 
        ///     callback.
        /// </summary>
        /// <param name="request">The request.</param>
        /// <returns>The response that was returned by the API.</returns>
        public RegisterAddressResponse RegisterAddress(RegisterAddressRequest request)
        {
            return Post<RegisterAddressRequest, RegisterAddressResponse>(@"register_address", request);
        }

        /// <summary>
        ///     Register an address for the token specified by TokenUID. Registered addresses, like 
        ///     created addresses, are monitored for incoming transfers of the token specified via TokenUID. 
        ///     When new tokens are transferred into the address, you are alerted via the token/transfer webhook 
        ///     callback.
        /// </summary>
        /// <param name="request">The request.</param>
        /// <returns>The response that was returned by the API.</returns>
        public Task<RegisterAddressResponse> RegisterAddressAsync(RegisterAddressRequest request)
        {
            return PostAsync<RegisterAddressRequest, RegisterAddressResponse>(@"register_address", request);
        }

        /// <summary>
        ///     Query the number of tokens specified by the token with TokenUID that address has.
        /// </summary>
        /// <param name="request">The request.</param>
        /// <returns>The response that was returned by the API.</returns>
        public AddressBalanceResponse GetAddressBalance(AddressBalanceRequest request)
        {
            return Get<AddressBalanceRequest, AddressBalanceResponse>(@"balance", request);
        }

        /// <summary>
        ///     Query the number of tokens specified by the token with TokenUID that address has.
        /// </summary>
        /// <param name="request">The request.</param>
        /// <returns>The response that was returned by the API.</returns>
        public Task<AddressBalanceResponse> GetAddressBalanceAsync(AddressBalanceRequest request)
        {
            return GetAsync<AddressBalanceRequest, AddressBalanceResponse>(@"balance", request);
        }

        /// <summary>
        ///     Transfer tokens from a Mobius managed address to a specified address. You must have a high 
        ///     enough balance to cover the transaction fees — on Ethereum this means paying the gas costs. 
        ///     Currently Mobius does not charge any fees itself.
        /// </summary>
        /// <param name="managedRequests">The request.</param>
        /// <returns>The response that was returned by the API.</returns>
        public TransferManagedResponse TransferManaged(TransferManagedRequest managedRequest)
        {
            return Post<TransferManagedRequest, TransferManagedResponse>(@"transfer/managed", managedRequest);
        }
        
        /// <summary>
        ///     Transfer tokens from a Mobius managed address to a specified address. You must have a high 
        ///     enough balance to cover the transaction fees — on Ethereum this means paying the gas costs. 
        ///     Currently Mobius does not charge any fees itself.
        /// </summary>
        /// <param name="managedRequests">The request.</param>
        /// <returns>The response that was returned by the API.</returns>
        public Task<TransferManagedResponse> TransferManagedAsync(TransferManagedRequest managedRequest)
        {
            return PostAsync<TransferManagedRequest, TransferManagedResponse>(@"transfer/managed", managedRequest);
        }
        
        /// <summary>
        ///     Get the status and transaction hash of a Mobius managed token transfer.
        /// </summary>
        /// <param name="requests">The request.</param>
        /// <returns>The response that was returned by the API.</returns>
        public TransferInfoResponse GetTransferInfo(TransferInfoRequest request)
        {
            return Get<TransferInfoRequest, TransferInfoResponse>(@"transfer/info", request);
        }

        /// <summary>
        ///     Get the status and transaction hash of a Mobius managed token transfer.
        /// </summary>
        /// <param name="requests">The request.</param>
        /// <returns>The response that was returned by the API.</returns>
        public Task<TransferInfoResponse> GetTransferInfoAsync(TransferInfoRequest request)
        {
            return GetAsync<TransferInfoRequest, TransferInfoResponse>(@"transfer/info", request);
        }
    }
}
