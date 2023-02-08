using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Väderdata___Erik___Emma.Methods
{
    public class SharedMethod
    {
        public static double ConvertToOneDecimal(double nr)
        {
            double nrDec = (nr + 0.05) * 10;
            int nrInt = (int)nrDec;
            double tempround = (double)nrInt / 10;

            return tempround;
        }
        public static void MakringLine(string word)
        {
            Console.WriteLine(word);
            Console.WriteLine(new String('-', word.Length));
        }
        public static void BreakingLine()
        {
            Console.WriteLine("-------------------------------------------------------------------");
        }
    }
}
