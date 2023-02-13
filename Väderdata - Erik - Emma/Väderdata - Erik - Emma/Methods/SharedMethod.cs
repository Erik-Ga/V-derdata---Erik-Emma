using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Väderdata___Erik___Emma.Methods
{
    public static class SharedMethod
    {
        public static double ConvertToOneDecimal(double nr)
        {
            double nrDec = (nr + 0.05) * 10;
            int nrInt = (int)nrDec;
            double tempround = (double)nrInt / 10;

            return tempround;
        }
        public static void MarkingLine(string word)
        {
            Console.WriteLine(word);
            Console.WriteLine(new String('-', word.Length));
        }
        public static void BreakingLine()
        {
            Console.WriteLine("-------------------------------------------------------------------");
        }
        public static void WelcomeMethod(string message)
        {
            Console.WriteLine(message);
        }
        public static void Cw(this string text)
        {
            Console.WriteLine(text);
            Console.WriteLine(new String('-', text.Length));
        }
        public static void Sun()
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("        \\     (      /\r\n   `.    \\     )    /    .'\r\n     `.   \\   (    /   .'\r\n       `.  .-''''-.  .'\r\n `~._    .'/_    _\\`.    _.~'\r\n     `~ /  / \\  / \\  \\ ~'\r\n_ _ _ _|  _\\O/  \\O/_  |_ _ _ _\r\n       | (_)  /\\  (_) |\r\n    _.~ \\  \\      /  / ~._\r\n .~'     `. `.__.' .'     `~.\r\n       .'  `-,,,,-'  `.\r\n     .'   /    )   \\   `.\r\n   .'    /    (     \\    `.\r\n        /      )     \\        \r\n              (");
            Console.ResetColor();
        }
    }
}
