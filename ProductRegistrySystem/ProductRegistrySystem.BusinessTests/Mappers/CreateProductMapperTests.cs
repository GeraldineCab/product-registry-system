using NUnit.Framework;
using ProductRegistrySystem.Business.Mappers;
using ProductRegistrySystem.Dto.Product;
using ProductRegistrySystem.Persistence.Entities;

namespace ProductRegistrySystem.BusinessTests.Mappers
{
    [TestFixture]
    public class CreateProductMapperTests
    {
        [SetUp]
        public void SetUp()
        {

        }

        [Test]
        public void Can_MapCreateProductDto_When_CreateProductDtoIsNotNull_Returns_Product()
        {
            // Arrange
            var createProductDto = new CreateProductDto()
            {
                Status = 1,
                Price = 10000,
                Description = "Any description",
                Name = "Any name",
                Stock = 10
            };

            // Act
            var result = new CreateProductMapper().Get(createProductDto);

            // Assert
            Assert.That(result, Is.InstanceOf<Product>());
            Assert.AreEqual(createProductDto.Status, result.Status);
            Assert.AreEqual(createProductDto.Price, result.Price);
            Assert.AreEqual(createProductDto.Description, result.Description);
            Assert.AreEqual(createProductDto.Name, result.Name);
            Assert.AreEqual(createProductDto.Stock, result.Stock);
        }

        [Test]
        public void Can_MapCreateProductDto_When_CreateProductDtoIsNull_Returns_Null()
        {
            // Act
            var result = new CreateProductMapper().Get(null);

            // Assert
            Assert.IsNull(result);
        }
    }
}
