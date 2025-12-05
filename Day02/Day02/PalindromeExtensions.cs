using System;
using System.Collections.Generic;
using System.Text;

namespace Day02;

public static class PalindromeExtensions
{
    // Extension for string
    public static bool IsPalindrome(this string input)
    {
        if (input == null) return false;
        var filtered = new string(input.Where(char.IsLetterOrDigit).ToArray()).ToLower();
        int left = 0, right = filtered.Length - 1;
        while (left < right)
        {
            if (filtered[left] != filtered[right])
                return false;
            left++;
            right--;
        }
        return true;
    }

    // Extension for int
    public static bool IsPalindrome(this int number)
    {
        return number.ToString().IsPalindrome();
    }

    // Extension for long
    public static bool IsPalindrome(this long number)
    {
        return number.ToString().IsPalindrome();
    }
}
