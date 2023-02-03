using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace Väderdata___Erik___Emma.Methods
{
    internal class Regex
    {
        public static void DateCheck(string date)
        {
            Regex validateRegexDate = new Regex("\\d{4}-\\d{2}-\\d{2}");
            if (validateRegexDate.IsMatch(date))
            {
                Console.WriteLine(date);
            }
            else
            {
                Console.WriteLine("ERROR!");
            }
        }
    }
}
