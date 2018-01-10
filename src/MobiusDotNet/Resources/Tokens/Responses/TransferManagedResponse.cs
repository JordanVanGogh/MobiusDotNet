using System;
using Newtonsoft.Json;

namespace MobiusDotNet.Resources.Tokens.Responses
{
    /// <summary>
    ///     The response of a transfer managed request.
    /// </summary>
    public class TransferManagedResponse : ResponseBase
    {
        /// <summary>
        ///     Gets or sets the UID of the transfer, which can be used for querying its status.
        /// </summary>
        [JsonProperty("token_address_transfer_uid")]
        public Guid TokenAddressTransferUID { get; set; }
    }
}
