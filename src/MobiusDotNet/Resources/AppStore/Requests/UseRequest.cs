using System;

namespace MobiusDotNet.Resources.AppStore.Requests
{
    /// <summary>
    ///     App Store use request.  
    /// </summary>
    public class UseRequest : Request
    {
        /// <summary>
        ///     Gets or sets the UID of the app. Get it at https://mobius.network/store/developer.
        /// </summary>
        [ParameterName("app_uid")]
        public Guid AppUID { get; set; }

        /// <summary>
        ///     Gets or sets the email of the user whose balance is going to be used.
        /// </summary>
        [ParameterName("email")]
        public string Email { get; set; }

        /// <summary>
        ///     Gets or sets the number of credits to use.
        /// </summary>
        [ParameterName("num_credits")]
        public decimal NumberOfCredits { get; set; }
    }
}
