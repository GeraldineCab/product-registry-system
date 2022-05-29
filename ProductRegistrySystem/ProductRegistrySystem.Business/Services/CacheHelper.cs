using System;
using Microsoft.Extensions.Caching.Memory;
using ProductRegistrySystem.Business.Services.Interfaces;
using ProductRegistrySystem.Business.Utils.Constants;
using ProductRegistrySystem.Persistence.Repositories.Interfaces;

namespace ProductRegistrySystem.Business.Services
{
    public class CacheHelper : ICacheHelper
    {
        private readonly IMemoryCache _memoryCache;
        private readonly IProductRepository _productRepository;

        public CacheHelper(IMemoryCache memoryCache, IProductRepository productRepository)
        {
            _memoryCache = memoryCache ?? throw new ArgumentNullException(nameof(memoryCache));
            _productRepository = productRepository ?? throw new ArgumentNullException(nameof(productRepository));
        }

        /// <inheritdoc />
        public int GetStatusFromCache(int productId)
        {
            if (_memoryCache.TryGetValue(CacheKeys.StatusCacheKey, out int cachedStatus))
            {
                return cachedStatus;
            }

            cachedStatus = _productRepository.GetById(productId).Status;

            var cacheOptions = new MemoryCacheEntryOptions()
            {
                AbsoluteExpirationRelativeToNow = TimeSpan.FromMinutes(5)
            };

            _memoryCache.Set(CacheKeys.StatusCacheKey, cachedStatus, cacheOptions);

            return cachedStatus;
        }
    }
}
