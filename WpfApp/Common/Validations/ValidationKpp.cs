using System.Globalization;
using System.Windows.Controls;

namespace WpfApp.Common.Validations
{
    public class ValidationKpp : ValidationRule
    {
        public override ValidationResult Validate(object value, CultureInfo cultureInfo)
        {
            if (value == null) return new ValidationResult(false, "Номер КПП не может быть пустым!");

            var kpp = value.ToString();

            if (string.IsNullOrWhiteSpace(kpp) || string.IsNullOrEmpty(kpp))
                return new ValidationResult(false, "Номер КПП не может быть пустым!");

            if (kpp == "0" || kpp.Length == 9) return ValidationResult.ValidResult;

            return new ValidationResult(false, "Номер КПП не может быть короче или больше 9 символов!");
            
        }
    }
}