using System;
using System.Collections.Generic;
using System.Text;

namespace Day03;

internal class BatteryBank
{
    private const int BankLenth = 12;

    private string _sequence = string.Empty;

    public BatteryBank(string sequence)
    {
        _sequence = sequence;
    }

    public long Joltage12()
    {
        string result = string.Empty;
        int remainderRequired = BankLenth - 1;
        string sequence = _sequence;

        while (remainderRequired >= 0)
        {
            int foo = sequence.Length - remainderRequired;
            string bar = sequence[..foo];
            (int value, int index) = MaxDigitAndIndex(bar);

            result += value.ToString();
            sequence = sequence[(index + 1)..];
            --remainderRequired;
        }

        return long.Parse(result);
    }

    public int Joltage()
    {
        int result = MaxLeadingDigitWithRemainder();
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

    private (int maxDigit, int index) MaxDigitAndIndex(string sequence)
    {
        int max = 0;
        int maxIndex = -1;
        for (int i = 0; i < sequence.Length; i++)
        {
            int digit = sequence[i] - '0';
            if (digit > max)
            {
                max = digit;
                maxIndex = i;
            }
        }
        return (max, maxIndex);
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
