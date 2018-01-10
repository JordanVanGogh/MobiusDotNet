using System;
using Newtonsoft.Json;

namespace MobiusDotNet.Resources.Tokens.Reponses
{
    /// <summary>
    ///     The response of a register address request.
    /// </summary>
    public class RegisterAddressResponse : ResponseBase
    {
        /// <summary>
        ///     Gets or sets the UID of the new address.
        /// </summary>
        [JsonProperty("uid")]
        public Guid UID { get; set; }
    }
}
