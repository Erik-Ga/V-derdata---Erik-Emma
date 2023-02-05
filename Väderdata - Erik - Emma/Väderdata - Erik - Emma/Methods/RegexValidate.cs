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
        public static void DateCheck(string date)
        {
            Regex validateRegexDate = new Regex("\\d{4}-\\d{2}-\\d{2}");
            if (validateRegexDate.IsMatch(date) && !date.Contains("2016-06") && !date.Contains("2017-01"))
            {
                using (StreamReader reader = new StreamReader(path + "ute.txt"))
                {
                    while (!reader.EndOfStream)
                    {
                        string line = reader.ReadLine();
                        if(line.Contains(date))
                        {
                            Console.WriteLine(line);
                        }                       
                    }
                }
            }
            else
            {
                Console.WriteLine("ERROR!");
            }

        }
    }
}
