namespace CLA_Administration_Web.Helpers.Shared
{
    public class SharedFunctions
    {
        public static long GetTimeInMilliseconds(string date)
        {
            var a = DateTime.Parse(date);
            var b = (DateTimeOffset)a;

            var milliseconds = b.ToUnixTimeMilliseconds();

            return milliseconds;
        }

        public static string StringTruncate(string value, int maxLength, string truncationSuffix = "…")
        {
            var truncated = value?.Length > maxLength ? value.Substring(0, maxLength) + truncationSuffix : value;

            return truncated;
        }

        public static string CapitalizeFirst(string input)
        {
            return char.ToUpper(input[0]) + input[1..];
        }

    }
}
