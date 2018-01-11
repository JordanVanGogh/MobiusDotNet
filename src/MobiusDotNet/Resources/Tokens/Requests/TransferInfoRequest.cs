using System;

namespace MobiusDotNet.Resources.Tokens.Requests
{
    /// <summary>
    ///     Tokens transfer info request.  
    /// </summary>
    public class TransferInfoRequest : Request
    {
        /// <summary>
        ///     Gets or sets the UID of the token address transfer, as returned by "TransferManaged()".
        /// </summary>
        [ParameterName("token_address_transfer_uid")]
        public Guid TokenAddressTransferUID { get; set; }
    }
}