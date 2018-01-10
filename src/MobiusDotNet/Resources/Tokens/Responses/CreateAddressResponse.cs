using System;
using Newtonsoft.Json;

namespace MobiusDotNet.Resources.Tokens.Responses
{
    /// <summary>
    ///     The response of a create address request.
    /// </summary>
    public class CreateAddressResponse : ResponseBase
    {
        /// <summary>
        ///     Gets or sets the UID of the new address.
        /// </summary>
        [JsonProperty("uid")]
        public Guid UID { get; set; }
        
        /// <summary>
        ///     Gets or sets the new address.
        /// </summary>
        [JsonProperty("address")]
        public string Address { get; set; }
    }
}
