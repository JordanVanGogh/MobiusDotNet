using System;
using Newtonsoft.Json;

namespace MobiusDotNet.Resources.Tokens.Webhooks
{
    /// <summary>
    ///     Token transfer is called when tokens are transferred 
    ///     into a Mobius created or registered address for a 
    /// registered token.
    /// </summary>
    public class Transfer : Webhook
    {
        private const string BoundActionType = @"token/transfer";

        /// <summary>
        ///     Gets or sets the token UID.
        /// </summary>
        [JsonProperty("token_uid")]
        public Guid TokenUID { get; set; }

        /// <summary>
        ///     Gets or sets the from address.
        /// </summary>
        [JsonProperty("from")]
        public string FromAddress { get; set; }

        /// <summary>
        ///     Gets or sets the to address.
        /// </summary>
        [JsonProperty("to")]
        public string ToAddress { get; set; }

        /// <summary>
        ///     Gets or sets the number of tokens trasnferred in this transaction.
        /// </summary>
        [JsonProperty("num_tokens")]
        public decimal NumberOfTokens { get; set; }

        /// <summary>
        ///     Gets or sets the total number of tokens in the to address.
        /// </summary>
        [JsonProperty("total_num_tokens")]
        public decimal TotalNumberOfTokens { get; set; }

        /// <summary>
        ///     Gets or sets the transaction hash.
        /// </summary>
        [JsonProperty("tx_hash")]
        public string TransactionHash { get; set; }
        
        /// <summary>
        ///     Detects whether a give action is an token transfer.
        /// </summary>
        /// <param name="actionType">The action type.</param>
        /// <returns>A boolean value indicating whether the action is of this webhook type.</returns>
        public static bool IsOfActionType(string actionType)
        {
            return BoundActionType.Equals(actionType, StringComparison.InvariantCultureIgnoreCase);
        }
    }
}
