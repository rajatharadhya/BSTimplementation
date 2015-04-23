/* PROJECT: WorldDataAppCS (C#)         CLASS: RawData
 * AUTHOR:  Rajath Aradhya
 * FILES ACCESSED:
 * FILE STRUCTURE:  
 * DESCRIPTION:   
 *******************************************************************************/

using System;
using System.IO;

namespace SharedClassLibrary
{
    public class RawData
    {
        //**************************** PRIVATE DECLARATIONS ************************
        private string _FilePath;
        private string _FileToRead;
        private string _CurrentRecordInMemory;
        private string _FullPath;
        private string[] _CurrentRecordArray;
        private string[] _NameAndId = new string[2];
        private bool _EndOfFile;
        private StreamReader _StreamReader;
        private UserInterface UserInterfaceObject;

        #region GETS and SETS
        //**************************** PUBLIC GET/SET METHODS **********************
        public string FilePathToRead 
        {
            get { return _FilePath; }
            set { _FilePath = value; }
        }
        public string FileNameToRead
        {
            get { return _FileToRead; }
            set { _FileToRead = value; }
        }
        public string FullPath
        {
            get { return _FullPath; }
            set { _FullPath = value; }
        }
        public string CurrentRecordInMemory
        {
            get { return _CurrentRecordInMemory;  }
            set { _CurrentRecordInMemory = value;  }
        }
        public string[] CurrentRecordArray
        {
            get { return _CurrentRecordArray; }
            set { _CurrentRecordArray = value;  }
        }
        public string[] NameAndId
        {
            get { return _NameAndId; }
            set { _NameAndId = value; }
        }
        public bool EndOfFile
        {
            get { return _EndOfFile; }
        }
        #endregion

        #region Constructors
        //**************************** PUBLIC CONSTRUCTOR(S) ***********************
        public RawData(string fileToRead, UserInterface userInterfaceOb)
        {
            try
            {
                UserInterfaceObject = userInterfaceOb;
                FileNameToRead = fileToRead;
                FullPath = GetDirectory(fileToRead);
                _StreamReader = new StreamReader(FullPath);
                userInterfaceOb.WriteToLog(fileToRead + " opened by RawData.");
                Console.WriteLine("OK, RawData object created. Passed file to read from: {0}", FileNameToRead);
            }
            catch (Exception e)
            {
                Console.WriteLine("Error opening / finding RawData file. " + e.Message);
            }
        }
        #endregion

        #region Public Methods
        //**************************** PUBLIC SERVICE METHODS **********************
        //returns Name and ID of file
        public string[] ReadOneLine()
        {
            if (_StreamReader.EndOfStream == false) {
                CurrentRecordInMemory = _StreamReader.ReadLine();
                RecordToArray(CurrentRecordInMemory);
            } else {
                _EndOfFile = true;
                UserInterfaceObject.WriteToLog( _FileToRead+ " closed.");
                _StreamReader.Close();
            }
            
            return CurrentRecordArray;

        }
        #endregion 

        #region Private Methods
        //**************************** PRIVATE METHODS *****************************
        //Full record, broken by commas from CSV file to read
        private void RecordToArray(string RecordToBreakUp)
        {
            CurrentRecordArray = RecordToBreakUp.Split(',');
        }

        //Moves up the file system 3 folders and enters in the shared FILES folder
        private string GetDirectory(string fileToRead)
        { 
            string currentDir = Directory.GetCurrentDirectory();
            currentDir = Directory.GetParent(currentDir).ToString();
            currentDir = Directory.GetParent(currentDir).ToString();
            currentDir = Directory.GetParent(currentDir).ToString();
            currentDir += @"\FILES\" + fileToRead;
            return currentDir;
        }
        #endregion

    }
}
