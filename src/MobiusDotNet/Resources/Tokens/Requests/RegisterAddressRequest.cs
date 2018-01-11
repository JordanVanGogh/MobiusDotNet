using System;

namespace MobiusDotNet.Resources.Tokens.Requests
{
    /// <summary>
    ///     Tokens register address request.  
    /// </summary>
    public class RegisterAddressRequest : Request
    {
        /// <summary>
        ///     Gets or sets the UID of the token, as returned by a "RegisterToken()" request.
        /// </summary>
        [ParameterName("token_uid")]
        public Guid TokenUID { get; set; }

        /// <summary>
        ///     Gets or sets the address to register.
        /// </summary>
        [ParameterName("address")]
        public string Address { get; set; }
    }
}
