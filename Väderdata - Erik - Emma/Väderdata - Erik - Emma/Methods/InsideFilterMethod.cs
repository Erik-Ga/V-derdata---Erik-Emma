using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Väderdata___Erik___Emma.Methods
{
    internal class InsideFilterMethod
    {
        public static string path = "../../../Väderdata/";

        public static List<string[]> arrayList = new List<string[]>();
        public static string[] insideArray = File.ReadAllLines(path + "inne.txt");

        public static void InsideArrayConvert()
        {
            using (StreamReader reader = new StreamReader(path + "inne.txt"))
            {
                for (int i = 1; i < insideArray.Length; i++)
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
            List<double> tempList = new List<double>();
            List<double> moistList = new List<double>();

            using (StreamReader reader = new StreamReader(path + "inne.txt"))
            {
                string dateCheck = RegexValidate.DateCheck();
                for (int i = 1; i < insideArray.Length; i++)
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
                        string moist = lineArray[4];
                        moistList.Add(double.Parse(moist));
                    }
                }

                //Avrundar medeltemperaturen och medelluftfuktighet till 1 decimal
                double tempAvrNr = tempList.Average();
                double moistAvrNr = moistList.Average();
                double tempRounded = SharedMethod.ConvertToOneDecimal(tempAvrNr);
                double moistRounded = SharedMethod.ConvertToOneDecimal(moistAvrNr);

                if (tempList.Count > 0)
                {
                    Console.WriteLine("-------------------------------------------------------------------");
                    Console.WriteLine("Medeltemperaturen för valt datum: " + tempRounded);
                    Console.WriteLine("Medelluftfuktigheten för valt datum: " + moistRounded);
                }
                else
                {
                    Console.WriteLine("-------------------------------------------------------------------");
                    Console.WriteLine("Datumet du angivit saknas eller skrivits i fel format! :(");
                }

            }
            tempList.Clear();
        }
        public static void WarmToCold()
        {
            List<string[]> tempArrayList = new List<string[]>();

            using (StreamReader reader = new StreamReader(path + "inne.txt"))
            {
                for (int i = 1; i < insideArray.Length; i++)
                {
                    string[] lineArray = reader.ReadLine().Split(new char[] { ' ', ',' },
                            StringSplitOptions.RemoveEmptyEntries);

                    tempArrayList.Add(lineArray);
                }

                tempArrayList = tempArrayList.OrderBy(t => t[3]).ToList();

                var groupByDate = from d in tempArrayList
                                  group d by d[0] into newGroup
                                  orderby newGroup.Key
                                  select newGroup;

                List<double> avgTemp = new List<double>();
                foreach (var group in groupByDate)
                {
                    Console.WriteLine($"Datum: {group.Key}");
                    foreach (var item in group)
                    {
                        string dateTemp = item[3].Replace(".", ",");
                        avgTemp.Add(double.Parse(dateTemp));
                    }
                    Console.WriteLine("Medeltemp: " + avgTemp.Average());
                    avgTemp.Clear();
                }

                //foreach (string[] temp in airArrayList)
                //{
                //    Console.WriteLine(temp[0] + ", " + temp[3]);

                //}
            }
        }
        public static void DryToMoist()
        {
            List<string[]> airArrayList = new List<string[]>();

            using (StreamReader reader = new StreamReader(path + "inne.txt"))
            {
                for (int i = 1; i < insideArray.Length; i++)
                {
                    string[] lineArray = reader.ReadLine().Split(new char[] { ' ', ',' },
                            StringSplitOptions.RemoveEmptyEntries);

                    airArrayList.Add(lineArray);
                }

                airArrayList = airArrayList.OrderBy(t => t[4]).ToList();

                var groupByDate = from d in airArrayList
                                  group d by d[0] into newGroup
                                  orderby newGroup.Key
                                  select newGroup;

                List<double> avgMoist = new List<double>();
                foreach (var group in groupByDate)
                {
                    Console.WriteLine($"Datum: {group.Key}");
                    foreach (var item in group)
                    {
                        string dateTemp = item[4].Replace(".", ",");
                        avgMoist.Add(double.Parse(dateTemp));
                    }
                    Console.WriteLine("Medelluftfuktighet: " + avgMoist.Average());
                    avgMoist.Clear();
                }

                //foreach (string[] temp in airArrayList)
                //{
                //    Console.WriteLine(temp[0] + ", " + temp[3]);

                //}
            }
        }
        public static void MoldRisk()
        {

        }
    }
}
