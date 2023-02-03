using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Väderdata___Erik___Emma.Methods
{
    public class CreateArrayList
    {
        public static string path = "../../../Väderdata/";
        

        public static void UteArrayConvert()
        {
            List<string[]> arrayList = new List<string[]>();
            string[] uteArray = File.ReadAllLines(path + "ute.txt");
            using (StreamReader reader = new StreamReader(path + "ute.txt"))
            {
                for (int i = 1; i < uteArray.Length; i++)
                {
                    string[] lineArray = reader.ReadLine().Split(new char[] { ' ',',' },
                            StringSplitOptions.RemoveEmptyEntries);
                    arrayList.Add(lineArray);
                }
                foreach(string[] lineArray in arrayList)
                {
                    Console.WriteLine(lineArray[4]);
                }
            }
        }
    }
}
