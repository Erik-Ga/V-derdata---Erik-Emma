namespace Väderdata___Erik___Emma.Methods
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
            //Kvar att göra: Listorna måste rensas!!
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
                if (tempList.Count > 0)
                {
                    Console.WriteLine("Medeltemperaturen för valt datum: " + tempList.Average());
                    Console.WriteLine("Medelluftfuktigheten för valt datum: " + moistList.Average());
                }
                else
                {
                    Console.WriteLine("Datumet du angivit saknas eller skrivits i fel format! :(");
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

                tempArrayList.Sort(tempArrayList[3]);

            }
        }
    }
}
