using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Väderdata___Erik___Emma.Methods
{
    public class MainProgram
    {
        enum IntroMenu
        {
            Utomhus_Data = 1,
            Inomhus_Data,
        }
        public static void WelcomeIntro()
        {
            var loop = true;
            while(loop)
            {
                Console.WriteLine("Välkommen till väderappen! \nVänligen välj datatyp:");
                foreach (int i in Enum.GetValues(typeof(IntroMenu)))
                {
                    Console.WriteLine($"{i}. {Enum.GetName(typeof(IntroMenu), i).Replace('_', ' ')}");
                }
                int nr;
                IntroMenu menu = (IntroMenu)99;
                if (int.TryParse(Console.ReadKey(true).KeyChar.ToString(), out nr))
                {
                    menu = (IntroMenu)nr;
                }
                else
                {
                    Console.Clear();
                    Console.WriteLine("Fel inmatning");
                    Console.ReadKey();
                    Console.Clear();
                }
                switch (menu)
                {
                    case IntroMenu.Utomhus_Data:
                        Console.Clear();
                        OutsideData();
                        break;
                    case IntroMenu.Inomhus_Data:
                        Console.Clear();
                        InsideData();
                        break;
                    default:
                        Console.Clear();
                        Console.WriteLine("Fel inmatning");
                        Console.ReadKey();
                        Console.Clear();
                        break;
                }
            }          
        }
        public static void OutsideData()
        {
            Console.WriteLine("Outside test!");
            Console.ReadLine();
            Console.Clear();
        }
        public static void InsideData()
        {
            Console.WriteLine("Inside test!");
            Console.ReadLine();
            Console.Clear();
        }
    }
}
