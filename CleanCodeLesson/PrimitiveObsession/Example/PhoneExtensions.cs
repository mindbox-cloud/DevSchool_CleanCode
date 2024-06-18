#nullable disable

using System.Globalization;

namespace Itc.DirectCrm.Model
{
	using System.Text.RegularExpressions;

	public static class PhoneExtensions
	{
		private static readonly Regex _phoneNormalizationRegex = new(
			"[^0-9]",
			RegexOptions.Compiled | RegexOptions.CultureInvariant | RegexOptions.Singleline);
		
		public static bool IsValidAllowedPhone(this string value)
		{
			if (value == null)
				throw new ArgumentNullException(nameof(value));

			return long.TryParse(value.NormalizeRussianPhone(), out var phone);
		}

		public static long? TryParsePhone(
			this string phoneString,
			bool isForAllowedCountries = true)
		{
			if (phoneString == null)
				throw new ArgumentNullException(nameof(phoneString));

			var normalizedPhoneString = isForAllowedCountries
				? phoneString.NormalizeRussianPhone()
				: phoneString.NormalizeInternationalPhone();

			if (long.TryParse(normalizedPhoneString, NumberStyles.Any, CultureInfo.InvariantCulture, out var result))
				return result;

			return null;
		}
		
		public static string NormalizeRussianPhone(this string value)
		{
			if (value == null)
				throw new ArgumentNullException(nameof(value));

			var result = _phoneNormalizationRegex.Replace(value, string.Empty);

			if (result.Length is < 10 or > 11)
				return value;

			if (result.Length == 10)
				result = "7" + result;

			if (result[0] == '8')
				result = "7" + result[1..];

			if (result[0] != '7')
				return value;

			return result;
		}
		public static string NormalizeInternationalPhone(this string value)
		{
			if (value == null)
				throw new ArgumentNullException(nameof(value));

			return _phoneNormalizationRegex.Replace(value, string.Empty);
		}
	}
}
