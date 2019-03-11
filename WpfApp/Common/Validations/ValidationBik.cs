using System.Globalization;
using System.Windows.Controls;

namespace WpfApp.Common.Validations
{
    public class ValidationBik : ValidationRule
    {
        public override ValidationResult Validate(object value, CultureInfo cultureInfo)
        {
            if (value == null
                || string.IsNullOrWhiteSpace(value.ToString())
                || string.IsNullOrEmpty(value.ToString())) return new ValidationResult(false, "Номер БИК не может быть пустым!");
            if (value.ToString().Length != 9) return new ValidationResult(false, "Номер БИК не может быть короче или больше 9 символов!");
            return ValidationResult.ValidResult;
        }
    }
}