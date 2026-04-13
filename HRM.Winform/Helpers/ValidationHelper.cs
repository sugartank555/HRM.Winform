using System.Net.Mail;
using System.Text.RegularExpressions;

namespace HRM.Winform.Helpers
{
    public static class ValidationHelper
    {
        private static readonly Regex UsernameRegex = new("^[A-Za-z0-9._-]{4,50}$", RegexOptions.Compiled);
        private static readonly Regex DigitsOnlyRegex = new("^\\d+$", RegexOptions.Compiled);
        private static readonly Regex VnPhoneRegex = new("^(0|\\+84)\\d{9,10}$", RegexOptions.Compiled);

        public static string NormalizeCode(string? value) => (value ?? string.Empty).Trim().ToUpperInvariant();

        public static string NormalizeText(string? value) => (value ?? string.Empty).Trim();

        public static string? NormalizeOptional(string? value)
        {
            var normalized = NormalizeText(value);
            return string.IsNullOrWhiteSpace(normalized) ? null : normalized;
        }

        public static bool IsValidEmail(string? email)
        {
            if (string.IsNullOrWhiteSpace(email))
            {
                return false;
            }

            try
            {
                _ = new MailAddress(email);
                return true;
            }
            catch
            {
                return false;
            }
        }

        public static bool IsValidVietnamesePhone(string? phone)
        {
            if (string.IsNullOrWhiteSpace(phone))
            {
                return false;
            }

            var normalized = phone.Replace(" ", string.Empty).Trim();
            return VnPhoneRegex.IsMatch(normalized);
        }

        public static bool IsValidCitizenId(string? citizenId)
        {
            if (string.IsNullOrWhiteSpace(citizenId))
            {
                return false;
            }

            var normalized = citizenId.Trim();
            return normalized.Length == 12 && DigitsOnlyRegex.IsMatch(normalized);
        }

        public static bool IsValidUsername(string? username)
        {
            if (string.IsNullOrWhiteSpace(username))
            {
                return false;
            }

            return UsernameRegex.IsMatch(username.Trim());
        }

        public static bool IsStrongEnoughPassword(string? password)
        {
            return !string.IsNullOrWhiteSpace(password) && password.Trim().Length >= 6;
        }

        public static int CalculateFullAge(DateTime birthDate, DateTime atDate)
        {
            var age = atDate.Year - birthDate.Year;
            if (birthDate.Date > atDate.Date.AddYears(-age))
            {
                age--;
            }

            return age;
        }
    }
}
