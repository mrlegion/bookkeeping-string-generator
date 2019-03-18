using System;
using System.Globalization;
using System.Text.RegularExpressions;
using System.Windows.Controls;

namespace WpfApp.Common.Validations
{
    public class ValidationTotal : ValidationRule
    {
        public override ValidationResult Validate(object value, CultureInfo cultureInfo)
        {
            if (value == null) return new ValidationResult(false, "Сумма не может быть пустой");

            string total = value as string;
            if (string.IsNullOrEmpty(total) || string.IsNullOrWhiteSpace(total))
                return new ValidationResult(false, "Сумма не может быть пустой");

            if (Regex.IsMatch(total, "[^\\W\\d]+", RegexOptions.IgnoreCase | RegexOptions.Compiled))
                return new ValidationResult(false, "Сумма не может содержать буквы");

            if (Regex.IsMatch(total, "[-,\\.]", RegexOptions.Compiled))
            {
                // проверка на количество символов разделителя
                int count = 0;
                var array = total.ToCharArray();
                foreach (char c in array)
                    if (Regex.IsMatch(c.ToString(), "[-,\\.]", RegexOptions.Compiled))
                        count++;
                if (count > 1) return new ValidationResult(false, "В сумме может быть только один символ деления");

                // проверка на длину копеек
                int index = 0;
                string[] str = new string[0];
                if (total.Contains("-"))
                {
                    index = total.IndexOf('-');
                    str = total.Split('-');
                }
                else if (total.Contains("."))
                {
                    index = total.IndexOf(".", StringComparison.Ordinal);
                    str = total.Split('.');
                }
                else if (total.Contains(","))
                {
                    index = total.IndexOf(",", StringComparison.Ordinal);
                    str = total.Split(',');
                }
                else if (index == 0 && str.Length == 0) return ValidationResult.ValidResult;
                
                if (str[1].Length > 2) return new ValidationResult(false, "В сумме может быть только 2 символа копеек");
            }

            return ValidationResult.ValidResult;
        }
    }
}