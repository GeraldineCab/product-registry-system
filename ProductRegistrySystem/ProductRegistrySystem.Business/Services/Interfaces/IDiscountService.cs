using System.Threading;
using System.Threading.Tasks;

namespace ProductRegistrySystem.Business.Services.Interfaces
{
    public interface IDiscountService
    {
        /// <summary>
        /// Calls the Discount proxy to get a product's discount 
        /// </summary>
        /// <param name="productId">The product id</param>
        /// <param name="cancellationToken"></param>
        /// <returns>The discount value for a product</returns>
        Task<double?> GetDiscountByProductAsync(int productId, CancellationToken cancellationToken);
    }
}
