/* Project: WorldDataAppCS (C#)     Program: AutoTesterUtility
 * Author: Jordan Kidd
 ******************************************************************************/

using System;
using System.IO;

using SetupProgram;
using UserApp;
using PrettyPrintUtility;

namespace WorldDataAppCS
{
    class AutoTesterUtility
    {
        static void Main(string[] args)
        {
            Console.WriteLine("OK, starting AutoTesterUtility");

            // The 3 parallel arrays (all strings, including the N's) with
            //      - hard-coded SUFFIX values to designate which files to use
            //      - N's to limit how many records to display during testing

            FileInfo f = new FileInfo(GetDirectory("log.txt"));
            StreamWriter _LogStreamWriter = f.CreateText();
            _LogStreamWriter.WriteLine("AutoTester has created new log.txt");
            _LogStreamWriter.Close();

            string[] dataFileSuffix = { "RawDataJust26.csv", "RawDataJust26.csv", "RawDataDups.csv", "RawData.csv" };
            string[] transFileSuffix = { "TransDataTypical.txt", "TransDataEmpty.txt", "TransDataForDups.txt", "TransData.txt" };
            //string[] nRecToShow = { "All", "60", "All", "All"};

            for (int i = 0; i < dataFileSuffix.Length; i++)
            {
                //Delete 3 other output files (if they exist)
                //DeleteFile("MainData" + dataFileSuffix[i] + ".bin");
                //DeleteFile("NameIndexBackup" + dataFileSuffix[i] + ".bin");
                //DeleteFile("CodeIndexBackup" + dataFileSuffix[i] + ".bin");
                //Each run my files are overwritten or created (log and maindata) - Jordan Kidd

                SetupProgram.SetupProgram.Main(new string[] { dataFileSuffix[i] });
                if (!dataFileSuffix[i].Equals("RawData.csv"))
                {   //if guard to NOT print on rawdata.csv (to save paper). Change D
                    PrettyPrintUtility.PrettyPrintUtility.Main(new string[] { dataFileSuffix[i] });
                }
                UserApp.UserApp.Main(new string[] { dataFileSuffix[i], transFileSuffix[i] });
                if(!dataFileSuffix[i].Equals("RawData.csv")) 
                {   //if guard to NOT print on rawdata.csv (to save paper). Change D
                    PrettyPrintUtility.PrettyPrintUtility.Main(new string[] { dataFileSuffix[i] });
                }
            }
        }
        //**************************************************************************
        private static bool DeleteFile(String fileName)
        {
            if (File.Exists(fileName))
            {
                File.Delete(fileName);
                return true;
            }
            else
            {
                return false;
            }
        }

        private static string GetDirectory(string fileToRead)
        {
            string currentDir = Directory.GetCurrentDirectory();
            currentDir = Directory.GetParent(currentDir).ToString();
            currentDir = Directory.GetParent(currentDir).ToString();
            currentDir = Directory.GetParent(currentDir).ToString();
            currentDir += @"\FILES\" + fileToRead;
            return currentDir;
        }
        //**************************************************************************
    }
}
