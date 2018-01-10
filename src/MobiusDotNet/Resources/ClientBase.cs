using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace MobiusDotNet.Resources
{
    /// <summary>
    ///     Base class for resource clients.
    /// </summary>
    public abstract class ClientBase
    {
        private readonly MobiusConnectionInfo _connectionInfo;
        private readonly HttpClient _httpClient;

        /// <summary>
        ///     Gets the resource name this client uses.
        /// </summary>
        protected abstract String ResourceName { get; }

        /// <summary>
        ///     Initializes a new instance of this class.
        /// </summary>
        protected ClientBase(HttpClient httpClient, MobiusConnectionInfo connectionInfo = null)
        {
            _connectionInfo = connectionInfo ?? new MobiusConnectionInfo();
            _httpClient = httpClient ?? throw new ArgumentNullException(nameof(httpClient));
        }

        /// <summary>
        ///     Issues a GET request.
        /// </summary>
        /// <typeparam name="TParameters">Type of the parameters.</typeparam>
        /// <typeparam name="TResponse">Type of the response.</typeparam>
        /// <param name="action">The resource action</param>
        /// <param name="parameters">The request parameters.</param>
        /// <returns>A response object.</returns>
        protected TResponse Get<TParameters, TResponse>(String action, TParameters parameters = null)
            where TParameters : ParametersBase
            where TResponse : ResponseBase
        {
            return WaitForTaskResult(GetAsync<TParameters, TResponse>(action, parameters));
        }

        /// <summary>
        ///     Issues a GET request.
        /// </summary>
        /// <typeparam name="TParameters">Type of the parameters.</typeparam>
        /// <typeparam name="TResponse">Type of the response.</typeparam>
        /// <param name="action">The resource action</param>
        /// <param name="parameters">The request parameters.</param>
        /// <returns>A response object.</returns>
        protected Task<TResponse> GetAsync<TParameters, TResponse>(String action, TParameters parameters = null)
            where TParameters : ParametersBase
            where TResponse : ResponseBase
        {
            if (action == null) throw new ArgumentNullException(nameof(action));

            return SendAsync<TParameters, TResponse>(HttpMethod.Get, action, parameters);
        }

        /// <summary>
        ///     Issues a POST request.
        /// </summary>
        /// <typeparam name="TParameters">Type of the parameters.</typeparam>
        /// <typeparam name="TResponse">Type of the response.</typeparam>
        /// <param name="action">The resource action</param>
        /// <param name="parameters">The request parameters.</param>
        /// <returns>A response object.</returns>
        protected TResponse Post<TParameters, TResponse>(String action, TParameters parameters)
            where TParameters : ParametersBase
            where TResponse : ResponseBase
        {
            return WaitForTaskResult(PostAsync<TParameters, TResponse>(action, parameters));
        }

        /// <summary>
        ///     Issues a POST request.
        /// </summary>
        /// <typeparam name="TParameters">Type of the parameters.</typeparam>
        /// <typeparam name="TResponse">Type of the response.</typeparam>
        /// <param name="action">The resource action</param>
        /// <param name="parameters">The request parameters.</param>
        /// <returns>A response object.</returns>
        protected Task<TResponse> PostAsync<TParameters, TResponse>(String action, TParameters parameters)
            where TParameters : ParametersBase
            where TResponse : ResponseBase
        {
            if (action == null) throw new ArgumentNullException(nameof(action));
            if (parameters == null) throw new ArgumentNullException(nameof(parameters));

            return SendAsync<TParameters, TResponse>(HttpMethod.Post, action, parameters);
        }

        private TResponse WaitForTaskResult<TResponse>(Task<TResponse> task)
            where TResponse : ResponseBase
        {
            try
            {
                return task.Result;
            }
            catch (AggregateException ae)
            {
                throw ae.InnerException;
            }
        }
        
        private async Task<TResponse> SendAsync<TParameters, TResponse>(
            HttpMethod httpMethod, 
            String action,
            TParameters parameters)
            where TParameters : ParametersBase
            where TResponse : ResponseBase
        {
            var url = FormatUrl(action);
            var message = new HttpRequestMessage(httpMethod, url);
            AddHeadersToRequest(message);
            if (parameters != null)
            {
                var dictionary = parameters.ToDictionary();
                if (dictionary.Count > 0)
                {
                    var content = new FormUrlEncodedContent(dictionary);
                    message.Content = content;
                }
            }

            var response = await _httpClient.SendAsync(message);
            if ((int)response.StatusCode >= 400)
                await HandleErrorResponseAsync(response);

            var json = await response.Content.ReadAsStringAsync();
            var responseObj = JsonConvert.DeserializeObject<TResponse>(json);
            return responseObj;
        }

        private void AddHeadersToRequest(HttpRequestMessage request)
        {
            request.Headers.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            request.Headers.Add("X-Api-Key", _connectionInfo.ApiKey);
            if (_connectionInfo.Authorization != null)
                request.Headers.Add("Authorization", _connectionInfo.Authorization);
            // request.Headers.Authorization = new AuthenticationHeaderValue(_connectionInfo.Authorization)on;
        }

        private async Task HandleErrorResponseAsync(HttpResponseMessage response)
        {
            string message = "Something went wrong";

            try
            {
                var json = await response.Content.ReadAsStringAsync();
                var responseObj = JsonConvert.DeserializeObject<ErrorResponse>(json);
                message = responseObj?.Error?.Message ?? message;
            }
            catch
            {
                /* pass */
            }

            throw new MobiusException((int)response.StatusCode, response.ReasonPhrase, message);
        }

        private string FormatUrl(string action)
        {
            return $"{_connectionInfo.Host}/{_connectionInfo.Version}/{ResourceName}/{action}";
        }
    }
}
