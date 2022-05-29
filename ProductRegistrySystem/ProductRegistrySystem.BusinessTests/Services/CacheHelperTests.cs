using Microsoft.Extensions.Caching.Memory;
using NUnit.Framework;
using ProductRegistrySystem.Business.Services;
using ProductRegistrySystem.Business.Utils.Constants;
using ProductRegistrySystem.Persistence.Entities;
using ProductRegistrySystem.Persistence.Repositories.Interfaces;
using Telerik.JustMock;
using Telerik.JustMock.Helpers;

namespace ProductRegistrySystem.BusinessTests.Services
{
    [TestFixture]
    public class CacheHelperTests
    {
        private CacheHelper _cacheHelper;
        private IMemoryCache _memoryCache;
        private IProductRepository _productRepository;

        [SetUp]
        public void SetUp()
        {
            _memoryCache = new MemoryCache(new MemoryCacheOptions());
            _productRepository = Mock.Create<IProductRepository>();
            _cacheHelper = new CacheHelper(_memoryCache, _productRepository);
        }

        [Test]
        public void Can_GetStatusFromCache_When_ValueIsCached_Returns_Status()
        {
            // Arrange
            _memoryCache.Set(CacheKeys.StatusCacheKey, 1);
            _productRepository.Arrange(s => s.GetById(Arg.AnyInt)).Returns(new Product() { Id = 1, Status = 1 }).OccursNever();

            // Act
            var result = _cacheHelper.GetStatusFromCache(1);

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(1, result);
        }

        [Test]
        public void Can_GetStatusFromCache_When_ValueIsNotCached_Returns_Status()
        {
            // Arrange
            _memoryCache.Remove(CacheKeys.StatusCacheKey);
            _productRepository.Arrange(s => s.GetById(Arg.AnyInt)).Returns(new Product() { Id = 1, Status = 1 }).MustBeCalled();

            // Act
            var result = _cacheHelper.GetStatusFromCache(1);

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(1, result);
            Mock.Assert(_productRepository);
        }
    }
}
