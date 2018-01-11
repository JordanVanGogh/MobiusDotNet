using Newtonsoft.Json;

namespace MobiusDotNet.Resources
{
    /// <summary>
    ///     The response when an error has occurred.
    /// </summary>
    internal class ErrorResponse : Response
    {
        /// <summary>
        ///     Gets or sets the error.
        /// </summary>
        [JsonProperty("error")]
        public ErrorContainer Error { get; set; }
        
        /// <summary>
        ///     Contains error values.
        /// </summary>
        public class ErrorContainer
        {
            /// <summary>
            ///     Gets or sets the message.
            /// </summary>
            [JsonProperty("message")]
            public string Message { get; set; }
        }
    }
}