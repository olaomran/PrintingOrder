using System.Globalization;

namespace PrintingOrder.Helper
{
 
        public static class NumberExtensions
        {
            public static string ToSeparated(this int number)
            {
                return number.ToString("N0", CultureInfo.InvariantCulture);
            }

            public static string ToSeparated(this decimal number)
            {
                return number.ToString("N0", CultureInfo.InvariantCulture);
            }

            public static string ToSeparated(this double number)
            {
                return number.ToString("N0", CultureInfo.InvariantCulture);
            }
        }
    }

