using ProductRegistrySystem.Common.Calculators;
using ProductRegistrySystem.Common.Enums;
using ProductRegistrySystem.Common.Formatters;
using ProductRegistrySystem.Dto.Product;
using ProductRegistrySystem.Persistence.Entities;

namespace ProductRegistrySystem.Business.Utils
{
    public static class ProductHandling
    {
        public static void FormatProduct(ProductDto productDto, Product productEntity, double? discount)
        {
            productDto.Discount = CustomFormatters.ApplyPercentageFormat(discount);
            productDto.FinalPrice = PriceCalculator.GetPriceWithDiscount(productDto.Price, discount);
            productDto.Price = CustomFormatters.ApplyCurrencyFormat(double.Parse(productDto.Price));
            productDto.StatusName = ((StatusEnum.Status)productEntity.Status).ToString();
        }
    }
}
