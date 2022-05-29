using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using NUnit.Framework;
using ProductRegistrySystem.Api.Controllers;
using ProductRegistrySystem.Business.Services.Interfaces;
using ProductRegistrySystem.Dto.Product;
using Telerik.JustMock;
using Telerik.JustMock.Helpers;

namespace ProductRegistrySystem.ApiTests.Controllers
{
    [TestFixture]
    public class ProductControllerTests
    {
        private ProductController _productController;
        private IProductService _productService;

        [SetUp]
        public void SetUp()
        {
            _productService = Mock.Create<IProductService>(Behavior.Strict);
            _productController = new ProductController(_productService);
        }

        [Test]
        public async Task Can_GetProductById_When_ProductExists_Returns_Ok()
        {
            // Arrange
            int productId = 1;
            _productService.Arrange(s => s.GetProductById(productId, Arg.IsAny<CancellationToken>()))
                .TaskResult(new ProductDto(){ Id = 1 });

            // Act
            var result = await _productController.GetProductByIdAsync(productId, Arg.IsAny<CancellationToken>());

            // Assert
            var content = (result as OkObjectResult)?.Value;
            Assert.IsNotNull(content);
            Assert.That(content as ProductDto, Is.InstanceOf<ProductDto>());
        }

        [Test]
        public async Task Can_GetProductByIdAsync_When_ProductDoesNotExist_Returns_NotFound()
        {
            // Arrange
            int productId = 1;
            _productService.Arrange(s => s.GetProductById(productId, Arg.IsAny<CancellationToken>()))
                .TaskResult((ProductDto)null);

            // Act
            var result = await _productController.GetProductByIdAsync(productId, Arg.IsAny<CancellationToken>());

            // Assert
            var content = (result as NotFoundObjectResult)?.Value;
            Assert.IsNotNull(content);
            Assert.That(((string)content).Contains("No product was"));
        }

        [Test]
        public async Task Can_CreateProductAsync_When_CreateProductDtoIsValid_Returns_Created()
        {
            // Arrange
            var productDto = new ProductDto()
            {
                Id = 1,
                Price = "100000",
                Description = "Any description",
                Name = "Any name",
                StatusName = "Active",
                Stock = 1
            };
            _productService.Arrange(s => s.CreateProductAsync(Arg.IsAny<CreateProductDto>(), Arg.IsAny<CancellationToken>()))
                .TaskResult(productDto);

            // Act
            var result = await _productController.CreateProductAsync(Arg.IsAny<CreateProductDto>(), Arg.IsAny<CancellationToken>());

            // Assert
            var content = (result as CreatedAtRouteResult)?.Value;
            Assert.IsNotNull(content);
            Assert.That(content as ProductDto, Is.InstanceOf<ProductDto>());
        }

        [Test]
        public async Task Can_UpdateProductAsync_When_UpdateProductDtoIsValid_Returns_Created()
        {
            // Arrange
            var productDto = new ProductDto()
            {
                Id = 1,
                Price = "100000",
                Description = "Any description",
                Name = "Any name",
                StatusName = "Active",
                Stock = 1
            };
            _productService.Arrange(s => s.UpdateProductAsync(Arg.AnyInt, Arg.IsAny<UpdateProductDto>(), Arg.IsAny<CancellationToken>()))
                .TaskResult(productDto);

            // Act
            var result = await _productController.UpdateProductAsync(Arg.AnyInt, Arg.IsAny<UpdateProductDto>(), Arg.IsAny<CancellationToken>());

            // Assert
            var content = (result as OkObjectResult)?.Value;
            Assert.IsNotNull(content);
            Assert.That(content as ProductDto, Is.InstanceOf<ProductDto>());
        }

        [Test]
        public async Task Can_CreateProductAsync_When_CreateProductDtoIsInvalid_Shows_ValidationErrors()
        {
            // Arrange
            var createProduct = new CreateProductDto() { Status = 5 };
            _productService.Arrange(s => s.CreateProductAsync(Arg.IsAny<CreateProductDto>(), Arg.IsAny<CancellationToken>()))
                .TaskResult(new ProductDto());
            var validationErrors = SimulateValidation(createProduct);

            // Act
            await _productController.CreateProductAsync(createProduct, Arg.IsAny<CancellationToken>());

            // Assert
            Assert.That(validationErrors.Count, Is.GreaterThan(0));
        }

        [Test]
        public async Task Can_UpdateProductAsync_When_UpdateProductDtoIsInvalid_Shows_ValidationErrors()
        {
            // Arrange
            var updateProduct = new UpdateProductDto() { Status = 5 };
            _productService.Arrange(s => s.UpdateProductAsync(Arg.AnyInt, Arg.IsAny<UpdateProductDto>(), Arg.IsAny<CancellationToken>()))
                .TaskResult((ProductDto)null);
            var validationErrors = SimulateValidation(updateProduct);

            // Act
            await _productController.UpdateProductAsync(Arg.AnyInt, updateProduct, Arg.IsAny<CancellationToken>());

            // Assert
            Assert.That(validationErrors.Count, Is.GreaterThan(0));
        }

        private List<ValidationResult> SimulateValidation(object model)
        {
            var validationContext = new ValidationContext(model, null, null);
            var validationResults = new List<ValidationResult>();
            Validator.TryValidateObject(model, validationContext, validationResults, true);
            return validationResults;
        }
    }
}
