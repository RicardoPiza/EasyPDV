using System.Collections.Generic;
using System;

public static class TypeHelper
{
    private static readonly HashSet<Type> NumericTypes = new HashSet<Type>
    {
        typeof(int),  typeof(double),  typeof(decimal),
        typeof(long), typeof(short),   typeof(sbyte),
        typeof(byte), typeof(ulong),   typeof(ushort),
        typeof(uint), typeof(float)
    };

    public static bool IsNumeric(this Type myType)
    {
        return NumericTypes.Contains(Nullable.GetUnderlyingType(myType) ?? myType);
    }

    public static string FormatToCenter(string toFormat)
    {
        double midDouble = (19 - toFormat.Length) / 2;
        int mid = (int) Math.Round(midDouble);
        toFormat = toFormat.PadLeft(mid + toFormat.Length);
        return toFormat;
    }
}