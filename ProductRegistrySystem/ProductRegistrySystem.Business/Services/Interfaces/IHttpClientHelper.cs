using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;

namespace ProductRegistrySystem.Business.Services.Interfaces
{
    public interface IHttpClientHelper
    {
        /// <summary>
        /// Retrieves a resource from the given uri
        /// </summary>
        /// <param name="uri">The resource uri</param>
        /// <param name="cancellationToken">Transaction cancellation token</param>
        /// <returns></returns>
        Task<HttpResponseMessage> GetAsync(string uri, CancellationToken cancellationToken);
    }
}
