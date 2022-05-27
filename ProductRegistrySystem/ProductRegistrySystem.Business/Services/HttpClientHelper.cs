using System;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using ProductRegistrySystem.Business.Services.Interfaces;

namespace ProductRegistrySystem.Business.Services
{
    public class HttpClientHelper : IHttpClientHelper
    {
        private readonly HttpClient _httpClient;

        public HttpClientHelper(HttpClient httpClient)
        {
            _httpClient = httpClient ?? throw new ArgumentNullException(nameof(httpClient));
        }

        /// <inheritdoc />
        public async Task<HttpResponseMessage> GetAsync(string uri, CancellationToken cancellationToken)
        {
            return await _httpClient.GetAsync(uri, cancellationToken);
        }
    }
}
