
using System;

namespace MobiusDotNet.Resources.Tokens.Parameters
{
    /// <summary>
    ///     The parameters that must be provided for a balance retrieval request.  
    /// </summary>
    public class AddressBalanceParameters : ParametersBase
    {
        /// <summary>
        ///     Gets or sets the UID of the token, as returned by a "RegisterToken()" request.
        /// </summary>
        [ParameterName("token_uid")]
        public Guid TokenUID { get; set; }

        /// <summary>
        ///     Gets or sets the address whose balance you want to query.
        /// </summary>
        [ParameterName("address")]
        public string Address { get; set; }
    }
}
