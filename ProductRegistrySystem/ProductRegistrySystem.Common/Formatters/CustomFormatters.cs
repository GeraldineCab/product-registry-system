using System.Globalization;

namespace ProductRegistrySystem.Common.Formatters
{
    public static class CustomFormatters
    {
        /// <summary>
        /// Transforms a double into a string with currency format
        /// </summary>
        public static string ApplyCurrencyFormat(double value)
        {
            return value.ToString("C", CultureInfo.CurrentCulture);
        }

        /// <summary>
        /// Transforms a double into a string with percentage format
        /// </summary>
        public static string ApplyPercentageFormat(double? value)
        {
            return value?.ToString("P", CultureInfo.InvariantCulture);
        }
    }
}
