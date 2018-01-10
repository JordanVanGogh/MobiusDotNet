using System.Net.Http;
using System.Threading.Tasks;
using MobiusDotNet.Resources.Tokens.Parameters;
using MobiusDotNet.Resources.Tokens.Reponses;

namespace MobiusDotNet.Resources.Tokens
{
    /// <summary>
    ///     The client for Tokens resource requests.
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
        /// <param name="parameters">The parameters.</param>
        /// <returns>The response that was returned by the API.</returns>
        public RegisterTokenResponse RegisterToken(RegisterTokenParameters parameters)
        {
            return Post<RegisterTokenParameters, RegisterTokenResponse>(@"register", parameters);
        }

        /// <summary>
        ///     Register a token so you can use it with the other Token API calls.
        /// </summary>
        /// <param name="parameters">The parameters.</param>
        /// <returns>The response that was returned by the API.</returns>
        public Task<RegisterTokenResponse> RegisterTokenAsync(RegisterTokenParameters parameters)
        {
            return PostAsync<RegisterTokenParameters, RegisterTokenResponse>(@"register", parameters);
        }

        /// <summary>
        ///     Create an address for the token specified by TokenUID.
        /// </summary>
        /// <param name="parameters">The parameters.</param>
        /// <returns>The response that was returned by the API.</returns>
        public CreateAddressResponse CreateAddress(CreateAddressParameters parameters)
        {
            return Post<CreateAddressParameters, CreateAddressResponse>(@"create_address", parameters);
        }

        /// <summary>
        ///     Create an address for the token specified by TokenUID.
        /// </summary>
        /// <param name="parameters">The parameters.</param>
        /// <returns>The response that was returned by the API.</returns>
        public Task<CreateAddressResponse> CreateAddressAsync(CreateAddressParameters parameters)
        {
            return PostAsync<CreateAddressParameters, CreateAddressResponse>(@"create_address", parameters);
        }

        /// <summary>
        ///     Register an address for the token specified by TokenUID. Registered addresses, like 
        ///     created addresses, are monitored for incoming transfers of the token specified via TokenUID. 
        ///     When new tokens are transferred into the address, you are alerted via the token/transfer webhook 
        ///     callback.
        /// </summary>
        /// <param name="parameters">The parameters.</param>
        /// <returns>The response that was returned by the API.</returns>
        public RegisterAddressResponse RegisterAddress(RegisterAddressParameters parameters)
        {
            return Post<RegisterAddressParameters, RegisterAddressResponse>(@"register_address", parameters);
        }

        /// <summary>
        ///     Register an address for the token specified by TokenUID. Registered addresses, like 
        ///     created addresses, are monitored for incoming transfers of the token specified via TokenUID. 
        ///     When new tokens are transferred into the address, you are alerted via the token/transfer webhook 
        ///     callback.
        /// </summary>
        /// <param name="parameters">The parameters.</param>
        /// <returns>The response that was returned by the API.</returns>
        public Task<RegisterAddressResponse> RegisterAddressAsync(RegisterAddressParameters parameters)
        {
            return PostAsync<RegisterAddressParameters, RegisterAddressResponse>(@"register_address", parameters);
        }

        /// <summary>
        ///     Query the number of tokens specified by the token with TokenUID that address has.
        /// </summary>
        /// <param name="parameters">The parameters.</param>
        /// <returns>The response that was returned by the API.</returns>
        public AddressBalanceResponse GetAddressBalance(AddressBalanceParameters parameters)
        {
            return Get<AddressBalanceParameters, AddressBalanceResponse>(@"balance", parameters);
        }

        /// <summary>
        ///     Query the number of tokens specified by the token with TokenUID that address has.
        /// </summary>
        /// <param name="parameters">The parameters.</param>
        /// <returns>The response that was returned by the API.</returns>
        public Task<AddressBalanceResponse> GetAddressBalanceAsync(AddressBalanceParameters parameters)
        {
            return GetAsync<AddressBalanceParameters, AddressBalanceResponse>(@"balance", parameters);
        }

        /// <summary>
        ///     Transfer tokens from a Mobius managed address to a specified address. You must have a high 
        ///     enough balance to cover the transaction fees — on Ethereum this means paying the gas costs. 
        ///     Currently Mobius does not charge any fees itself.
        /// </summary>
        /// <param name="managedParameters">The parameters.</param>
        /// <returns>The response that was returned by the API.</returns>
        public TransferManagedResponse TransferManaged(TransferManagedParameters managedParameters)
        {
            return Post<TransferManagedParameters, TransferManagedResponse>(@"transfer/managed", managedParameters);
        }
        
        /// <summary>
        ///     Transfer tokens from a Mobius managed address to a specified address. You must have a high 
        ///     enough balance to cover the transaction fees — on Ethereum this means paying the gas costs. 
        ///     Currently Mobius does not charge any fees itself.
        /// </summary>
        /// <param name="managedParameters">The parameters.</param>
        /// <returns>The response that was returned by the API.</returns>
        public Task<TransferManagedResponse> TransferManagedAsync(TransferManagedParameters managedParameters)
        {
            return PostAsync<TransferManagedParameters, TransferManagedResponse>(@"transfer/managed", managedParameters);
        }
        
        /// <summary>
        ///     Get the status and transaction hash of a Mobius managed token transfer.
        /// </summary>
        /// <param name="parameters">The parameters.</param>
        /// <returns>The response that was returned by the API.</returns>
        public TransferInfoResponse GetTransferInfo(TransferInfoParameters parameters)
        {
            return Get<TransferInfoParameters, TransferInfoResponse>(@"transfer/info", parameters);
        }

        /// <summary>
        ///     Get the status and transaction hash of a Mobius managed token transfer.
        /// </summary>
        /// <param name="parameters">The parameters.</param>
        /// <returns>The response that was returned by the API.</returns>
        public Task<TransferInfoResponse> GetTransferInfoAsync(TransferInfoParameters parameters)
        {
            return GetAsync<TransferInfoParameters, TransferInfoResponse>(@"transfer/info", parameters);
        }
    }
}
