using System;

namespace MobiusDotNet.Resources.Tokens.Requests
{
    /// <summary>
    ///     Tokens create address request.  
    /// </summary>
    public class CreateAddressRequest : Request
    {
        /// <summary>
        ///     Gets or sets the UID of the token, as returned by a "RegisterToken()" request.
        /// </summary>
        [ParameterName("token_uid")]
        public Guid TokenUID { get; set; }
    }
}
