
using System;

namespace MobiusDotNet.Resources.Tokens.Parameters
{
    /// <summary>
    ///     The parameters that must be provided for a create address request.  
    /// </summary>
    public class CreateAddressParameters : ParametersBase
    {
        /// <summary>
        ///     Gets or sets the UID of the token, as returned by a "RegisterToken()" request.
        /// </summary>
        [ParameterName("token_uid")]
        public Guid TokenUID { get; set; }
    }
}
