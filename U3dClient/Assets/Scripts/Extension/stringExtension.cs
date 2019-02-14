
using System;
public static class stringExtension
{
    public static bool IsNullOrEmpty(this string str)
    {
        return String.IsNullOrEmpty(str);
    }
}
