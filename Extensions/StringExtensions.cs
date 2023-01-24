namespace Task1_0.Extensions
{
    public static class StringExtensions
    {
        public static string SplitWithoutSpaces(this string text, char separator, int index) => Regex.Replace(text.Trim(), @"\s+", "").Split(separator)[index];
    }
}