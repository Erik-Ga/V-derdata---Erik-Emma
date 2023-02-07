using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace Väderdata___Erik___Emma.Methods
{
    public class RegexValidate
    {
        public static string path = "../../../Väderdata/";
        public static string DateCheck()
        {
            Console.WriteLine("Ange datum: ");
            string date = Console.ReadLine();
            Regex validateRegexDate = new Regex("\\d{4}-\\d{2}-\\d{2}");
            if (validateRegexDate.IsMatch(date) && !date.Contains("2016-05") && !date.Contains("2017-01"))
            {
                return date;
            }
            else
            {
                return "ERROR";
            }
        }
    }
}
