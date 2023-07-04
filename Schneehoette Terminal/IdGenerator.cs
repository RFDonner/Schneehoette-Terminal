using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Schneehoette_Terminal
{
    internal static class IdGenerator
    {
        private static Random rand = new Random();

        private static readonly int yearMin = 18;
        private static readonly int yearMax = 83;

        private static readonly int codeMax = 5;

        private static Dictionary<int, int> IterateCounter = new Dictionary<int, int>();
        public static string GenerateId(bool IsDeadrow = false)
        {
            int digit = rand.Next(yearMin, yearMax + 1);
            string first = $"0{digit}";
            string startSecond = IsDeadrow ? "2" : "1" ;
            string second = $"{startSecond}0{rand.Next(1,codeMax + 1)}";

            if(IterateCounter.ContainsKey(digit)) 
            { 
                IterateCounter[digit]++; 
            }
            else
            {
                IterateCounter.Add(digit, 1);
            }

            int thirdDigit = IterateCounter[digit];

            string third = thirdDigit > 9 ? $"1{thirdDigit}" : $"11{thirdDigit}";
            return $"{first}-{second}-{third}";
        }

        public static bool VerifyId(string id)
        {
            return true;
        }
    }
}
