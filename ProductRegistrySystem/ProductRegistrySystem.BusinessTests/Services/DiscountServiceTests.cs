using System.Threading;
using System.Threading.Tasks;
using NUnit.Framework;
using ProductRegistrySystem.Business.ExternalProxies.Interfaces;
using ProductRegistrySystem.Business.Services;
using Telerik.JustMock;
using Telerik.JustMock.Helpers;

namespace ProductRegistrySystem.BusinessTests.Services
{
    [TestFixture]
    public class DiscountServiceTests
    {
        private DiscountService _discountService;
        private IDiscountProxy _discountProxy;

        [SetUp]
        public void SetUp()
        {
            _discountProxy = Mock.Create<IDiscountProxy>(Behavior.Strict);
            _discountService = new DiscountService(_discountProxy);
        }

        [Test]
        public async Task Can_GetDiscountByProductAsync_When_ProductIsFound_Returns_Discount()
        {
            // Arrange
            var productId = 1;
            _discountProxy.Arrange(s => s.GetDiscountByProductAsync(productId, Arg.IsAny<CancellationToken>()))
                .TaskResult(2);

            // Act
            var result = await _discountService.GetDiscountByProductAsync(productId, Arg.IsAny<CancellationToken>());

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(2, result);
        }

        [Test]
        public async Task Can_GetDiscountByProductAsync_When_ProductIsNotFound_Returns_Null()
        {
            // Arrange
            var productId = 9;
            _discountProxy.Arrange(s => s.GetDiscountByProductAsync(productId, Arg.IsAny<CancellationToken>()))
                .TaskResult(null);

            // Act
            var result = await _discountService.GetDiscountByProductAsync(productId, Arg.IsAny<CancellationToken>());

            // Assert
            Assert.IsNull(result);
        }
    }
}
