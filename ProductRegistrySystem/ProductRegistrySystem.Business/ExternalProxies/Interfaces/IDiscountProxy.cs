using System.Threading;
using System.Threading.Tasks;

namespace ProductRegistrySystem.Business.ExternalProxies.Interfaces
{
    public interface IDiscountProxy
    {
        /// <summary>
        /// Given a product id, retrieves the matching discount
        /// </summary>
        /// <param name="productId">The product id</param>
        /// <param name="cancellationToken">Transaction cancellation token</param>
        /// <returns>The discount value for a product</returns>
        Task<double?> GetDiscountByProductAsync(int productId, CancellationToken cancellationToken);
    }
}
