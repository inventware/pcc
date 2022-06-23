using Microsoft.Net.Http.Headers;
using PCC.API.Core.Interface;
using System;
using System.Net.Http;
using System.Threading.Tasks;


namespace PCC.API.Core.Services
{
    /// <summary>
    /// https://medium.com/@ajidejibola/consume-web-api-with-c-httpclient-367c1f562305:
    /// 
    /// Why not use HttpClient?
    ///     HttpClient is intended to be instantiated once and reused throughout the life of an application.Instantiating 
    ///     an HttpClient class for every request will exhaust the number of sockets available under heavy loads.
    ///     
    /// More:
    ///      https://docs.microsoft.com/en-us/dotnet/architecture/microservices/implement-resilient-applications/use-httpclientfactory-to-implement-resilient-http-requests
    ///      https://www.aspnetmonsters.com/2016/08/2016-08-27-httpclientwrong/
    ///      
    /// Why use IHttpClientFactory?
    ///     HttpClientFactory provides you with HttpClient objects but takes responsibility for managing the resources that 
    ///     the clients can use up. Think of it as “connection pooling for Web Services.
    /// </summary>
    public class HttpCallService : IHttpCallService
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public Task<T> GetData<T>()
        {
            T data = default(T);
            var httpRequestMessage = new HttpRequestMessage(HttpMethod.Get, "https://api.publicapis.org/entries")
            { 
                Headers = {
                    { HeaderNames.Accept, "application/json" },
                    { HeaderNames.UserAgent, "HttpRequestsSample" }
                }
            };

            var httpClient = _httpClientFactory.CreateClient();
            HttpResponseMessage response = httpClient.SendAsync(httpRequestMessage).Result;
            if (response.IsSuccessStatusCode) { 
                // data = response.Content.ReadAsStringAsync()
            }
            else { }

            throw new NotImplementedException();
        }
    }
}
