using System.Globalization;
using System.Windows.Controls;

namespace WpfApp.Common.Validations
{
    public class ValidationBik : ValidationRule
    {
        public override ValidationResult Validate(object value, CultureInfo cultureInfo)
        {
            if (value == null) return new ValidationResult(false, "Номер БИК не может быть пустым!");

            var bik = value.ToString();

            if (string.IsNullOrWhiteSpace(bik) || string.IsNullOrEmpty(bik))
                return new ValidationResult(false, "Номер БИК не может быть пустым!");

            if (bik.Length == 9) return ValidationResult.ValidResult;

            return new ValidationResult(false, "Номер БИК не может быть короче или больше 9 символов!");
        }
    }
}