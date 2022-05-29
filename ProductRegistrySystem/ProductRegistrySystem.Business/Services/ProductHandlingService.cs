using System;
using ProductRegistrySystem.Business.Services.Interfaces;
using ProductRegistrySystem.Common.Calculators;
using ProductRegistrySystem.Common.Enums;
using ProductRegistrySystem.Common.Formatters;
using ProductRegistrySystem.Dto.Product;

namespace ProductRegistrySystem.Business.Services
{
    public class ProductHandlingService : IProductHandlingService
    {
        private readonly ICacheHelper _cacheHelper;

        public ProductHandlingService(ICacheHelper cacheHelper)
        {
            _cacheHelper = cacheHelper ?? throw new ArgumentNullException(nameof(cacheHelper));
        }

        /// <inheritdoc />
        public void FormatStatusName(ProductDto productDto)
        {
            var status = _cacheHelper.GetStatusFromCache(productDto.Id);
            productDto.StatusName = ((StatusEnum.Status)status).ToString();
        }

        /// <inheritdoc />
        public void FormatDiscount(ProductDto productDto, double? discount)
        {
            productDto.Discount = CustomFormatters.ApplyPercentageFormat(discount);
        }

        /// <inheritdoc />
        public void FormatFinalPrice(ProductDto productDto, double? discount)
        {
            productDto.FinalPrice = PriceCalculator.GetPriceWithDiscount(productDto.Price, discount);
        }
        
        /// <inheritdoc />
        public void FormatPrice(ProductDto productDto)
        {
            productDto.Price = CustomFormatters.ApplyCurrencyFormat(double.Parse(productDto.Price));
        }
    }
}
