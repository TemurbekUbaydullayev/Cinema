namespace Cinema.Service.Extensions
{
    public static class Capitalize
    {
        public static string GetCapitalize(this string word)
        {
            return word.Substring(0, 1).ToUpper() + word.Substring(1).ToLower();
        }
    }
}
