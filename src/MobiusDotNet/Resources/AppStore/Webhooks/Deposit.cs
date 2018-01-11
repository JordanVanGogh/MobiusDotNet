using System;
using Newtonsoft.Json;

namespace MobiusDotNet.Resources.AppStore.Webhooks
{
    /// <summary>
    ///     App Store deposit is called when a user deposits 
    ///     credits in your app through the DApp store.
    /// </summary>
    public class Deposit : Webhook
    {
        private const string BoundActionType = @"app_store/deposit";

        /// <summary>
        ///     Gets or sets the app UID.
        /// </summary>
        [JsonProperty("app_uid")]
        public Guid AppUID { get; set; }

        /// <summary>
        ///     Gets or sets the email address of the sending user.
        /// </summary>
        [JsonProperty("email")]
        public string Email { get; set; }

        /// <summary>
        ///     Gets or sets the number of credits deposited in this transaction.
        /// </summary>
        [JsonProperty("num_credits")]
        public decimal NumberOfCredits { get; set; }
        
        /// <summary>
        ///     Gets or sets the total number of credits the user has in your app.
        /// </summary>
        [JsonProperty("total_num_credits")]
        public decimal TotalNumberOfCredits { get; set; }
        
        /// <summary>
        ///     Detects whether a give action is an App Store deposit.
        /// </summary>
        /// <param name="actionType">The action type.</param>
        /// <returns>A boolean value indicating whether the action is of this webhook type.</returns>
        public static bool IsOfActionType(string actionType)
        {
            return BoundActionType.Equals(actionType, StringComparison.InvariantCultureIgnoreCase);
        }
    }
}
