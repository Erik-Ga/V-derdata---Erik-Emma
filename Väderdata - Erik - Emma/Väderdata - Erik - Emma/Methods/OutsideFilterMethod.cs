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

                    string[] dateTempSum = new string[] { group.Key, SharedMethod.ConvertToOneDecimal(avgTemp.Average()).ToString() };
                    totalSum.Add(dateTempSum);
                    totalSum = totalSum.OrderByDescending(t => double.Parse(t[1])).ToList();

                    avgTemp.Clear();
                }
                foreach (string[] value in totalSum)
                {
                    Console.WriteLine("Datum: " + value[0] + "   Medeltemperatur: " + value[1]);
                }
                //// DETTA ÄR FÖR SAMMANSTÄLLDA TEXTFILEN
                //List<string[]> sumDateTemp = new List<string[]>();
                //string[] dateSplitTest;
                //string[] arrayDateTemp;
                //foreach (var group in groupByDate)
                //{
                //    foreach (var item in group)
                //    {
                //        string dateTemp = item[3].Replace(".", ",");
                //        avgTemp.Add(double.Parse(dateTemp));
                //    }
                //    dateSplitTest = group.Key.Split(new char[] { '-' },
                //            StringSplitOptions.RemoveEmptyEntries);
                //    arrayDateTemp = new string[] { dateSplitTest[0], dateSplitTest[1], dateSplitTest[2], avgTemp.Average().ToString() };
                //    sumDateTemp.Add(arrayDateTemp);
                //    string[] dateTempSum = new string[] { group.Key, avgTemp.Average().ToString() };
                //    totalSum.Add(dateTempSum);
                //    totalSum = totalSum.OrderByDescending(t => double.Parse(t[1])).ToList();

                //    avgTemp.Clear();
                //}
                //var groupByMonth = from m in sumDateTemp
                //                   group m by m[1] into newGroupMonth
                //                   orderby newGroupMonth.Key
                //                   select newGroupMonth;

                //List<string> totalTempMonth = new List<string>();
                //List<double> avgTemp2 = new List<double>();
                //double monthTempTotal = 0;
                //int counterTemps = 0;
                //foreach (var month in groupByMonth)
                //{
                //    foreach (var temp in month)
                //    {
                //        Console.WriteLine(month.Key + " " + temp[3]);
                //        double monthTemp = double.Parse(temp[3]);
                //        avgTemp2.Add(monthTemp);
                //        monthTempTotal = monthTempTotal + monthTemp;
                //        counterTemps++;
                //    }
                //    monthTempTotal = monthTempTotal / counterTemps;
                //    if (month.Key != "05" && month.Key != "01")
                //    {
                //        totalTempMonth.Add($"Månad: {month.Key} Medeltemp: {monthTempTotal} ");
                //        Console.WriteLine("Månad: " + month.Key + " Medeltemp: " + monthTempTotal);
                //    }

                //    monthTempTotal = 0;
                //    counterTemps = 0;
                //}
                //using (StreamWriter result = new StreamWriter(path + "sammanfattaddata.txt", true))
                //{
                //    for (int i = 0; i < totalTempMonth.Count; i++)
                //    {
                //        result.WriteLine(totalTempMonth[i] + "(UTE)");
                //    }
                //}
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

                    string[] dateMoistSum = new string[] { group.Key, SharedMethod.ConvertToOneDecimal(avgMoist.Average()).ToString() };
                    totalSum.Add(dateMoistSum);
                    totalSum = totalSum.OrderBy(t => double.Parse(t[1])).ToList();

                    avgMoist.Clear();
                }
                foreach (string[] value in totalSum)
                {
                    Console.WriteLine("Datum: " + value[0] + "   Medeltemperatur: " + value[1]);
                }
                //List<string[]> sumDateMoist = new List<string[]>();
                //string[] dateSplitTest;
                //string[] arrayDateMoist;
                //foreach (var group in groupByDate)
                //{
                //    foreach (var item in group)
                //    {
                //        string dateMoist = item[4].Replace(".", ",");
                //        avgMoist.Add(double.Parse(dateMoist));
                //    }
                //    dateSplitTest = group.Key.Split(new char[] { '-' },
                //            StringSplitOptions.RemoveEmptyEntries);
                //    arrayDateMoist = new string[] { dateSplitTest[0], dateSplitTest[1], dateSplitTest[2], avgMoist.Average().ToString() };
                //    sumDateMoist.Add(arrayDateMoist);
                //    string[] dateTempSum = new string[] { group.Key, avgMoist.Average().ToString() };
                //    totalSum.Add(dateTempSum);
                //    totalSum = totalSum.OrderByDescending(t => double.Parse(t[1])).ToList();

                //    avgMoist.Clear();
                //}
                //var groupByMonth = from m in sumDateMoist
                //                   group m by m[1] into newGroupMonth
                //                   orderby newGroupMonth.Key
                //                   select newGroupMonth;

                //List<string> totalMoistMonth = new List<string>();
                //List<double> avgMoist2 = new List<double>();
                //double monthMoistTotal = 0;
                //int counterMoists = 0;
                //foreach (var month in groupByMonth)
                //{
                //    foreach (var moist in month)
                //    {
                //        Console.WriteLine(month.Key + " " + moist[3]);
                //        double monthMoist = double.Parse(moist[3]);
                //        avgMoist2.Add(monthMoist);
                //        monthMoistTotal = monthMoistTotal + monthMoist;
                //        counterMoists++;
                //    }
                //    monthMoistTotal = monthMoistTotal / counterMoists;
                //    if (month.Key != "05" && month.Key != "01")
                //    {
                //        totalMoistMonth.Add($"Månad: {month.Key} Medelluftfuktighet: {monthMoistTotal} ");
                //        Console.WriteLine("Månad: " + month.Key + " Medelluftfuktighet: " + monthMoistTotal);
                //    }

                //    monthMoistTotal = 0;
                //    counterMoists = 0;
                //}
                //using (StreamWriter result = new StreamWriter(path + "sammanfattaddata.txt", true))
                //{
                //    for (int i = 0; i < totalMoistMonth.Count; i++)
                //    {
                //        result.WriteLine(totalMoistMonth[i] + "(UTE)");
                //    }
                //}
            }
        }
        public static void MoldRisk()
        {
            List<string[]> tempArrayList = new List<string[]>();
            List<string[]> airArrayList = new List<string[]>();

            using (StreamReader reader = new StreamReader(path + "ute.txt"))
            {
                for (int i = 1; i < outsideArray.Length; i++)
                {
                    string[] lineArray = reader.ReadLine().Split(new char[] { ' ', ',' },
                            StringSplitOptions.RemoveEmptyEntries);

                    tempArrayList.Add(lineArray);
                    airArrayList.Add(lineArray);

                }

                var groupByDate = from d in tempArrayList
                                  group d by d[0] into newGroup
                                  orderby newGroup.Key
                                  select newGroup;

                List<string[]> totalSum = new List<string[]>();
                List<double> avgTemp = new List<double>();
                List<double> avgMoist = new List<double>();
                double moldRisk = 0;
                foreach (var group in groupByDate)
                {
                    foreach (var item in group)
                    {
                        string dateTemp = item[3].Replace(".", ",");
                        avgTemp.Add(double.Parse(dateTemp));
                        string dateMoist = item[4].Replace(".", ",");
                        avgMoist.Add(double.Parse(dateMoist));
                    }
                    if (avgTemp.Average() > 0 && avgMoist.Average() >= 79)
                    {
                        moldRisk = ((((avgTemp.Average() * 0.26) + avgMoist.Average()) - 79) / 21) * 100;
                    }
                    else if (avgTemp.Average() < 0 && avgMoist.Average() < 79)
                    {
                        moldRisk = 0;
                    }

                    string[] dateTempAirSum = new string[] { group.Key, SharedMethod.ConvertToOneDecimal(moldRisk).ToString() };
                    totalSum.Add(dateTempAirSum);

                    moldRisk = 0;
                    avgTemp.Clear();
                    avgMoist.Clear();
                }
                totalSum = totalSum.OrderBy(t => double.Parse(t[1])).ToList();
                foreach (string[] value in totalSum)
                {
                    if (value[0] != "05" && value[0] != "01")
                    {
                        Console.WriteLine("Datum: " + value[0] + "   Mögelrisk: " + value[1]);
                    }
                }
                // DETTA ÄR FÖR SAMMANSTÄLLDA TEXTFILEN
                //List<string[]> sumDateMold = new List<string[]>();
                //string[] dateSplit;
                //string[] arrayDateMold;
                //foreach (var group in groupByDate)
                //{
                //    foreach (var item in group)
                //    {
                //        string dateTemp = item[3].Replace(".", ",");
                //        avgTemp.Add(double.Parse(dateTemp));
                //        string dateMoist = item[4].Replace(".", ",");
                //        avgMoist.Add(double.Parse(dateMoist));
                //    }
                //    if (avgTemp.Average() > 0 && avgMoist.Average() >= 79)
                //    {
                //        moldRisk = ((((avgTemp.Average() * 0.26) + avgMoist.Average()) - 79) / 21) * 100;
                //    }
                //    else if (avgTemp.Average() < 0 && avgMoist.Average() < 79)
                //    {
                //        moldRisk = 0;
                //    }
                //    dateSplit = group.Key.Split(new char[] { '-' },
                //            StringSplitOptions.RemoveEmptyEntries);
                //    arrayDateMold = new string[] { dateSplit[0], dateSplit[1], dateSplit[2], moldRisk.ToString() };
                //    sumDateMold.Add(arrayDateMold);
                //    avgTemp.Clear();
                //    avgMoist.Clear();
                //}
                //sumDateMold = sumDateMold.OrderBy(t => double.Parse(t[1])).ToList();
                //var groupByMonth = from m in sumDateMold
                //                   group m by m[1] into newGroupMonth
                //                   orderby newGroupMonth.Key
                //                   select newGroupMonth;

                //List<string> totalMoldMonth = new List<string>();
                //List<double> avgMold2 = new List<double>();
                //double monthMoldTotal = 0;
                //int counterMolds = 0;
                //foreach (var month in groupByMonth)
                //{
                //    foreach (var mold in month)
                //    {
                //        Console.WriteLine(month.Key + " " + mold[3]);
                //        double monthTemp = double.Parse(mold[3]);
                //        avgMold2.Add(monthTemp);
                //        monthMoldTotal = monthMoldTotal + monthTemp;
                //        counterMolds++;
                //    }
                //    monthMoldTotal = monthMoldTotal / counterMolds;
                //    if (month.Key != "05" && month.Key != "01")
                //    {
                //        totalMoldMonth.Add($"Månad: {month.Key} Mögelrisk: {monthMoldTotal} ");
                //        Console.WriteLine("Månad: " + month.Key + " Mögelrisk: " + monthMoldTotal);
                //    }

                //    monthMoldTotal = 0;
                //    counterMolds = 0;
                //}
                //using (StreamWriter result = new StreamWriter(path + "sammanfattaddata.txt", true))
                //{
                //    for (int i = 0; i < totalMoldMonth.Count; i++)
                //    {
                //        result.WriteLine(totalMoldMonth[i] + "(UTE)");
                //    }
                //  Console.WriteLine("Mögelalgoritm: ((((avgTemp.Average() * 0.26) + avgMoist.Average()) - 79) / 21) * 100;");
                //}
            }
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
                                // DETTA ÄR FÖR SAMMANSTÄLLDA TEXTFILEN
                                //using (StreamWriter result = new StreamWriter(path + "sammanfattaddata.txt", true))
                                //{

                                //    result.WriteLine("Höststart: Datum: " + value[0] + " vid detta datum har hösten anlänt!");

                                //}
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
                        if (winterCounter > 0 && winterCounter > winterClosestCounter)
                        {
                            winterClosestCounter = winterCounter;
                            closestDate = value[0];
                        }
                        winterCounter = 0;
                    }
                }
                Console.WriteLine("Närmast vinter datum för vinter: " + closestDate + "! Totala dagar under -0 grader i rad: " + winterClosestCounter);
                // DETTA ÄR FÖR SAMMANSTÄLLDA TEXTFILEN
                //using (StreamWriter result = new StreamWriter(path + "sammanfattaddata.txt", true))
                //{
                //    result.WriteLine("Närmast vinter datum för vinter: " + closestDate + "! Totala dagar under -0 grader i rad: " + winterClosestCounter);
                //}
            }
        }
    }
}
