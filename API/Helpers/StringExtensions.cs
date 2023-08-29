using System.Text.RegularExpressions;

namespace API.Helpers
{
    public static class StringExtensions
    {
        private static readonly Regex regex = new Regex(@"\s+");

        public static string RemoveWhiteSpaces(this string str)
        {
            return regex.Replace(str, " ");
        }
    }
}
