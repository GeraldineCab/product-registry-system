using System.Threading;
using System.Threading.Tasks;
using NUnit.Framework;
using ProductRegistrySystem.Business.Mappers;
using ProductRegistrySystem.Business.Services;
using ProductRegistrySystem.Business.Services.Interfaces;
using ProductRegistrySystem.Dto.Product;
using ProductRegistrySystem.Persistence.Entities;
using ProductRegistrySystem.Persistence.Repositories.Interfaces;
using Telerik.JustMock;
using Telerik.JustMock.Helpers;

namespace ProductRegistrySystem.BusinessTests.Services
{
    [TestFixture]
    public class ProductServiceTests
    {
        private ProductService _productService;
        private IDiscountService _discountService;
        private IProductHandlingService _productHandlingService;
        private IProductRepository _productRepository;

        [SetUp]
        public void SetUp()
        {
            _productHandlingService = Mock.Create<IProductHandlingService>();
            _discountService = Mock.Create<IDiscountService>(Behavior.Strict);
            _productRepository = Mock.Create<IProductRepository>(Behavior.Strict);
            _productService = new ProductService(_productRepository, _discountService, _productHandlingService);
        }

        [Test]
        public async Task Can_GetProductById_When_ProductIsFound_Returns_ProductDto()
        {
            // Arrange
            var productId = 1;
            var product = new Product()
            {
                Id = productId, 
                Price = 100000, 
                Status = 1, 
                Description = "Any description", 
                Name = "Any name",
                Stock = 122
            };
            _discountService.Arrange(s => s.GetDiscountByProductAsync(productId, Arg.IsAny<CancellationToken>())).TaskResult(0.2);
            _productRepository.Arrange(s => s.GetById(productId)).Returns(product);

            // Act
            var result = await _productService.GetProductById(productId, Arg.IsAny<CancellationToken>());

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(product.Id, result.Id);
            Assert.AreEqual(product.Description, result.Description);
        }

        [Test]
        public async Task Can_GetProductById_When_ProductIsNotFound_Returns_Null()
        {
            // Arrange
            var productId = 1;
            _discountService.Arrange(s => s.GetDiscountByProductAsync(productId, Arg.IsAny<CancellationToken>())).TaskResult(0.2);
            _productRepository.Arrange(s => s.GetById(productId)).Returns((Product)null);

            // Act
            var result = await _productService.GetProductById(productId, Arg.IsAny<CancellationToken>());

            // Assert
            Assert.IsNull(result);
        }

        [Test]
        public async Task Can_CreateProductAsync_Returns_CreatedProduct()
        {
            // Arrange
            var createProduct = new CreateProductDto()
            {
                Price = 10000,
                Status = 1,
                Description = "Any description",
                Name = "Any name",
                Stock = 123
            };

            var product = new CreateProductMapper().Get(createProduct);

            _discountService.Arrange(s => s.GetDiscountByProductAsync(Arg.AnyInt, Arg.IsAny<CancellationToken>())).TaskResult(0.2);
            _productRepository.Arrange(s => s.GetById(Arg.AnyInt)).Returns(product);
            _productRepository.Arrange(s => s.Add(Arg.IsAny<Product>()));
            _productRepository.Arrange(s => s.SaveChangesAsync(Arg.IsAny<CancellationToken>())).TaskResult(1);

            // Act
            var result = await _productService.CreateProductAsync(createProduct, Arg.IsAny<CancellationToken>());

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(createProduct.Description, result.Description);
        }

        [Test]
        public async Task Can_UpdateProductAsync_When_ProductIsFound_Returns_UpdatedProduct()
        {
            // Arrange
            var product = new Product()
            {
                Id = 1,
                Price = 100000,
                Status = 1,
                Description = "Any description",
                Name = "Any name",
                Stock = 122
            };

            var updateProduct = new UpdateProductDto()
            {
                Description = "Any description updated",
                Name = "Any name updated"
            };
            _productRepository.Arrange(s => s.GetById(Arg.AnyInt)).Returns(product);
            _productRepository.Arrange(s => s.Update(Arg.IsAny<Product>()));
            _productRepository.Arrange(s => s.SaveChangesAsync(Arg.IsAny<CancellationToken>())).TaskResult(1);
            _discountService.Arrange(s => s.GetDiscountByProductAsync(Arg.AnyInt, Arg.IsAny<CancellationToken>())).TaskResult(0.2);

            // Act
            var result = await _productService.UpdateProductAsync(1, updateProduct, Arg.IsAny<CancellationToken>());

            // Assert
            Assert.IsNotNull(result);
            Assert.AreNotEqual(result.Description, "Any description");
            Assert.AreEqual(updateProduct.Name, result.Name);
        }

        [Test]
        public async Task Can_UpdateProductAsync_When_ProductIsNotFound_Returns_Null()
        {
            // Arrange
            var updateProduct = new UpdateProductDto()
            {
                Description = "Any description updated",
                Name = "Any name updated"
            };
            _productRepository.Arrange(s => s.GetById(Arg.AnyInt)).Returns((Product)null);
            
            // Act
            var result = await _productService.UpdateProductAsync(1, updateProduct, Arg.IsAny<CancellationToken>());

            // Assert
            Assert.IsNull(result);
        }
    }
}
