using NUnit.Framework;
using ProductRegistrySystem.Business.Services;
using ProductRegistrySystem.Business.Services.Interfaces;
using ProductRegistrySystem.Common.Calculators;
using ProductRegistrySystem.Common.Enums;
using ProductRegistrySystem.Common.Formatters;
using ProductRegistrySystem.Dto.Product;
using Telerik.JustMock;
using Telerik.JustMock.Helpers;

namespace ProductRegistrySystem.BusinessTests.Services
{
    [TestFixture]
    public class ProductHandlingServiceTests
    {
        private ProductDto _productDto;
        private ProductHandlingService _productHandlingService;
        private ICacheHelper _cacheHelper;

        [SetUp]
        public void SetUp()
        {
            _productDto = new ProductDto() { Id = 1, Price = "100000" };

            _cacheHelper = Mock.Create<ICacheHelper>(Behavior.Strict);
            _productHandlingService = new ProductHandlingService(_cacheHelper);
        }

        [Test]
        public void Can_FormatStatusName_Returns_FormattedStatusName()
        {
            // Arrange
            var status = 1;
            _cacheHelper.Arrange(s => s.GetStatusFromCache(_productDto.Id)).Returns(status);

            // Act
            _productHandlingService.FormatStatusName(_productDto);

            // Assert
            Assert.IsNotNull(_productDto.StatusName);
            Assert.AreEqual(((StatusEnum.Status)status).ToString(), _productDto.StatusName);
        }

        [Test]
        public void Can_FormatDiscount_Returns_FormattedDiscount()
        {
            // Arrange
            var discount = 0.4;

            // Act
            _productHandlingService.FormatDiscount(_productDto, discount);

            // Assert
            Assert.IsNotNull(_productDto.Discount);
            Assert.AreEqual(CustomFormatters.ApplyPercentageFormat(discount), _productDto.Discount);
        }

        [Test]
        public void Can_FormatFinalPrice_Returns_FormattedFinalPrice()
        {
            // Arrange
            var discount = 0.4;

            // Act
            _productHandlingService.FormatFinalPrice(_productDto, discount);

            // Assert
            Assert.IsNotNull(_productDto.FinalPrice);
            Assert.AreEqual(PriceCalculator.GetPriceWithDiscount(_productDto.Price, discount), _productDto.FinalPrice);
        }

        [Test]
        public void Can_FormatPrice_Returns_FormattedPrice()
        {
            // Act
            _productHandlingService.FormatPrice(_productDto);

            // Assert
            Assert.IsNotNull(_productDto.Price);
            Assert.AreEqual(CustomFormatters.ApplyCurrencyFormat(double.Parse("100000")), _productDto.Price);
        }
    }
}
