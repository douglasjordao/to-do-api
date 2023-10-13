namespace Utils
{
    public static class StringUtils
    {
        public static bool IsNullOrEmpty(this string? value)
        {
            if (value != null)
            {
                var str = value.Trim();

                return str == string.Empty;
            }

            return true;
        }

        public static bool IsLengthValid(this string? value, int maxLength)
        {
            if (value != null)
            {
                var str = value.Trim();

                return str.Length <= maxLength;
            }

            return false;
        }
    }
}