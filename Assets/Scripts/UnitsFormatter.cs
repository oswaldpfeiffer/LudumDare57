using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class UnitsFormatter
{
    private static readonly string[] _suffixes = { "", "K", "M", "B", "T", "Qa", "Qi", "Sx", "Sp", "Oc", "No", "Dc" };

    public static string Format(double value)
    {
        if (value < 1000)
            return value.ToString("0");

        int exponent = (int)Math.Floor(Math.Log(value, 1000));
        exponent = Math.Min(exponent, _suffixes.Length - 1);

        double shortValue = value / Math.Pow(1000, exponent);
        return shortValue.ToString("0.##") + _suffixes[exponent];
    }
}
