using System.Text.RegularExpressions;

namespace Core.Helpers
{
    public static class StringExtensions
    {
        private static readonly Regex digitsRegex = new Regex(@"\d", RegexOptions.Compiled | RegexOptions.Singleline);

        private static readonly Regex nonDigitsRegex = new Regex(@"\D", RegexOptions.Compiled | RegexOptions.Singleline);

        public static string ReplaceDigits(this string text, string replacement) => digitsRegex.Replace(text ?? "", replacement);

        public static string StripNonDigits(this string text) => nonDigitsRegex.Replace(text ?? "", "");
    }
}
