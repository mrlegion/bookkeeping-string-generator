using System.Globalization;
using System.Windows.Controls;

namespace WpfApp.Common.Validations
{
    public class ValidationAccountNumber : ValidationRule
    {
        public override ValidationResult Validate(object value, CultureInfo cultureInfo)
        {
            if (value == null) return new ValidationResult(false, "Номер счёта не может быть пустым!");

            var number = value.ToString();

            if (string.IsNullOrWhiteSpace(number) || string.IsNullOrEmpty(number))
                return new ValidationResult(false, "Номер счёта не может быть пустым!");

            if (number.Length == 20) return ValidationResult.ValidResult;

            return new ValidationResult(false, "Номер счёта не может быть короче 20 символов!");
        }
    }
}