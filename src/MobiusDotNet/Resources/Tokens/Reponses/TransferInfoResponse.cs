using System;
using Newtonsoft.Json;

namespace MobiusDotNet.Resources.Tokens.Reponses
{
    /// <summary>
    ///     The response of a transfer info request.
    /// </summary>
    public class TransferInfoResponse : ResponseBase
    {
        /// <summary>
        ///     Gets or sets the UID of the transfer.
        /// </summary>
        [JsonProperty("uid")]
        public Guid UID { get; set; }

        /// <summary>
        ///     Gets or sets the status of the transfer.
        /// </summary>
        [JsonProperty("status")]
        public TransferStatus Status { get; set; }

        /// <summary>
        ///     Gets or sets the hash of the transaction, once it has been sent.
        /// </summary>
        [JsonProperty("tx_hash")]
        public string TransactionHash { get; set; }
    }
}