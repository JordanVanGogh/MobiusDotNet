
using System;

namespace MobiusDotNet.Resources.Tokens.Parameters
{
    /// <summary>
    ///     The parameters that must be provided for a transfer managed request.  
    /// </summary>
    public class TransferManagedParameters : ParametersBase
    {
        /// <summary>
        ///     Gets or sets the token address UID, as returned by "CreateAddress()".
        /// </summary>
        [ParameterName("token_address_uid")]
        public Guid TokenAddressUID { get; set; }

        /// <summary>
        ///     Gets or sets the address to send the tokens to.
        /// </summary>
        [ParameterName("address_to")]
        public string AddressTo { get; set; }

        /// <summary>
        ///     Gets or sets the number of tokens to transfer.
        /// </summary>
        [ParameterName("num_tokens")]
        public decimal NumberOfTokens { get; set; }
    }
}
