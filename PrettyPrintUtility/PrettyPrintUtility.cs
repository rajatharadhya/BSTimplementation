/* PROJECT: WorldDataAppCS (C#)         PROGRAM: PrettyPrintUtility
 * AUTHOR:  Rajath Aradhya
 *******************************************************************************/

using System;
using System.IO;
using SharedClassLibrary;
namespace PrettyPrintUtility
{
    public class PrettyPrintUtility
    {
        public static void Main()
        {
            UserInterface log = new UserInterface(null);
            
            MainData main = new MainData(log, true);
            log.FinishUp();
            string returnedPath = SetDirectory() + "IndexBackup.bin";
            FileStream _fileStream = new FileStream(returnedPath, FileMode.Open, FileAccess.ReadWrite);
            BinaryReader read = new BinaryReader(_fileStream);
            FileStream fileStream = new FileStream(SetDirectory() + "log.txt", FileMode.Open, FileAccess.Write);
            StreamWriter write = new StreamWriter(fileStream);
            for (int i = 0; i < 26; i++)
            {
                short lf = read.ReadInt16();
                char[] st = read.ReadChars(18);
                string s = new string(st);
                short dt = read.ReadInt16();
                short rf = read.ReadInt16();
                write.WriteLine(lf + " " + s + " " + dt + " " + rf);
            }
            write.Close();
            read.Close();
            _fileStream.Close();
           
        }
        private static string SetDirectory()
        {
            string currentDir = Directory.GetCurrentDirectory();
            currentDir = Directory.GetParent(currentDir).ToString();
            currentDir = Directory.GetParent(currentDir).ToString();
            currentDir = Directory.GetParent(currentDir).ToString();
            currentDir += @"\FILES\";
            return currentDir;
        }
    } 
  
}
