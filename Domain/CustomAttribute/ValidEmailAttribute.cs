using System.ComponentModel.DataAnnotations;
using System.Text.RegularExpressions;

namespace DynamicAuthApi.CustomAttribute
{
    public class ValidEmailAttribute : ValidationAttribute
    {
        public override bool IsValid(object value)
        {
            if (value == null)
                return false;

            var str = value as string;
            if (string.IsNullOrWhiteSpace(str))
                return false;

            var emailPattern = @"^[^@\s]+@[^@\s]+\.[^@\s]+$";
            return Regex.IsMatch(str, emailPattern);
        }

        public override string FormatErrorMessage(string name)
        {
            return $"{name} must be a valid email address.";
        }
    }
}
