using ProductRegistrySystem.Common.Formatters;

namespace ProductRegistrySystem.Common.Calculators
{
    public static class PriceCalculator
    {
        /// <summary>
        /// Calculates the final product price
        /// </summary>
        /// <param name="price">The product current price</param>
        /// <param name="discount">The product price retrieved from the Discount api</param>
        /// <returns>If discount is null, the current price is returned, otherwise, the price with discount is returned.</returns>
        public static string GetPriceWithDiscount(string price, double? discount)
        {
            var priceDouble = double.Parse(price);
            if (discount == null)
            {
                return CustomFormatters.ApplyCurrencyFormat(priceDouble);
            }

            var priceWithDiscount = priceDouble * (1 - discount.Value);
            return CustomFormatters.ApplyCurrencyFormat(priceWithDiscount);
        }
    }
}
