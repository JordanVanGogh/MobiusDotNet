using Newtonsoft.Json;

namespace MobiusDotNet.Resources.AppStore.Responses
{
    /// <summary>
    ///     The response of a balance request.
    /// </summary>
    public class BalanceResponse : Response
    {
        /// <summary>
        ///     Gets or sets the number of credits on the balance.
        /// </summary>
        [JsonProperty("num_credits")]
        public decimal NumberOfCredits { get; set; }
    }
}
