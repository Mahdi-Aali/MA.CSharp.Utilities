using System.Text;

namespace MA.CSharp.Utilities.Text;

public static class StringUtilities
{
    public static bool IsNullOrEmpty(this string value) => string.IsNullOrEmpty(value);
    public static bool IsNotNullOrEmpty(this string value) => !string.IsNullOrEmpty(value);
    public static bool IsNullOrWhiteSpace(this string value) => string.IsNullOrWhiteSpace(value);
    public static bool IsNotNullOrWhiteSpace(this string value) => !string.IsNullOrWhiteSpace(value);
    public static byte[] GetUtf8Bytes(this string value) => Encoding.UTF8.GetBytes(value);
    public static byte[] GetUtf32Bytes(this string value) => Encoding.UTF32.GetBytes(value);
    public static string GetUtf8StringFromBytes(this byte[] bytes) => Encoding.UTF8.GetString(bytes);
    public static string GetUtf32StringFromBytes(this byte[] bytes) => Encoding.UTF32.GetString(bytes);
}
