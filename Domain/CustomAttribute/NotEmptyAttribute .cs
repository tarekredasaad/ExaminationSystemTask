using System.ComponentModel.DataAnnotations;

namespace DynamicAuthApi.CustomAttribute
{
    public class NotEmptyAttribute : ValidationAttribute
    {
        public override bool IsValid(object value)
        {
            if (value == null)
                return false;

            var str = value as string;
            return !string.IsNullOrWhiteSpace(str);
        }

        public override string FormatErrorMessage(string name)
        {
            return $"{name} cannot be empty or whitespace.";
        }
    }
}
