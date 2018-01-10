using System;
using System.Net.Http;
using System.Runtime.CompilerServices;
using MobiusDotNet.Resources.AppStore;
using MobiusDotNet.Resources.Tokens;

[assembly: InternalsVisibleTo("MobiusDotNet.Tests")]

namespace MobiusDotNet
{
    /// <summary>
    ///     Mobius API client.
    /// </summary>
    public class Mobius : IDisposable
    {
        private readonly HttpClient _localHttpClient;

        /// <summary>
        ///     The App Store API.
        /// </summary>
        public AppStoreClient AppStore { get; }

        /// <summary>
        ///     The Tokens API.
        /// </summary>
        public TokensClient Tokens { get; }

        /// <summary>
        ///     Instantiates a new instance of this class.
        /// </summary>
        /// <param name="connectionInfo">The connect details used when setting up a connection.</param>
        public Mobius(MobiusConnectionInfo connectionInfo) : this(null, connectionInfo)
        { }

        /// <summary>
        ///     Instantiates a new instance of this class.
        /// </summary>
        /// <param name="httpClient">The HTTP client to be used.</param>
        /// <param name="connectionInfo">The connect details used when setting up a connection.</param>
        internal Mobius(HttpClient httpClient, MobiusConnectionInfo connectionInfo)
        {
            if (connectionInfo == null) throw new ArgumentNullException(nameof(connectionInfo));

            HttpClient httpClientToUse;
            if (httpClient == null)
            {
                _localHttpClient = new HttpClient();
                httpClientToUse = _localHttpClient;
            }
            else
            {
                _localHttpClient = null;
                httpClientToUse = httpClient;
            }

            AppStore = new AppStoreClient(httpClientToUse, connectionInfo);
            Tokens = new TokensClient(httpClientToUse, connectionInfo);
        }

        /// <inheritdoc />
        public void Dispose()
        {
            if (_localHttpClient != null)
                _localHttpClient.Dispose();
        }
    }
}
