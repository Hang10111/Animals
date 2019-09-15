using System;

namespace Animals.Server.Extensions
{
    public static class StringExtensions
    {
        public static string ConvertToURLString(this string source)
        {
            var subString = source.Substring(2);
            return String.Concat("http://192.168.1.200:10000", subString);
        }
    }
}
