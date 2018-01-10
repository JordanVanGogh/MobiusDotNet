using Newtonsoft.Json;

namespace MobiusDotNet.Resources.Tokens.Responses
{
    /// <summary>
    ///     The response of an address balance request.
    /// </summary>
    public class AddressBalanceResponse : ResponseBase
    {
        /// <summary>
        ///     Gets or sets the address.
        /// </summary>
        [JsonProperty("address")]
        public string Address { get; set; }

        /// <summary>
        ///     Gets or sets the balance.
        /// </summary>
        [JsonProperty("balance")]
        public decimal Balance { get; set; }

        /// <summary>
        ///     Gets or sets the token.
        /// </summary>
        [JsonProperty("token")]
        public TokenContainer Token { get; set; }

        /// <summary>
        ///     Contains token values.
        /// </summary>
        public class TokenContainer
        {
            /// <summary>
            ///     Gets or sets the token type.
            /// </summary>
            [JsonProperty("type_type")]
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
}
