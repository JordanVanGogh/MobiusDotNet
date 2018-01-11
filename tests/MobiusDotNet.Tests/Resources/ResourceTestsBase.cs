using System;
using System.Net.Http;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.TestHost;
using MobiusDotNet.Resources;
using Newtonsoft.Json;

namespace MobiusDotNet.Tests.Resources
{
    public abstract class ResourceTestsBase : IDisposable
    {
        public const string ApiVersion = "v1";
        public const string JsonContentType = "application/json";

        protected TestServer TestServer { get; set; }
        protected HttpClient TestClient { get; set; }

        protected ResourceTestsBase()
        {
            TestServer = null;
        }

        protected String GetPath(String resource, String action)
        {
            return $"/{ApiVersion}/{resource}/{action}";
        }

        protected MobiusConnectionInfo GetConnectionInfo(String apiKey = null, String host = "", String version = ApiVersion, String authorization = null)
        {
            return new MobiusConnectionInfo(apiKey ?? Guid.NewGuid().ToString(), host, version, authorization);
        }
        
        protected HttpClient StartTestHostWithFixedResponse<TResponse>(String path, int httpStatusCode, TResponse response)
            where TResponse : Response
        {
            TestServer = new TestServer(new WebHostBuilder()
                .Configure(app =>
                {
                    app.Run(context =>
                    {
                        if (context.Request.Path.Value != path)
                        {
                            context.Response.StatusCode = 404;
                            return context.Response.WriteAsync("Not found!");
                        }
                        else
                        {
                            var json = JsonConvert.SerializeObject(response, Formatting.Indented);
                            context.Response.StatusCode = httpStatusCode;
                            context.Response.ContentType = JsonContentType;
                            return context.Response.WriteAsync(json);
                        }
                    });
                }));
            return TestClient = TestServer.CreateClient();
        }
        
        public void Dispose()
        {
            if (TestClient != null)
                TestClient.Dispose();
            if (TestServer != null)
                TestServer.Dispose();
        }
    }
}
