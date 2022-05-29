using System.Threading;
using System.Threading.Tasks;
using ProductRegistrySystem.Dto.Product;

namespace ProductRegistrySystem.Business.Services.Interfaces
{
    public interface IProductService
    {
        /// <summary>
        /// Gets a product by id
        /// </summary>
        /// <param name="productId">The product id</param>
        /// <param name="cancellationToken">Transaction cancellation token</param>
        /// <returns>An instance of <see cref="ProductDto"/></returns>
        Task<ProductDto> GetProductById(int productId, CancellationToken cancellationToken);

        /// <summary>
        /// Creates a new product
        /// </summary>
        /// <param name="createProductDto">The creation object</param>
        /// <param name="cancellationToken">Transaction cancellation token</param>
        /// <returns>The created product</returns>
        Task<ProductDto> CreateProductAsync(CreateProductDto createProductDto, CancellationToken cancellationToken);

        /// <summary>
        /// Updates the product matching the given id
        /// </summary>
        /// <param name="productId">The product id</param>
        /// <param name="updateProductDto">The update object</param>
        /// <param name="cancellationToken">Transaction cancellation token</param>
        /// <returns>The updated product</returns>
        Task<ProductDto> UpdateProductAsync(int productId, UpdateProductDto updateProductDto, CancellationToken cancellationToken);
    }
}
