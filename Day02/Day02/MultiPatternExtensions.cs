namespace Day02;

internal static class MultiPatternExtensions
{
    // Extension for String
    public static bool IsMultiPattern(this string input)
    {
        if (string.IsNullOrEmpty(input)) return false;

        // split the string into two halves
        int mid = input.Length / 2;

        for (int i = 1; i <= mid; i++)
        {
            string pattern = input[..i];
            if (IsMadeOfRepeatedPattern(input, pattern))
            {
                //Console.WriteLine($"    Found repeating pattern: {input}, Pattern: {pattern}");
                return true;
            }
        }

        return false;
    }

    // Extension for Long
    public static bool IsMultiPattern(this long number) =>
        number.ToString().IsMultiPattern();

    private static bool IsMadeOfRepeatedPattern(string input, string pattern)
    {
        if (string.IsNullOrEmpty(pattern) || string.IsNullOrEmpty(input)) return false;
        if (input.Length % pattern.Length != 0) return false;
        int repeatCount = input.Length / pattern.Length;
        return string.Concat(Enumerable.Repeat(pattern, repeatCount)) == input;
    }
}
