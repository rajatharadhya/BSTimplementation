/* PROJECT: WorldDataAppCS (C#)         CLASS: UserInterface
 * AUTHOR: Rajath Aradhya
 *******************************************************************************/

using System;
using System.IO;

namespace SharedClassLibrary
{
    public class UserInterface
    {
        //**************************** PRIVATE DECLARATIONS ************************
        //TransFile
        private string _transactionFile;
        private static StreamReader _StreamReader;
        private bool _EndOfStream = false;

        //Log
        private static StreamWriter _LogStreamWriter;
     //   private static FileInfo f;

        //**************************** PUBLIC GET/SET METHODS **********************
        public bool EndOfStream
        {
            get { return _EndOfStream; }
            set { _EndOfStream = value; }
        }
        //**************************** PUBLIC CONSTRUCTOR(S) ***********************
        public UserInterface(string nameOfFile)
        {
            try
            {
                WriteToLog("UserInterface opened log.txt.");

                if (nameOfFile != null)
                {
                    
                    _transactionFile = nameOfFile;
                    string fullPath = GetDirectory(nameOfFile);
                    _StreamReader = new StreamReader(fullPath);
                    Console.WriteLine("OK, UserInterface. Passed file to read from: {0}", nameOfFile);
                    WriteToLog(nameOfFile + " opened by UserInterface.");
                }
                else
                {
                    _LogStreamWriter = new StreamWriter(GetDirectory("log.txt"));
                }

            }
            catch (Exception e)
            {
                Console.WriteLine("Error opening / finding UserInterface file. " + e.Message);
            }
        }
        //**************************** PUBLIC SERVICE METHODS **********************

        public string[] GetOneTransaction()
        {
            string[] transactionArray = new string[2];
            if (_StreamReader.EndOfStream == false)
            {
                string fromFile = _StreamReader.ReadLine();
                if (fromFile.Contains(" "))
                {
                    transactionArray = fromFile.Split(new char[] { ' ' }, 2);
                }
                else if (fromFile != "")
                {
                    transactionArray[0] = fromFile;
                    transactionArray[1] = null;
                }
                else
                {
                    transactionArray[0] = null;
                    transactionArray[1] = null;
                }
            }
            else
            {
                EndOfStream = true;
            }

            return transactionArray;
        }

        public void WriteToLog(string message)
        {
            try
            {
                _LogStreamWriter.WriteLine(message);
            }
            catch (Exception e)
            {
                Console.WriteLine("Error on writing to log in user interface. " + e.Message);
            }
        }

        public void FinishUp()
        {
            if (_transactionFile != null) //TransData
            {
                WriteToLog(_transactionFile + " closed by UserInterface.");
                _StreamReader.Close();
            }
            WriteToLog("log.txt closed by UserInterface.");
            _LogStreamWriter.Close();  //Log
        }
        //**************************** PRIVATE METHODS *****************************
        private string GetDirectory(string fileToRead)
        {
            string currentDir = Directory.GetCurrentDirectory();
            currentDir = Directory.GetParent(currentDir).ToString();
            currentDir = Directory.GetParent(currentDir).ToString();
            currentDir = Directory.GetParent(currentDir).ToString();
            currentDir += @"\FILES\" + fileToRead;
            return currentDir;
        }

    }
}
