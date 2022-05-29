using ProductRegistrySystem.Dto.Product;
using ProductRegistrySystem.Persistence.Entities;

namespace ProductRegistrySystem.Business.Services.Interfaces
{
    public interface IProductHandlingService
    {
        /// <summary>
        /// Gets the corresponding status name according to the given number
        /// </summary>
        void FormatStatusName(ProductDto productDto, Product productEntity);

        /// <summary>
        /// Applies the percentage format to the given value
        /// </summary>
        void FormatDiscount(ProductDto productDto, double? discount);

        /// <summary>
        /// Retrieves a product final price
        /// </summary>
        void FormatFinalPrice(ProductDto productDto, double? discount);

        /// <summary>
        /// Applies the currency format to the given value
        /// </summary>
        void FormatPrice(ProductDto productDto);
    }
}
