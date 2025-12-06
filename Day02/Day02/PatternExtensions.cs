namespace Day02;

internal static class PatternExtensions
{
    // Extension for String
    public static bool IsPattern(this string input)
    {
        if (string.IsNullOrEmpty(input)) return false;
        if (input.Length % 2 != 0) return false;

        // split the string into two halves
        int mid = input.Length / 2;
        string firstHalf = input[..mid];
        string secondHalf = input[mid..];

        return firstHalf == secondHalf;
    }

    // Extension for Long
    public static bool IsPattern(this long number) =>
        number.ToString().IsPattern();
}
