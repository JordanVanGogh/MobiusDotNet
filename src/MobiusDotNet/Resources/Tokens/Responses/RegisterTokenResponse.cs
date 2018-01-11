using System;
using Newtonsoft.Json;

namespace MobiusDotNet.Resources.Tokens.Responses
{
    /// <summary>
    ///     The response of a register token request.
    /// </summary>
    public class RegisterTokenResponse : Response
    {
        /// <summary>
        ///     Gets or sets the UID of the token.
        /// </summary>
        [JsonProperty("uid")]
        public Guid UID { get; set; }

        /// <summary>
        ///     Gets or sets the token type.
        /// </summary>
        [JsonProperty("token_type")]
        public TokenType TokenType { get; set; }

        /// <summary>
        ///     Gets or sets the name of the token.
        /// </summary>
        [JsonProperty("name")]
        public string Name { get; set; }

        /// <summary>
        ///     Gets or sets the symbol of the token.
        /// </summary>
        [JsonProperty("symbol")]
        public string Symbol { get; set; }

        /// <summary>
        ///     Gets or sets the issuer of the token.
        /// </summary>
        [JsonProperty("issuer")]
        public string Issuer { get; set; }
    }
}
