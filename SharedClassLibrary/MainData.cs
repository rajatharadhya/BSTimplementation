/* PROJECT: WorldDataAppCS (C#)         CLASS: MainData
 * AUTHOR: Rajath Aradhya
*******************************************************************************/

using System;
using System.IO;
using System.Collections.Generic;

namespace SharedClassLibrary
{

    public class MainData
    {
        //**************************** PRIVATE DECLARATIONS ************************
        private const int _SIZEOFDATA = 71;
        private int _NumOfRecords = 0;
        private string _Path;
        private UserInterface UserInterfaceObject;
        private char[] _FULLRECORDARRAY = new char[71];
        private List<char[]> _ListCharItems = new List<char[]>();
        private StreamReader _fileStream;
        private char[] _CountryCode;
        private string _StringCountryCode;
        private const int _sizeCountryCode = 3;
        private char[] _Name;
        private string _StringName;
        private const int _sizeName = 17;
        private char[] _Continent;
        private string _StringContinent;
        private const int _sizeContinent = 11;
        private char[] _Population;
        private string _StringPopulation;
        private const int _sizePopulation = 10;
        private char[] _LifeExp;
        private string _StringLifeExp;
        private const int _sizeLifeExp = 4;
        #region PUBLIC GET / SET
        //**************************** PUBLIC GET/SET METHODS **********************
        //--String and Char GETs and SETs

        public char[] CountryCode
        {
            get { return _CountryCode; }
            set { if (value.Length == _sizeCountryCode) { _CountryCode = value; _ListCharItems.Add(_CountryCode); } else { Console.WriteLine("_CountryCode in wrong format."); } }
        }
        public string StringCountryCode
        {
            get { return _StringCountryCode; }
            set
            {
                _StringCountryCode = value;
                if (value.Length > _sizeCountryCode)
                {
                    CountryCode = value.Substring(0, _sizeCountryCode).ToCharArray();
                }
                else if (value.Length < _sizeCountryCode)
                {
                    CountryCode = value.PadLeft(_sizeCountryCode).ToCharArray();
                }
                else
                {
                    CountryCode = value.ToCharArray();
                }
            }
        }

        public char[] Name
        {
            get { return _Name; }
            set { if (value.Length == _sizeName) { _Name = value; _ListCharItems.Add(_Name); } else { Console.WriteLine("_Name in wrong format."); } }
        }
        public string StringName
        {
            get { return _StringName; }
            set
            {
                _StringName = value;
                if (value.Length > _sizeName)
                {
                    Name = value.Substring(0, _sizeName).ToCharArray();
                }
                else if (value.Length < _sizeName)
                {
                    Name = value.PadLeft(_sizeName).ToCharArray();
                }
                else
                {
                    Name = value.ToCharArray();
                }
            }
        }

        public char[] Continent
        {
            get { return _Continent; }
            set { if (value.Length == _sizeContinent) { _Continent = value; _ListCharItems.Add(_Continent); } else { Console.WriteLine("_Continent in wrong format."); } }
        }
        public string StringContinent
        {
            get { return _StringContinent; }
            set
            {
                _StringContinent = value;
                if (value.Length > _sizeContinent)
                {
                    Continent = value.Substring(0, _sizeContinent).ToCharArray();
                }
                else if (value.Length < _sizeContinent)
                {
                    Continent = value.PadLeft(_sizeContinent).ToCharArray();
                }
                else
                {
                    Continent = value.ToCharArray();
                }
            }
        }

        public char[] Population
        {
            get { return _Population; }
            set { if (value.Length == _sizePopulation) { _Population = value; _ListCharItems.Add(_Population); } else { Console.WriteLine("_Population in wrong format."); } }
        }
        public string StringPopulation
        {
            get { return _StringPopulation; }
            set
            {
                _StringPopulation = value;
                if (value.Length > _sizePopulation)
                {
                    Population = value.Substring(0, _sizePopulation).ToCharArray();
                }
                else if (value.Length < _sizePopulation)
                {
                    Population = value.PadLeft(_sizePopulation).ToCharArray();
                }
                else
                {
                    Population = value.ToCharArray();
                }
            }
        }

        public char[] LifeExp
        {
            get { return _LifeExp; }
            set { if (value.Length == _sizeLifeExp) { _LifeExp = value; _ListCharItems.Add(_LifeExp); } else { Console.WriteLine("_LifeExp in wrong format."); } }
        }
        public string StringLifeExp
        {
            get { return _StringLifeExp; }
            set
            {
                _StringLifeExp = value;
                if (value.Length > _sizeLifeExp)
                {
                    LifeExp = value.Substring(0, _sizeLifeExp).ToCharArray();
                }
                else if (value.Length < _sizeLifeExp)
                {
                    LifeExp = value.PadLeft(_sizeLifeExp).ToCharArray();
                }
                else
                {
                    LifeExp = value.ToCharArray();
                }
            }
        }

        public int NumOfRecords
        {
            get { return _NumOfRecords; }
        }
        public string Path
        {
            get { return _Path; }
            set { _Path = value; }
        }
        #endregion
        //**************************** PUBLIC CONSTRUCTOR(S) ***********************
        public MainData(UserInterface userInterfaceOb, bool CreateNewMode)
        {
            try
            {
                UserInterfaceObject = userInterfaceOb;
                string returnedPath = SetDirectory() + "MainDataA3.txt";
                Path = returnedPath;
                if (CreateNewMode)
                {
                    UserInterfaceObject.WriteToLog("MainDataA3.txt created / cleared.");
                    _fileStream = new StreamReader(Path);
                }
                else
                {
                    UserInterfaceObject.WriteToLog("MainDataA3.txt opened in append mode via UserApp.");
                    _fileStream = new StreamReader(Path);
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("Failed on MainDataA3 obj creation / file creation. " + e.Message);
            }
        }
        //**************************** PUBLIC SERVICE METHODS **********************
        public void Close()
        {
            UserInterfaceObject.WriteToLog("MainDataA3.txt closed.");
            _fileStream.Close();
        }


        //**************************** PRIVATE METHODS *****************************
        private string SetDirectory()
        {
            string currentDir = Directory.GetCurrentDirectory();
            currentDir = Directory.GetParent(currentDir).ToString();
            currentDir = Directory.GetParent(currentDir).ToString();
            currentDir = Directory.GetParent(currentDir).ToString();
            currentDir += @"\FILES\";
            return currentDir;
        }
        public void GetThisData(int rrn)
        {
            int offset = (rrn - 1) * 50;
            StreamReader readmaindata = new StreamReader(SetDirectory() + "MainDataA3.txt");
            readmaindata.BaseStream.Seek(offset, SeekOrigin.Begin);
            string Data = readmaindata.ReadLine();
            readmaindata.Close();
            UserInterfaceObject.WriteToLog(Data.Substring(0, 3) + "  " + Data.Substring(3, 18) + "  " + Data.Substring(21, 13) + "  " + Data.Substring(34, 10) + "  " + Data.Substring(44, 4));

        }

        private void ClearRecord()
        {
            for (int i = 0; i < _FULLRECORDARRAY.Length; i++)
            {
                _FULLRECORDARRAY[i] = '\0';
            }
        }

    }
}