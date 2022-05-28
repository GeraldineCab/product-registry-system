using System;
using System.Threading;
using System.Threading.Tasks;
using ProductRegistrySystem.Business.Mappers;
using ProductRegistrySystem.Business.Services.Interfaces;
using ProductRegistrySystem.Business.Utils;
using ProductRegistrySystem.Dto.Product;
using ProductRegistrySystem.Persistence.Repositories.Interfaces;

namespace ProductRegistrySystem.Business.Services
{
    public class ProductService : IProductService
    {
        private readonly IProductRepository _productRepository;
        private readonly IDiscountService _discountService;

        public ProductService(IProductRepository productRepository, IDiscountService discountService)
        {
            _productRepository = productRepository ?? throw new ArgumentNullException(nameof(productRepository));
            _discountService = discountService ?? throw new ArgumentNullException(nameof(discountService));
        }

        /// <inheritdoc />
        public async Task<ProductDto> GetProductById(int productId, CancellationToken cancellationToken)
        {
            var discount = await _discountService.GetDiscountByProductAsync(productId, cancellationToken);
            var product = _productRepository.GetById(productId);

            if (product == null)
            {
                return null;
            }

            var mapper = new ProductMapper();
            var productDto = mapper.Get(product);
            ProductHandling.FormatProduct(productDto, product, discount);

            return productDto;
        }

        /// <inheritdoc />
        public async Task<ProductDto> CreateProductAsync(CreateProductDto createProductDto, CancellationToken cancellationToken)
        {
            var createMapper = new CreateProductMapper();
            var mapper = new ProductMapper();
            var product = createMapper.Get(createProductDto);

            _productRepository.Add(product);
            await _productRepository.SaveChangesAsync(cancellationToken);

            return mapper.Get(product);
        }

        /// <inheritdoc />
        public async Task<ProductDto> UpdateProductAsync(int productId, UpdateProductDto updateProductDto, CancellationToken cancellationToken)
        {
            var product = _productRepository.GetById(productId);

            if (product == null)
            {
                return null;
            }

            product.Name = updateProductDto.Name;
            product.Price = updateProductDto.Price;
            product.Description = updateProductDto.Description;
            product.Status = updateProductDto.Status;
            product.Stock = updateProductDto.Stock;

            _productRepository.Update(product);
            await _productRepository.SaveChangesAsync(cancellationToken);

            var mapper = new ProductMapper();
            return mapper.Get(product);
        }
    }
}
