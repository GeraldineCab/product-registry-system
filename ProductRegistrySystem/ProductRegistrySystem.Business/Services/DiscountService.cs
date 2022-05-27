using System;
using System.Threading;
using System.Threading.Tasks;
using ProductRegistrySystem.Business.ExternalProxies.Interfaces;
using ProductRegistrySystem.Business.Services.Interfaces;

namespace ProductRegistrySystem.Business.Services
{
    public class DiscountService : IDiscountService
    {
        private readonly IDiscountProxy _proxy;
        public DiscountService(IDiscountProxy proxy)
        {
            _proxy = proxy ?? throw new ArgumentNullException(nameof(proxy));
        }
        /// <inheritdoc />
        public async Task<double?> GetDiscountByProductAsync(int productId, CancellationToken cancellationToken)
        {
            return await _proxy.GetDiscountByProductAsync(productId, cancellationToken);
        }
    }
}
