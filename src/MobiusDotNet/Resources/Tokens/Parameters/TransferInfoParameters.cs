using System;

namespace MobiusDotNet.Resources.Tokens.Parameters
{
    /// <summary>
    ///     The parameters that must be provided for a transfer info request.  
    /// </summary>
    public class TransferInfoParameters : ParametersBase
    {
        /// <summary>
        ///     Gets or sets the UID of the token address transfer, as returned by "TransferManaged()".
        /// </summary>
        [ParameterName("token_address_transfer_uid")]
        public Guid TokenAddressTransferUID { get; set; }
    }
}