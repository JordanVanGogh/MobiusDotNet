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
        protected abstract string ResourceName { get; }

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
        /// <typeparam name="TRequest">Type of the request.</typeparam>
        /// <typeparam name="TResponse">Type of the response.</typeparam>
        /// <param name="action">The resource action</param>
        /// <param name="request">The request.</param>
        /// <returns>A response object.</returns>
        protected TResponse Get<TRequest, TResponse>(string action, TRequest request = null)
            where TRequest : Request
            where TResponse : Response
        {
            return WaitForTaskResult(GetAsync<TRequest, TResponse>(action, request));
        }

        /// <summary>
        ///     Issues a GET request.
        /// </summary>
        /// <typeparam name="TRequest">Type of the request.</typeparam>
        /// <typeparam name="TResponse">Type of the response.</typeparam>
        /// <param name="action">The resource action</param>
        /// <param name="request">The request.</param>
        /// <returns>A response object.</returns>
        protected Task<TResponse> GetAsync<TRequest, TResponse>(string action, TRequest request = null)
            where TRequest : Request
            where TResponse : Response
        {
            if (action == null) throw new ArgumentNullException(nameof(action));

            return SendAsync<TRequest, TResponse>(HttpMethod.Get, action, request);
        }

        /// <summary>
        ///     Issues a POST request.
        /// </summary>
        /// <typeparam name="TRequest">Type of the request.</typeparam>
        /// <typeparam name="TResponse">Type of the response.</typeparam>
        /// <param name="action">The resource action</param>
        /// <param name="request">The request.</param>
        /// <returns>A response object.</returns>
        protected TResponse Post<TRequest, TResponse>(string action, TRequest request)
            where TRequest : Request
            where TResponse : Response
        {
            return WaitForTaskResult(PostAsync<TRequest, TResponse>(action, request));
        }

        /// <summary>
        ///     Issues a POST request.
        /// </summary>
        /// <typeparam name="TRequest">Type of the request.</typeparam>
        /// <typeparam name="TResponse">Type of the response.</typeparam>
        /// <param name="action">The resource action</param>
        /// <param name="request">The request.</param>
        /// <returns>A response object.</returns>
        protected Task<TResponse> PostAsync<TRequest, TResponse>(string action, TRequest request)
            where TRequest : Request
            where TResponse : Response
        {
            if (action == null) throw new ArgumentNullException(nameof(action));
            if (request == null) throw new ArgumentNullException(nameof(request));

            return SendAsync<TRequest, TResponse>(HttpMethod.Post, action, request);
        }

        private TResponse WaitForTaskResult<TResponse>(Task<TResponse> task)
            where TResponse : Response
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
        
        private async Task<TResponse> SendAsync<TRequest, TResponse>(
            HttpMethod httpMethod, 
            string action,
            TRequest request)
            where TRequest : Request
            where TResponse : Response
        {
            var url = FormatUrl(action);
            var message = new HttpRequestMessage(httpMethod, url);
            AddHeadersToRequest(message);
            if (request != null)
            {
                var dictionary = request.ToDictionary();
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
