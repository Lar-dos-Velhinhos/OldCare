using System.Globalization;
using System.Text;
using System.Text.RegularExpressions;

namespace OldCare.Contexts.SharedContext.Extensions;

public static class StringExtension
{
    public static string ToNumbersOnly(this string? input) =>
        string.IsNullOrEmpty(input) ? string.Empty : Regex.Replace(input, "[^0-9]", "");

    public static string ToBase64(this string text)
    {
        var bytes = Encoding.ASCII.GetBytes(text);
        return Convert.ToBase64String(bytes);
    }

    public static string FromBase64(this string text)
    {
        var bytes = Convert.FromBase64String(text);
        return Encoding.ASCII.GetString(bytes);
    }

    public static string ToMd5(this string text, string secret)
    {
        if (string.IsNullOrEmpty(text))
            return "";

        var data = $"{text}:{secret}";
        var md5 = System.Security.Cryptography.MD5.Create();
        var bytes = md5.ComputeHash(Encoding.Default.GetBytes(data));
        var result = new StringBuilder();
        foreach (var t in bytes)
            result.Append(t.ToString("x2"));

        return result.ToString();
    }

    public static string ToMany(this string text, int amount, string plural)
        => (amount > 1) ? plural : text;
}