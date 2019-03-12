using System.Globalization;
using System.Windows.Controls;

namespace WpfApp.Common.Validations
{
    public class ValidationInn : ValidationRule
    {
        public override ValidationResult Validate(object value, CultureInfo cultureInfo)
        {
            if (value == null) return new ValidationResult(false, "Номер ИНН не может быть пустым!");

            var inn = value.ToString();

            if (string.IsNullOrWhiteSpace(inn) || string.IsNullOrEmpty(inn))
                return new ValidationResult(false, "Номер ИНН не может быть пустым!");

            if (inn.Length >= 9 && inn.Length <= 12) return ValidationResult.ValidResult;

            return new ValidationResult(false, "Номер ИНН не может быть короче или больше 9 символов!");
        }
    }
}