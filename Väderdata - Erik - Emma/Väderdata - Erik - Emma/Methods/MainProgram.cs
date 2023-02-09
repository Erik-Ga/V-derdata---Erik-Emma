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
        enum OutsideMenu
        {
            Medeltemperatur_och_Medelluftfuktighet = 1,
            Varmaste_till_kallaste_dagen,
            Torraste_till_fuktigaste_dagen,
            Mögelrisk,
            Meteorologisk_höst,
            Meteorologisk_vinter

        }
        enum InsideMenu
        {
            Medeltemperatur_och_Medelluftfuktighet = 1,
            Varmaste_till_kallaste_dagen,
            Torraste_till_fuktigaste_dagen,
            Mögelrisk
        }
        public static void WelcomeIntro()
        {
            var loop = true;
            while(loop)
            {
                string welcome = "Välkommen till väderappen!";
                SharedMethod.MakringLine(welcome);
                Console.WriteLine("Vänligen välj datatyp:");

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
                        string outsideData = "Utomhusdata:";
                        SharedMethod.MakringLine(outsideData);

                        foreach (int i in Enum.GetValues(typeof(OutsideMenu)))
                        {
                            Console.WriteLine($"{i}. {Enum.GetName(typeof(OutsideMenu), i).Replace('_', ' ')}");
                        }
                        int nrOutside;
                        OutsideMenu menuOutside = (OutsideMenu)99;
                        if (int.TryParse(Console.ReadKey(true).KeyChar.ToString(), out nrOutside))
                        {
                            menuOutside = (OutsideMenu)nrOutside;
                        }
                        else
                        {
                            Console.Clear();
                            Console.WriteLine("Fel inmatning");
                            Console.ReadKey();
                            Console.Clear();
                        }
                        switch (menuOutside)
                        {
                            case OutsideMenu.Medeltemperatur_och_Medelluftfuktighet:
                                Console.Clear();
                                OutsideFilterMethod.AverageTemperature();
                                Console.ReadKey();
                                Console.Clear();
                                break;
                            case OutsideMenu.Varmaste_till_kallaste_dagen:
                                Console.Clear();
                                OutsideFilterMethod.WarmToCold();
                                Console.ReadKey();
                                Console.Clear();
                                break;
                            case OutsideMenu.Torraste_till_fuktigaste_dagen:
                                Console.Clear();
                                OutsideFilterMethod.DryToMoist();
                                Console.ReadKey();
                                Console.Clear();
                                break;
                            case OutsideMenu.Mögelrisk:
                                Console.Clear();
                                // OutsideFilterMethod.MoldRisk();
                                Console.ReadKey();
                                Console.Clear();
                                break;
                            case OutsideMenu.Meteorologisk_höst:
                                Console.Clear();
                                OutsideFilterMethod.Autumn();
                                Console.ReadKey();
                                Console.Clear();
                                break;
                            case OutsideMenu.Meteorologisk_vinter:
                                Console.Clear();
                                OutsideFilterMethod.Winter();
                                Console.ReadKey();
                                Console.Clear();
                                break;
                        }
                        break;
                    case IntroMenu.Inomhus_Data:
                        Console.Clear();
                        string insideData = "Inomhusdata:";
                        SharedMethod.MakringLine(insideData);

                        foreach (int i in Enum.GetValues(typeof(InsideMenu)))
                        {
                            Console.WriteLine($"{i}. {Enum.GetName(typeof(InsideMenu), i).Replace('_', ' ')}");
                        }
                        int nrInside;
                        InsideMenu menuInside = (InsideMenu)99;
                        if (int.TryParse(Console.ReadKey(true).KeyChar.ToString(), out nrInside))
                        {
                            menuInside = (InsideMenu)nrInside;
                        }
                        else
                        {
                            Console.Clear();
                            Console.WriteLine("Fel inmatning");
                            Console.ReadKey();
                            Console.Clear();
                        }
                        switch (menuInside)
                        {
                            case InsideMenu.Medeltemperatur_och_Medelluftfuktighet:
                                Console.Clear();
                                InsideFilterMethod.AverageTemperature();
                                Console.ReadKey();
                                Console.Clear();
                                break;
                            case InsideMenu.Varmaste_till_kallaste_dagen:
                                Console.Clear();
                                InsideFilterMethod.WarmToCold();
                                Console.ReadKey();
                                Console.Clear();
                                break;
                            case InsideMenu.Torraste_till_fuktigaste_dagen:
                                Console.Clear();
                                InsideFilterMethod.DryToMoist();
                                Console.ReadKey();
                                Console.Clear();
                                break;
                            case InsideMenu.Mögelrisk:
                                Console.Clear();
                                // InsideFilterMethod.MoldRisk();
                                Console.ReadKey();
                                Console.Clear();
                                break;
                        }
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
    }
}
