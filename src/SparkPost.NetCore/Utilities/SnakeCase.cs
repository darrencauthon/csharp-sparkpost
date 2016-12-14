using System.Text.RegularExpressions;

namespace SparkPost.Utilities
{
    public static class SnakeCase
    {
        public static string Convert(string input)
        {
            if (input == null) return null;

            var regex = new Regex("[A-Z]");

            var matches = regex.Matches(input);

            for (var i = 0; i < matches.Count; i++)
                input = input.Replace(matches[i].Value, "_" + matches[i].Value.ToLower());

            if (input.StartsWith("_"))
                input = input.Substring(1, input.Length - 1);

            return input;
        }
    }
}