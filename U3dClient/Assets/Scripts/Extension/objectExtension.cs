


public static class objectExtension
{
    public static string ToSafeString(this object obj)
    {
        if (null == obj)
        {
            return "";//这儿可以自定义返回值
        }
        else
        {
            return obj.ToString( );
        }
    }
}