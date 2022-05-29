using System.Globalization;
using NUnit.Framework;
using ProductRegistrySystem.Business.Mappers;
using ProductRegistrySystem.Dto.Product;
using ProductRegistrySystem.Persistence.Entities;

namespace ProductRegistrySystem.BusinessTests.Mappers
{
    [TestFixture]
    public class ProductMapperTests
    {
        [SetUp]
        public void SetUp()
        {

        }

        [Test]
        public void Can_MapProductDto_When_ProductIsNotNull_Returns_ProductDto()
        {
            // Arrange
            var product = new Product()
            {
                Id = 1,
                Status = 1,
                Price = 100000,
                Description = "Any description",
                Name = "Any name",
                Stock = 122
            };

            // Act
            var result = new ProductMapper().Get(product);

            // Assert
            Assert.That(result, Is.InstanceOf<ProductDto>());
            Assert.AreEqual(product.Id, result.Id);
            Assert.AreEqual(product.Description, result.Description);
            Assert.AreEqual(product.Name, result.Name);
            Assert.AreEqual(product.Price.ToString(CultureInfo.CurrentCulture), result.Price);
        }

        [Test]
        public void Can_MapProductDto_When_ProductIsNull_Returns_Null()
        {
            // Act
            var result = new ProductMapper().Get(null);

            // Assert
            Assert.IsNull(result);
        }
    }
}
