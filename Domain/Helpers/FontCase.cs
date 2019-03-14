using System;

namespace Domain.Helpers
{
    public static class FontCase
    {
        public static string ToFistUpper(this string s)
        {
            if (string.IsNullOrEmpty(s))
                throw new ArgumentNullException(nameof(s));

            string[] sArray = s.Split(' ');

            if (sArray.Length == 0)
                throw new ArgumentOutOfRangeException(nameof(sArray));

            for (int i = 0; i < sArray.Length; i++)
            {
                if (i == 0)
                    sArray[i] = (sArray[i].Substring(0, 1).ToUpper()) + (sArray[i].Substring(1).ToLower());
                else sArray[i] = sArray[i].ToLower();
            }

            return string.Join(" ", sArray);
        }

        public static string ToFirstOnEachUpper(this string s)
        {
            if (string.IsNullOrEmpty(s))
                throw new ArgumentNullException(nameof(s));

            string[] sArray = s.Split(' ');

            if (sArray.Length == 0)
                throw new ArgumentOutOfRangeException(nameof(sArray));

            for (int i = 0; i < sArray.Length; i++)
            {
                if (sArray[i].Length > 1)
                    sArray[i] = (sArray[i].Substring(0, 1).ToUpper()) + (sArray[i].Substring(1).ToLower());
                else sArray[i] = sArray[i].ToUpper();
            }

            return string.Join(" ", sArray);
        }
    }
}