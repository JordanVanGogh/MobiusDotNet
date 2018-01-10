using System;

namespace MobiusDotNet.Resources.AppStore.Parameters
{
    /// <summary>
    ///     The parameters that must be provided for a use request.  
    /// </summary>
    public class UseParameters : ParametersBase
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
        public int NumberOfCredits { get; set; }
    }
}
