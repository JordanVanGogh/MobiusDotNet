using System;

namespace MobiusDotNet.Resources.AppStore.Parameters
{
    /// <summary>
    ///     The parameters that must be provided for a balance request.  
    /// </summary>
    public class BalanceParameters : ParametersBase
    {
        /// <summary>
        ///     Gets or sets the UID of the app. Get it at https://mobius.network/store/developer.
        /// </summary>
        [ParameterName("app_uid")]
        public Guid AppUID { get; set; }
        
        /// <summary>
        ///     Gets or sets the email of the user whose balance you want to query.
        /// </summary>
        [ParameterName("email")]
        public string Email { get; set; }
    }
}
