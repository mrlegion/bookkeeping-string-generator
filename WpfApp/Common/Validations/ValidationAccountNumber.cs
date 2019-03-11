using System.Globalization;
using System.Windows.Controls;

namespace WpfApp.Common.Validations
{
    public class ValidationAccountNumber : ValidationRule
    {
        public override ValidationResult Validate(object value, CultureInfo cultureInfo)
        {
            if (value == null 
                || string.IsNullOrWhiteSpace(value.ToString()) 
                || string.IsNullOrEmpty(value.ToString())) return new ValidationResult(false, "Номер счёта не может быть пустым!");
            if (value.ToString().Length != 20) return new ValidationResult(false, "Номер счёта не может быть короче 20 символов!");
            return ValidationResult.ValidResult;
        }
    }
}