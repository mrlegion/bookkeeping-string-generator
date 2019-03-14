using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace Domain.Helpers
{
    public class MoneyToString : IIntToString
    {
        private static string[] _numberStrings = new[]
        {
            "", "один", "два", "три", "четыре", "пять", "шесть", "семь", "восемь", "девять",
            "", "одиннадцать", "двенадцать", "тринадцать", "четырнадцать", "пятнадцать", "шестнадцать", "семнадцать", "восемнадцать", "девятнадцать",
            "", "десять", "двадцать", "тридцать", "сорок", "пятьдесят", "шестьдесят", "семьдесят", "восемьдесят", "девяносто",
            "", "сто", "двести", "триста", "четыреста", "пятьсот", "шестьсот", "семьсот", "восемьсот", "девятьсот",
            "тысяч", "тысяча", "тысячи", "тысячи", "тысячи", "тысяч", "тысяч", "тысяч", "тысяч", "тысяч",
            "миллионов","миллион","миллиона","миллиона", "миллиона", "миллионов", "миллионов", "миллионов", "миллионов", "миллионов",
            "миллиардов", "миллиард", "миллиарда", "миллиарда", "миллиарда", "миллиардов", "миллиардов", "миллиардов", "миллиардов", "миллиардов"
        };

        private static readonly List<string> Rub =
            new List<string>() { "рублей", "рубль", "рубля", "рубля", "рубля", "рублей", "рублей", "рублей", "рублей", "рублей" };

        private static readonly List<string> Kop =
            new List<string>() { "копеек", "копейка", "копейки", "копейки", "копейки", "копеек", "копеек", "копеек", "копеек", "копеек" };

        private static string _negative;
        private static string _price;
        private static string[][] _naming;

        public MoneyToString()
        {
            FillNamingArray();
        }

        public string NumberToString(string money, bool fullNameKop = true)
        {
            if (string.IsNullOrEmpty(money))
                throw new ArgumentNullException(nameof(money));

            string rub = "";
            string kop = "";

            money = money.Replace('.', ',');
            money = Regex.Replace(money, "/[\f\n\r\t\v]/g", "");

            if (money.Substring(0, 1) == "-")
            {
                money = money.Remove(0, 1);
                _negative = "минус";
            }

            // проверка числа
            if (Double.TryParse(money, out var result))
                money = Math.Round(result * 100) / 100 + "";
            else throw new ArgumentException("enter number is not number!");

            // проверка на копейки
            if (money.IndexOf(',') != -1)
            {
                rub = money.Substring(0, money.IndexOf(','));
                kop = money.Substring(money.IndexOf(',') + 1);
                if (kop.Length == 1) kop += "0";
            }
            else rub = money;

            if (rub.Length > 12) return "Number is Big";

            var ru = GetNaming(_price = rub, Rub, MoneyType.Rub);
            ru = (string.IsNullOrEmpty(_negative)) ? ru : $"{_negative} {ru}";
            ru = fullNameKop ? $"{ru} {GetNamingKop(kop)}" : $"{ru} {kop} коп.";

            return ru.ToFistUpper();
        }

        private void FillNamingArray()
        {
            int c = 0;
            _naming = new string[10][];
            for (int i = 0; i < 10; i++)
                _naming[i] = new string[_numberStrings.Length / 10];

            for (int i = 0; i < _numberStrings.Length / 10; i++)
                for (int j = 0; j < 10; j++)
                    _naming[j][i] = _numberStrings[c++];
        }

        private string GetNaming(string price, List<string> list, MoneyType type)
        {
            string result = "";

            for (int i = 0; i < price.Length; i += 3)
            {
                string hundreds = "";
                string tens = "";
                string units = "";

                if (GetNumber(i + 2, 2) > 10 && GetNumber(i + 2, 2) < 20)
                {
                    units = $" {_naming[GetNumber(i + 1, 1)][1]} {_naming[0][i / 3 + 3]}";
                    if (i == 0) units += list[0];
                    else units += "0";
                }
                else
                {
                    units = _naming[GetNumber(i + 1, 1)][0];

                    if (units == "один" && (i == 3 || type == MoneyType.Kop))
                        units = "одна";

                    if (units == "два" && (i == 3 || type == MoneyType.Kop))
                        units = "две";

                    if (i != 0 && units != "")
                        units += $" {_naming[GetNumber(i + 1, 1)][i / 3 + 3]}";

                    if (units == " ") units = "";
                    if (units != $" {_naming[GetNumber(i + 1, 1)][i / 3 + 3]}")
                        units = $" {units}";

                    if (i == 0) units += $" {list[GetNumber(i + 1, 1)]}";

                    tens = _naming[GetNumber(i + 2, 1)][2];
                    if (tens != "") tens = $" {tens}";
                }

                hundreds = _naming[GetNumber(i + 3, 1)][3];
                if (hundreds != "") hundreds = $" {hundreds}";

                int startIndex = price.Length - i - 3;
                if (startIndex > 0)
                    if (price.Substring(price.Length - i - 3, 3) == "000" && units == $" {_naming[0][i / 3 + 3]}")
                        units = "";

                result = hundreds + tens + units + result;
            }

            if (result == $" {Rub[0]}") return $"ноль {result}";
            return result.Substring(1);
        }

        private int GetNumber(int start, int length)
        {
            if (start > _price.Length) return 0;
            else return Int32.Parse(_price.Substring(_price.Length - start, length));
        }

        private string GetNamingKop(string kop)
        {
            if (string.IsNullOrEmpty(kop) || string.IsNullOrWhiteSpace(kop))
                return "00 копеек";

            if (Int32.TryParse(kop.Substring(1, 1), out var units))
            {
                if (units == 1) return kop + " копейка";
                if (units < 5) return kop + " копейки";
                if (units > 4) return kop + " копеек";
                if (units == 0) return kop + " копеек";
            }

            if (Int32.TryParse(kop.Substring(2, 1), out var thens))
                if (thens == 1) return kop + " копеек";

            return "00 копеек";
        }

        
    }
}