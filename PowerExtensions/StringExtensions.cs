using System.Text;
using System.Text.RegularExpressions;

namespace PowerExtensions
{
    public static class StringExtensions
    {

        /// <summary>
        /// If the given string's length is greater then the specify length then truncate it and append the specific overflow text
        /// </summary>
        /// <param name="s">The given string</param>
        /// <param name="length">The maximum length of the output</param>
        /// <param name="overflow">The overflow text</param>
        /// <returns>The truncated string</returns>
        public static string Truncate(this string s, int length = 120, string overflow = "...")
        {
            if (string.IsNullOrWhiteSpace(s))
            {
                return string.Empty;
            }

            if (s.Length <= length)
            {
                return s;
            }

            return s.Substring(0, length) + (string.IsNullOrWhiteSpace(overflow) ? string.Empty : overflow);
        }

        /// <summary>
        /// If the given string is null or whitespace, return the specify fallback value
        /// </summary>
        /// <param name="s">The given string</param>
        /// <param name="fallback">The fallback value, it's never be null</param>
        /// <returns>The output string never be null</returns>
        public static string UseFallback(this string s, string fallback = "")
        {
            if (string.IsNullOrWhiteSpace(s))
            {
                return string.IsNullOrWhiteSpace(fallback) ? string.Empty : fallback;
            }

            return s;
        }

        /// <summary>
        /// Remove the diacritical marks from the input string
        /// </summary>
        /// <param name="input">The input string</param>
        /// <returns>The output string without marks</returns>
        public static string RemoveMark(this string input)
        {
            var regex = new Regex("\\p{IsCombiningDiacriticalMarks}+");
            var formD = input.Normalize(NormalizationForm.FormD);

            return regex.Replace(formD, string.Empty)
                .Replace('\u0111', 'd')
                .Replace('\u0110', 'D');
        }

        /// <summary>
        /// Convert a string into friendly url form with hiphen between words
        /// </summary>
        /// <param name="input">The input string</param>
        /// <param name="length">The maximum length of result</param>
        /// <returns>The string result</returns>
        public static string ToFriendlyUrl(this string input, int length = 125)
        {
            if (string.IsNullOrEmpty(input))
            {
                return string.Empty;
            }

            var slug = input.RemoveMark().ToLower();

            // remove invalid chars
            slug = Regex.Replace(slug, @"[^a-z0-9\s-]", string.Empty);

            // convert multiple spaces into one
            slug = Regex.Replace(slug, "\\s+", " ").Trim();
            slug = Regex.Replace(slug, "\\s", "-");
            slug = Regex.Replace(slug, "-+", "-");
            slug = slug.Trim('-');

            // cut and trim            
            return slug.Truncate(length, string.Empty);
        }

        /// <summary>
        /// Uppercase the fist letter of the given string
        /// </summary>
        /// <param name="s">The given string</param>
        /// <param name="toLowerCaseTheRest">If true then make all the text lowercase</param>
        /// <returns>The result string</returns>
        public static string ToUpperFirstLetter(this string s, bool toLowerCaseTheRest = false)
        {
            if (string.IsNullOrWhiteSpace(s))
            {
                return string.Empty;
            }

            if (toLowerCaseTheRest)
            {
                s = s.ToLower();
            }

            if (s.Length == 1)
            {
                return s.ToUpper();
            }

            return s.Substring(0, 1).ToUpper() + s.Substring(1);
        }
    }
}
