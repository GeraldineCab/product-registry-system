using NUnit.Framework;
using ProductRegistrySystem.Common.Calculators;
using ProductRegistrySystem.Common.Formatters;

namespace ProductRegistrySystem.CommonTests.Calculators
{
    [TestFixture]
    public class PriceCalculatorTests
    {
        private string _price = "10000";

        [SetUp]
        public void SetUp()
        { }

        [Test]
        public void Can_GetPriceWithDiscount_When_DiscountIsNull_Returns_Price()
        {
            // Act
            var result = PriceCalculator.GetPriceWithDiscount(_price, null);

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(CustomFormatters.ApplyCurrencyFormat(double.Parse(_price)), result);
        }

        [Test]
        public void Can_GetPriceWithDiscount_When_DiscountIsNotNull_Returns_PriceWithDiscount()
        {
            // Arrange
            var discount = 0.4;

            // Act
            var result = PriceCalculator.GetPriceWithDiscount(_price, discount);

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(CustomFormatters.ApplyCurrencyFormat(6000), result);
        }
    }
}
