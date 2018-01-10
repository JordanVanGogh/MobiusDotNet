using System;

namespace MobiusDotNet
{
    /// <summary>
    ///     Connection info for the Mobius API.
    /// </summary>
    public class MobiusConnectionInfo
    {
        /// <summary>
        ///     Initializes a new instance.
        /// </summary>
        /// <param name="apiKey">The API key.</param>
        /// <param name="host">The host name. Provide null for default host name.</param>
        /// <param name="version">The requested version of the API. Provide null for default version.</param>
        /// <param name="authorization">The authorization value.</param>
        public MobiusConnectionInfo(string apiKey = null, string host = null, string version = null, string authorization = null)
        {
            ApiKey = apiKey ?? string.Empty;
            Host = host ?? "https://mobius.network/api";
            Version = version ?? "v1";
            Authorization = authorization;
        }

        /// <summary>
        ///     Gets the API key.
        /// </summary>
        public String ApiKey { get; }

        /// <summary>
        ///     Gets the host name.
        /// </summary>
        public String Host { get; }

        /// <summary>
        ///     Gets the API version.
        /// </summary>
        public String Version { get; }

        /// <summary>
        ///     Gets the authorization value.
        /// </summary>
        public String Authorization { get; }
    }
}