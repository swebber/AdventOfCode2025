using System;
using System.Collections.Generic;
using System.Text;

namespace Day03;

internal class BatteryBank
{
    private string _sequence = string.Empty;

    public BatteryBank(string sequence)
    {
        _sequence = sequence;
    }

    public int Joltage()
    {
        int result = MaxLeadingDigitWithRemainder();
        Console.WriteLine($"Sequence {_sequence}, Joltage {result}");
        return result;
    }

    private int MaxDigit(string sequence)
    {
        int max = 0;
        foreach (char c in sequence)
        {
            int digit = c - '0';
            if (digit > max)
                max = digit;
        }
        return max;
    }

    private int MaxLeadingDigitWithRemainder()
    {
        int max = 0;
        int maxIndex = -1;
        var leading = _sequence[..^1];
        for (int i = 0; i < leading.Length; i++)
        {
            int digit = leading[i] - '0';
            if (digit > max)
            {
                max = digit;
                maxIndex = i;
            }
        }

        string beyond = (maxIndex >= 0 && maxIndex + 1 < _sequence.Length) ? _sequence[(maxIndex + 1)..] : string.Empty;
        var beyondMaxDigit = MaxDigit(beyond);

        int result = (max * 10) + beyondMaxDigit;

        return result;
    }
}
