﻿namespace Väderdata___Erik___Emma.Methods
{
    public class OutsideFilterMethod
    {
        public static string path = "../../../Väderdata/";

        public static List<string[]> arrayList = new List<string[]>();
        public static string[] outsideArray = File.ReadAllLines(path + "ute.txt");

        public static void OutsideArrayConvert()
        {
            using (StreamReader reader = new StreamReader(path + "ute.txt"))
            {
                for (int i = 1; i < outsideArray.Length; i++)
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

            using (StreamReader reader = new StreamReader(path + "ute.txt"))
            {
                string dateCheck = RegexValidate.DateCheck();
                for (int i = 1; i < outsideArray.Length; i++)
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

                //Avrundar medeltemperatur och medelluftfuktighet till 1 decimal
                double tempAvrNr = 0;
                double moistAvrNr = 0;
                try
                {
                    tempAvrNr = tempList.Average();
                    moistAvrNr = moistList.Average();

                }
                catch
                {
                    SharedMethod.BreakingLine();
                    Console.WriteLine("Datumet du angivit saknas eller skrivits i fel format! :(");
                }
                double tempRounded = SharedMethod.ConvertToOneDecimal(tempAvrNr);
                double moistRounded = SharedMethod.ConvertToOneDecimal(moistAvrNr);

                if (tempList.Count > 0)
                {
                    SharedMethod.BreakingLine();
                    Console.WriteLine("Medeltemperaturen för valt datum: " + tempRounded);
                    Console.WriteLine("Medelluftfuktigheten för valt datum: " + moistRounded);
                }

            }
            tempList.Clear();
        }
        public static void WarmToCold()
        {
            List<string[]> tempArrayList = new List<string[]>();

            using (StreamReader reader = new StreamReader(path + "ute.txt"))
            {
                for (int i = 1; i < outsideArray.Length; i++)
                {
                    string[] lineArray = reader.ReadLine().Split(new char[] { ' ', ',' },
                            StringSplitOptions.RemoveEmptyEntries);

                    tempArrayList.Add(lineArray);
                }

                var groupByDate = from d in tempArrayList
                                  group d by d[0] into newGroup
                                  orderby newGroup.Key
                                  select newGroup;

                List<string[]> totalSum = new List<string[]>();
                List<double> avgTemp = new List<double>();
                foreach (var group in groupByDate)
                {
                    foreach (var item in group)
                    {
                        string dateTemp = item[3].Replace(".", ",");
                        avgTemp.Add(double.Parse(dateTemp));
                    }

                    string[] dateTempSum = new string[] { group.Key, avgTemp.Average().ToString() };
                    totalSum.Add(dateTempSum);
                    totalSum = totalSum.OrderByDescending(t => double.Parse(t[1])).ToList();

                    avgTemp.Clear();
                }
                foreach (string[] value in totalSum)
                {
                    Console.WriteLine("Datum: " + value[0] + "   Medeltemperatur: " + value[1]);
                }
            }
        }
        public static void DryToMoist()
        {
            List<string[]> airArrayList = new List<string[]>();

            using (StreamReader reader = new StreamReader(path + "ute.txt"))
            {
                for (int i = 1; i < outsideArray.Length; i++)
                {
                    string[] lineArray = reader.ReadLine().Split(new char[] { ' ', ',' },
                            StringSplitOptions.RemoveEmptyEntries);

                    airArrayList.Add(lineArray);
                }

                var groupByDate = from d in airArrayList
                                  group d by d[0] into newGroup
                                  orderby newGroup.Key
                                  select newGroup;

                List<string[]> totalSum = new List<string[]>();
                List<double> avgMoist = new List<double>();
                foreach (var group in groupByDate)
                {
                    foreach (var item in group)
                    {
                        string dateTemp = item[4].Replace(".", ",");
                        avgMoist.Add(double.Parse(dateTemp));
                    }

                    string[] dateMoistSum = new string[] { group.Key, avgMoist.Average().ToString() };
                    totalSum.Add(dateMoistSum);
                    totalSum = totalSum.OrderByDescending(t => double.Parse(t[1])).ToList();

                    avgMoist.Clear();
                }
                foreach (string[] value in totalSum)
                {
                    Console.WriteLine("Datum: " + value[0] + "   Medeltemperatur: " + value[1]);
                }
            }
        }
        public static void MoldRisk()
        {

        }
        public static void Autumn()
        {
            List<string[]> tempArrayList = new List<string[]>();

            using (StreamReader reader = new StreamReader(path + "ute.txt"))
            {
                for (int i = 1; i < outsideArray.Length; i++)
                {
                    string[] lineArray = reader.ReadLine().Split(new char[] { ' ', ',' },
                            StringSplitOptions.RemoveEmptyEntries);

                    tempArrayList.Add(lineArray);
                }

                var groupByDate = from d in tempArrayList
                                  group d by d[0] into newGroup
                                  orderby newGroup.Key
                                  select newGroup;

                List<string[]> totalSum = new List<string[]>();
                List<double> avgTemp = new List<double>();
                foreach (var group in groupByDate)
                {
                    foreach (var item in group)
                    {
                        string dateTemp = item[3].Replace(".", ",");
                        avgTemp.Add(double.Parse(dateTemp));
                    }

                    string[] dateTempSum = new string[] { group.Key, avgTemp.Average().ToString() };
                    totalSum.Add(dateTempSum);

                    avgTemp.Clear();
                }
                int autumnCounter = 0;
                foreach (string[] value in totalSum)
                {
                    if (value[0].Contains("2016-08") || value[0].Contains("2016-09")
                        || value[0].Contains("2016-10") || value[0].Contains("2016-11")
                        || value[0].Contains("2016-12"))
                    {
                        if (double.Parse(value[1]) < 10)
                        {
                            Console.WriteLine("Datum: " + value[0] + "   Medeltemperatur: " + value[1]);
                            autumnCounter++;
                            if (autumnCounter == 5)
                            {
                                Console.WriteLine("Datum: " + value[0] + " vid detta datum har hösten anlänt!");
                                break;
                            }
                        }
                        else if (double.Parse(value[1]) > 10)
                        {
                            autumnCounter = 0;
                        }
                    }
                }
            }
        }
        public static void Winter()
        {
            List<string[]> tempArrayList = new List<string[]>();

            using (StreamReader reader = new StreamReader(path + "ute.txt"))
            {
                for (int i = 1; i < outsideArray.Length; i++)
                {
                    string[] lineArray = reader.ReadLine().Split(new char[] { ' ', ',' },
                            StringSplitOptions.RemoveEmptyEntries);

                    tempArrayList.Add(lineArray);
                }

                var groupByDate = from d in tempArrayList
                                  group d by d[0] into newGroup
                                  orderby newGroup.Key
                                  select newGroup;

                List<string[]> totalSum = new List<string[]>();
                List<double> avgTemp = new List<double>();
                foreach (var group in groupByDate)
                {
                    foreach (var item in group)
                    {
                        string dateTemp = item[3].Replace(".", ",");
                        avgTemp.Add(double.Parse(dateTemp));
                    }

                    string[] dateTempSum = new string[] { group.Key, avgTemp.Average().ToString() };
                    totalSum.Add(dateTempSum);

                    avgTemp.Clear();
                }
                int winterCounter = 0;
                int winterClosestCounter = 0;
                string closestDate = "";
                foreach (string[] value in totalSum)
                {
                    if (double.Parse(value[1]) < 0)
                    {
                        Console.WriteLine("Datum: " + value[0] + "   Medeltemperatur: " + value[1]);
                        winterCounter++;
                        if (winterCounter == 5)
                        {
                            Console.WriteLine("Datum: " + value[0] + " vid detta datum har vintern anlänt!");
                            break;
                        }
                    }
                    else if (double.Parse(value[1]) > 0)
                    {
                        if(winterCounter > 0 && winterCounter > winterClosestCounter)
                        {
                            winterClosestCounter = winterCounter;
                            closestDate = value[0];
                        }
                        winterCounter = 0;
                    }
                }
                Console.WriteLine("Närmast vinter datum för vinter: " + closestDate + "! Totala dagar under -0 grader i rad: " + winterClosestCounter);
            }
        }
    }
}
