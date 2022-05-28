using System.Globalization;

namespace ProductRegistrySystem.Common.Formatters
{
    public static class CustomFormatters
    {
        public static string ApplyCurrencyFormat(double value)
        {
            return value.ToString("C", CultureInfo.CurrentCulture);
        }

        public static string ApplyPercentageFormat(double? value)
        {
            return value?.ToString("P", CultureInfo.InvariantCulture);
        }
    }
}
