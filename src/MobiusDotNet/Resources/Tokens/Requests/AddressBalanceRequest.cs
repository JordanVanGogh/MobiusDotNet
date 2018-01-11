using System;

namespace MobiusDotNet.Resources.Tokens.Requests
{
    /// <summary>
    ///     Tokens address balance retrieval request.  
    /// </summary>
    public class AddressBalanceRequest : Request
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
