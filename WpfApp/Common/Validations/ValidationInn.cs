using System.Globalization;
using System.Windows.Controls;

namespace WpfApp.Common.Validations
{
    public class ValidationInn : ValidationRule
    {
        public override ValidationResult Validate(object value, CultureInfo cultureInfo)
        {
            if (value == null
                || string.IsNullOrWhiteSpace(value.ToString())
                || string.IsNullOrEmpty(value.ToString())) return new ValidationResult(false, "Номер ИНН не может быть пустым!");
            if (value.ToString().Length < 9) return new ValidationResult(false, "Номер ИНН не может быть короче 9 символов!");
            return ValidationResult.ValidResult;
        }
    }
}