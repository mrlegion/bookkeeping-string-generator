using System;
using System.Collections;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace SumToString
{
    public class Model
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

        private static readonly List<string> _rub = 
            new List<string>() {"рублей", "рубль", "рубля", "рубля", "рубля", "рублей", "рублей", "рублей", "рублей", "рублей"};

        private static readonly List<string> _kop = 
            new List<string>() {"копеек", "копейка", "копейки", "копейки", "копейки", "копеек", "копеек", "копеек", "копеек", "копеек"};

        private static string _negative;
        private static string _price;
        private static string[][] _naming;

        static Model()
        {
            FillNamingArray();
        }

        private static void FillNamingArray()
        {
            int c = 0;
            _naming = new string[10][];
            for (int i = 0; i < 10; i++)
                _naming[i] = new string[_numberStrings.Length / 10];

            for (int i = 0; i < _numberStrings.Length / 10; i++)
                for (int j = 0; j < 10; j++)
                    _naming[j][i] = _numberStrings[c++];
        }

        public static string NumberToString(string money, bool fullNameKop = true)
        {
            if (string.IsNullOrEmpty(money))
                throw new ArgumentNullException(nameof(money));

            string rub = "";
            string kop = "";

            money = money.Replace('.', ',');
            money = Regex.Replace(money, "/[\f\n\r\t\v]/g", "");

            if (money.Substring(0, 1) == "-")
            {
                money = money.Remove(0);
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

            var ru = GetNaming(_price = rub, _rub, MoneyType.Rub);

            var kopText = fullNameKop ? GetNamingKop(kop) : kop + " коп.";

            return $"{ru} {kopText}";
        }

        private static string GetNaming(string price, List<string> list, MoneyType type)
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
                        units =  "одна";

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

            if (result == $" {_rub[0]}") return $"ноль {result}";
            return result.Substring(1);
        }

        private static int GetNumber(int start, int length)
        {
            if (start > _price.Length) return 0;
            else return Int32.Parse(_price.Substring(_price.Length - start, length));
        }

        private static string GetNamingKop(string kop)
        {
            int value = Int32.Parse(kop);

            if (value == 1 || value == 21 || value == 31 || 
                value == 41 || value == 51 || value == 61 || 
                value == 71 || value == 81 || value == 91)
                return value + " копейка";

            if (value >= 2 && value <= 4)   return $"{value} {_kop[2]}";
            if (value >= 22 && value <= 24) return $"{value} {_kop[2]}";
            if (value >= 32 && value <= 34) return $"{value} {_kop[2]}";
            if (value >= 42 && value <= 44) return $"{value} {_kop[2]}";
            if (value >= 52 && value <= 54) return $"{value} {_kop[2]}";
            if (value >= 62 && value <= 64) return $"{value} {_kop[2]}";
            if (value >= 72 && value <= 74) return $"{value} {_kop[2]}";
            if (value >= 82 && value <= 84) return $"{value} {_kop[2]}";
            if (value >= 92 && value <= 94) return $"{value} {_kop[2]}";
            if (value >= 5 && value <= 20)  return $"{value} {_kop[0]}";
            if (value >= 25 && value <= 30) return $"{value} {_kop[0]}";
            if (value >= 35 && value <= 40) return $"{value} {_kop[0]}";
            if (value >= 45 && value <= 50) return $"{value} {_kop[0]}";
            if (value >= 55 && value <= 60) return $"{value} {_kop[0]}";
            if (value >= 65 && value <= 70) return $"{value} {_kop[0]}";
            if (value >= 75 && value <= 80) return $"{value} {_kop[0]}";
            if (value >= 85 && value <= 90) return $"{value} {_kop[0]}";
            if (value >= 95 && value <= 99) return $"{value} {_kop[0]}";
            return $" 00 {_kop[0]}";
        }
    }

    enum MoneyType
    {
        None,
        Rub,
        Kop
    }
}