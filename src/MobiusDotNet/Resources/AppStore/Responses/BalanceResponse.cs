using Newtonsoft.Json;

namespace MobiusDotNet.Resources.AppStore.Responses
{
    /// <summary>
    ///     The response of a balance request.
    /// </summary>
    public class BalanceResponse : ResponseBase
    {
        /// <summary>
        ///     Gets or sets the number of credits on the balance.
        /// </summary>
        [JsonProperty("num_credits")]
        public int NumberOfCredits { get; set; }
    }
}
