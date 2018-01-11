using System;

namespace MobiusDotNet.Resources.AppStore.Requests
{
    /// <summary>
    ///     App Store balance request.  
    /// </summary>
    public class BalanceRequest : RequestBase
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
