#nullable disable

namespace CleanCodeLesson.Examples.PrimitiveObsession;

using System.Globalization;
using System.Text.RegularExpressions;

public static class PhoneExtensions
{
    private static readonly Regex _phoneNormalizationRegex = new(
        "[^0-9]",
        RegexOptions.Compiled | RegexOptions.CultureInvariant | RegexOptions.Singleline);


    public static long? TryParsePhone(
        this string phoneString)
    {
        if (phoneString == null)
            throw new ArgumentNullException(nameof(phoneString));

        var normalizedPhoneString = phoneString.NormalizeInternationalPhone();

        if (long.TryParse(normalizedPhoneString, NumberStyles.Any, CultureInfo.InvariantCulture, out var result))
            return result;

        return null;
    }

    public static string NormalizeInternationalPhone(this string value)
    {
        if (value == null)
            throw new ArgumentNullException(nameof(value));

        return _phoneNormalizationRegex.Replace(value, string.Empty);
    }
}