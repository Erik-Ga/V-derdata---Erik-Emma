namespace Väderdata___Erik___Emma.Methods
{
    public class CreateReadFile
    {
        public static string path = "../../../Väderdata/";
        public static string pathRead = path + "tempdata5-med fel.txt";

        public static string[] allDataArray = File.ReadAllLines(pathRead);
        public static void CreateUte()
        {
            using (StreamWriter writer = File.CreateText(path + "ute.txt"))
            {
                int lineNum = 0;
                while(lineNum < allDataArray.Length)
                {
                    if(lineNum < allDataArray.Length && allDataArray[lineNum].Contains("Ute"))
                    {
                        writer.WriteLine(allDataArray[lineNum]);
                    }
                    lineNum++;
                }
            }
        }
        public static void CreateInne()
        {
            using (StreamWriter writer = File.CreateText(path + "inne.txt"))
            {
                int lineNum = 0;
                while (lineNum < allDataArray.Length)
                {
                    if (lineNum < allDataArray.Length && allDataArray[lineNum].Contains("Inne"))
                    {
                        writer.WriteLine(allDataArray[lineNum]);
                    }
                    lineNum++;
                }
            }
        }
        public static void CreateSumDataFile()
        {
            using (StreamWriter writer = File.CreateText(path + "sammanfattaddata.txt"))
            {

            }
        }
    }

}
