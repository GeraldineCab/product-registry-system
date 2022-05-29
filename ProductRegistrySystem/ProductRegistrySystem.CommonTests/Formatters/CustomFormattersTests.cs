using NUnit.Framework;
using ProductRegistrySystem.Common.Formatters;

namespace ProductRegistrySystem.CommonTests.Formatters
{
    [TestFixture]
    public class CustomFormattersTests
    {
        private double _amount = 10000;
        private double _percentage = 0.2;

        [SetUp]
        public void SetUp()
        { }

        [Test]
        public void Can_ApplyCurrencyFormat_Returns_String()
        {
            // Act
            var result = CustomFormatters.ApplyCurrencyFormat(_amount);

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual("$10,000.00", result);
        }

        [Test]
        public void Can_ApplyPercentageFormat_Returns_String()
        {
            // Act
            var result = CustomFormatters.ApplyPercentageFormat(_percentage);

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual("20.00 %", result);
        }
    }
}
