using System.Threading;
using System.Threading.Tasks;
using ProductRegistrySystem.Dto;

namespace ProductRegistrySystem.Business.Services.Interfaces
{
    public interface IProductService
    {
        /// <summary>
        /// Gets a product by id
        /// </summary>
        /// <param name="productId">The product id</param>
        /// <param name="cancellationToken"></param>
        /// <returns>An instance of <see cref="ProductDto"/></returns>
        Task<ProductDto> GetProductById(int productId, CancellationToken cancellationToken);

        /// <summary>
        /// Creates a new product
        /// </summary>
        /// <param name="createProductDto">The creation object</param>
        /// <returns>The created product</returns>
        Task<ProductDto> CreateProductAsync(CreateProductDto createProductDto);
    }
}
