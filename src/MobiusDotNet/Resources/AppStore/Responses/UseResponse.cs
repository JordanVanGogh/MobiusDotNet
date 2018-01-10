using Newtonsoft.Json;

namespace MobiusDotNet.Resources.AppStore.Responses
{
    /// <summary>
    ///     The response of a use request.
    /// </summary>
    public class UseResponse : ResponseBase
    {
        /// <summary>
        ///     Gets or sets a boolean value indicating whether the use was a success.
        /// </summary>
        [JsonProperty("success")]
        public bool IsSuccess { get; set; }

        /// <summary>
        ///     Gets or sets the number of credits on the balance after the use.
        /// </summary>
        [JsonProperty("num_credits")]
        public int NumberOfCredits { get; set; }
    }
}
