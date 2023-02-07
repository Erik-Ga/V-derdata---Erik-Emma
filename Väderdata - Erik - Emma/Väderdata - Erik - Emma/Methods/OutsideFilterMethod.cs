using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Väderdata___Erik___Emma.Methods
{
    public class OutsideFilterMethod
    {
        public static string path = "../../../Väderdata/";

        public static List<string[]> arrayList = new List<string[]>();
        public static string[] uteArray = File.ReadAllLines(path + "ute.txt");

        public static void UteArrayConvert()
        {
            using (StreamReader reader = new StreamReader(path + "ute.txt"))
            {
                for (int i = 1; i < uteArray.Length; i++)
                {
                    string[] lineArray = reader.ReadLine().Split(new char[] { ' ', ',' },
                            StringSplitOptions.RemoveEmptyEntries);
                    arrayList.Add(lineArray);
                }
                ////Se specifika värden från arrayer
                //foreach (string[] lineArray in arrayList)
                //{
                //    Console.WriteLine(lineArray[4]);
                //}
            }
        }
        public static void AverageTemperature()
        {
            //Console.WriteLine("Ange datum mellan 2016-06 till 2017 (formatexempel: 2016-06-17): ");
            //string date = Console.ReadLine();

            List<double> tempList = new List<double>();

            using (StreamReader reader = new StreamReader(path + "ute.txt"))
            {
                string dateCheck = RegexValidate.DateCheck();
                for (int i = 1; i < uteArray.Length; i++)
                {
                    string[] lineArray = reader.ReadLine().Split(new char[] { ' ', ',' },
                            StringSplitOptions.RemoveEmptyEntries);

                    arrayList.Add(lineArray);
                }
                foreach (string[] lineArray in arrayList)
                {
                    if (lineArray.Contains(dateCheck))
                    {
                        string temp = lineArray[3].Replace(".", ",");
                        tempList.Add(double.Parse(temp));
                    }
                }
                if(tempList.Count > 0)
                {
                    Console.WriteLine("Medeltemperaturen för valt datum: " + tempList.Average());
                }
                else
                {
                    Console.WriteLine("Datumet du angivit saknas eller skrivits i fel format! :(");
                }
                               
            }
            tempList.Clear();
        }
    }
}
