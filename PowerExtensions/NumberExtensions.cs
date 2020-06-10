
namespace PowerExtensions
{
    public static class NumberExtensions
    {
        /// <summary>
        /// Parse the given number into integer number<br/>
        /// Fallback to the default value if could not parse the input string
        /// </summary>
        /// <param name="s">The input string</param>
        /// <param name="defaultValue">The fallback value</param>
        /// <returns>The number if parse successful or default value if not</returns>
        public static int ToInt(this string s, int defaultValue = 0)
        {
            return int.TryParse(s, out var result) ? result : defaultValue;
        }

        /// <summary>
        /// Parse the given number into integer number
        /// </summary>
        /// <param name="s">The input string</param>
        /// <returns>The number if parse successful or null if not</returns>
        public static int? ToIntNullable(this string s)
        {
            if (int.TryParse(s, out var result))
            {
                return result;
            }

            return null;
        }
    }
}