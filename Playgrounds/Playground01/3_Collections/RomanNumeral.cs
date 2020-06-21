using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _3_Collections
{
    internal class RomanNumeral
    {
        public static RomanNumeral CreateInstance()
        {
            return new RomanNumeral();
        }

        private static Dictionary<char, int> RomanNumberMap { get; } = new Dictionary<char, int>
        {
            {'I', 1},
            {'V', 5},
            {'X', 10},
            {'L', 50},
            {'C', 100},
            {'D', 500},
            {'M', 1000}
        };

        public static bool IsRoman(string roman)
        {
            return roman.Trim().ToUpper().All(c => RomanNumberMap.ContainsKey(c));
        }

        public static int Parse(string roman)
        {
            var romanTrimmed = roman.Trim().ToUpper();
            var answer = 0;
            for (var i = 0; i < romanTrimmed.Length; i++)
            {
                if (i + 1 < romanTrimmed.Length && IsSubtractive(romanTrimmed[i], romanTrimmed[i + 1]))
                {
                    answer -= RomanNumberMap[romanTrimmed[i]];

                }
                else
                {
                    answer += RomanNumberMap[romanTrimmed[i]];
                }

            }
            return answer;
        }

        private static bool IsSubtractive(char c1, char c2)
        {
            return RomanNumberMap[c1] < RomanNumberMap[c2];
        }
    }
}
