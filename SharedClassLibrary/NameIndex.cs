/* PROJECT: WorldDataAppCS (C#)         CLASS: NameIndex
 * AUTHOR: Rajath Aradhya
*******************************************************************************/
using System;
using System.IO;
using System.Collections.Generic;
namespace SharedClassLibrary
{
    public class NameIndex
    {
        //**************************** PRIVATE DECLARATIONS ************************
        private const int _SIZEOFDATA = 71;
        private string[] _StringSingleRecordArray;
        public short DRP;
        private int _NumOfRecords = 0;
        private string _Path;
        private UserInterface UserInterfaceObject;
        private char[] _FULLRECORDARRAY = new char[71];
        public short[] root = new short[30];
        private FileStream _fileStream;
        private char[] _RecordID;
        private string _StringRecordID;
        private const int _sizeRecordID = 2;
        private char[] _CountryCode;
        private string _StringCountryCode;
        private const int _sizeCountryCode = 3;
        private char[] _Name;
        private string _StringName;
        private const int _sizeName = 18;
        private char[] _Continent;
        private string _StringContinent;
        private const int _sizeContinent = 13;
        public short loopcount = 1;
        private char[] _Population;
        private string _StringPopulation;
        private const int _sizePopulation = 10;
        private char[] _LifeExp;
        private string _StringLifeExp;
        private const int _sizeLifeExp = 4;
        public short N=0;
        public short k = 0;
        BSTNode[] onebyone = new BSTNode[260];
        #region PUBLIC GET / SET
        //**************************** PUBLIC GET/SET METHODS **********************
        //--String and Char GETs and SETs
        public char[] RecordID
        {
            get { return _RecordID; }
            set { if (value.Length == _sizeRecordID) { _RecordID = value; } else { Console.WriteLine("_RecordID in wrong format."); } }
        }
        public string StringRecordID
        {
            get { return _StringRecordID; }
            set
            {
                _StringRecordID = value;
                if (value.Length > _sizeRecordID)
                {
                    RecordID = value.Substring(0, _sizeRecordID).ToCharArray();
                }
                else if (value.Length < _sizeRecordID)
                {
                    RecordID = value.PadLeft(_sizeRecordID).ToCharArray();
                }
                else
                {
                    RecordID = value.ToCharArray();
                }
            }
        }
        public char[] CountryCode
        {
            get { return _CountryCode; }
            set { if (value.Length == _sizeCountryCode) { _CountryCode = value;  } else { Console.WriteLine("_CountryCode in wrong format."); } }
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
            set { if (value.Length == _sizeName) { _Name = value; } else { Console.WriteLine("_Name in wrong format."); } }
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
            set { if (value.Length == _sizeContinent) { _Continent = value; } else { Console.WriteLine("_Continent in wrong format."); } }
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
            set { if (value.Length == _sizePopulation) { _Population = value;} else { Console.WriteLine("_Population in wrong format."); } }
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
            set { if (value.Length == _sizeLifeExp) { _LifeExp = value; } else { Console.WriteLine("_LifeExp in wrong format."); } }
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
        public NameIndex(UserInterface userInterfaceOb, bool CreateNewMode)
        {
            Console.WriteLine("OK, NameIndex object created");
            MainData main = new MainData(userInterfaceOb, CreateNewMode);
        }
        //**************************** PUBLIC SERVICE METHODS **********************
        public void ProcessNStoreRecord(string[] SingleRecordArray)
        {
             onebyone[N]= new BSTNode();
            _StringSingleRecordArray = SingleRecordArray;
            for (int i = 0; i < SingleRecordArray.Length; i++)
            {
                switch (i)
                {
                    case 0:
                        StringRecordID = SingleRecordArray[i];
                        break;
                    case 1:
                        StringCountryCode = SingleRecordArray[i];
                        break;
                    case 2:
                        StringName = SingleRecordArray[i];
                        break;
                    case 3:
                        StringContinent = SingleRecordArray[i];
                        break;
                    case 4:
                        StringPopulation = SingleRecordArray[i];
                        break;
                    case 5:
                        StringLifeExp = SingleRecordArray[i];
                        break;
                }
            }
            int compare;
            if (N == 0)
            {
                onebyone[N].leftChPtr = -1;
                onebyone[N].RightChildPtr = -1;
                onebyone[N].KeyValue = StringName.ToUpper();
                onebyone[N].DataRecordPtr = Convert.ToInt16(StringRecordID);
            }
            else
            {
                for (int i = 0; i != -1; )
                {
                    compare = String.Compare(onebyone[i].KeyValue.ToUpper(), StringName.ToUpper());
                    if (compare > 0)
                    {
                        if (onebyone[i].LeftChPtr == -1)
                        {
                            onebyone[N].LeftChPtr = -1;
                            onebyone[N].RightChildPtr = -1;
                            onebyone[N].KeyValue = StringName.ToUpper();
                            onebyone[N].DataRecordPtr = Convert.ToInt16(StringRecordID);
                            onebyone[i].LeftChPtr = N;
                            i = -1;
                        }
                        else
                        {
                            i = onebyone[i].LeftChPtr;
                        }
                    }
                    else
                    {
                        if (onebyone[i].RightChildPtr == -1)
                        {
                            onebyone[N].LeftChPtr = -1;
                            onebyone[N].RightChildPtr = -1;
                            onebyone[N].KeyValue = StringName.ToUpper();
                            onebyone[N].DataRecordPtr = Convert.ToInt16(StringRecordID);
                            onebyone[i].RightChildPtr = N;
                            i = -1;
                        }
                        else
                        {

                            i = onebyone[i].RightChildPtr;
                        }
                    }
                }
            }
                N++;
        }
        //**************************** PRIVATE METHODS *****************************
        private void ClearRecord()
        {
            for (int i = 0; i < _FULLRECORDARRAY.Length; i++)
            {
                _FULLRECORDARRAY[i] = '\0';
            }
        }
        private string SetDirectory()
        {
            string currentDir = Directory.GetCurrentDirectory();
            currentDir = Directory.GetParent(currentDir).ToString();
            currentDir = Directory.GetParent(currentDir).ToString();
            currentDir = Directory.GetParent(currentDir).ToString();
            currentDir += @"\FILES\";
            return currentDir;
        }
        public void FinishUp(UserInterface userInterfaceOb)
        {
            try
            {
                UserInterfaceObject = userInterfaceOb;
                string returnedPath = SetDirectory() + "IndexBackup.bin";
                Path = returnedPath;
                UserInterfaceObject.WriteToLog("IndexBackup.bin created / cleared.");
                _fileStream = new FileStream(Path, FileMode.OpenOrCreate, FileAccess.ReadWrite);
                BinaryWriter indexbackup = new BinaryWriter(_fileStream);
                try
                {
                    for (int i = 0; !onebyone[i].KeyValue.Contains("\0"); i++)
                    {
                        short lf = onebyone[i].LeftChPtr;
                        string st = onebyone[i].KeyValue;
                        System.Text.StringBuilder sb = new System.Text.StringBuilder();
                        sb.Append(st);
                        for (int j = st.Length; j < 18; j++)
                            sb.Append(" ");
                        st = sb.ToString();
                        char[] ch = st.ToCharArray();
                        short dt = onebyone[i].DataRecordPtr;
                        short rf = onebyone[i].RightChildPtr;
                        indexbackup.Write(lf);
                        indexbackup.Write(ch);
                        indexbackup.Write(dt);
                        indexbackup.Write(rf);
                    }
                }
                catch (Exception e)
                {
                    
                }
                    indexbackup.Close();
                    _fileStream.Close();
                    UserInterfaceObject.WriteToLog("IndexBackup.bin Closed.Backup file created");
            }
            catch (Exception e)
            {
                Console.WriteLine("Failed on IndexBackup.bin obj creation / file creation. " + e.Message);
            }
        }
        //*************For transactions**********
        public void getbackarray()
        {
            string returnedPath = SetDirectory() + "IndexBackup.bin";
            Path = returnedPath;
            _fileStream = new FileStream(Path, FileMode.Open, FileAccess.Read);
            BinaryReader readtoarray = new BinaryReader(_fileStream);
           
            for (int i = 0; i < 26; i++)
                onebyone[i] = new BSTNode();
            try
            {
                for (int i = 0; onebyone[i].KeyValue!="\0"; i++)
                {
                    short t = readtoarray.ReadInt16();
                    onebyone[i].LeftChPtr = t;
                    char[] st = readtoarray.ReadChars(18);
                    string nam = new string(st);
                    onebyone[i].KeyValue = nam;
                    string s = new string(st);
                    onebyone[i].DataRecordPtr = readtoarray.ReadInt16();
                    onebyone[i].RightChildPtr = readtoarray.ReadInt16();
                }
            }
            catch(Exception e)
            { }
            readtoarray.Close();
        }
        public void QueryName(string cname,UserInterface logging,MainData main)
        {
            N = 0;
            System.Text.StringBuilder sb = new System.Text.StringBuilder();
            sb.Append(cname);
            for (int j = cname.Length; j < 18; j++)
                sb.Append(" ");
            cname = sb.ToString();
            int r = Findrecursive(cname, main, logging);
            loopcount = 1;
        }
        public int Findrecursive(string key, MainData main, UserInterface logging) // call initially with node = root
        {
           
            
            int compare;
            string node = " ";
           node = onebyone[N].KeyValue.ToUpper();
            compare = String.Compare(node, key);
            if(node=="\0")
            {
                Console.WriteLine("Not found");
                logging.WriteToLog("[" + loopcount.ToString() + " BST Nodes Visited]");
                return 0;
            }
            else if(compare== 0)
            {
               DRP=onebyone[N].DataRecordPtr;
               main.GetThisData(DRP);
               logging.WriteToLog("["+loopcount.ToString() + " BST Nodes Visited]");
               return 0;
            }
            else if (compare > 0)
            {
                N = onebyone[N].LeftChPtr;
                if (N == -1)
                {
                    logging.WriteToLog("**ERROR : no country named " + key);
                    logging.WriteToLog("["+loopcount.ToString() + " BST Nodes Visited]");
                    return 0;
                }
                else
                {
                    loopcount++;
                    int r = Findrecursive(key, main, logging);
                    return 0;
                }
            }
            else
            {
                N = onebyone[N].RightChildPtr;
                if (N == -1)
                {
                    logging.WriteToLog("**ERROR : no country named " + key);
                    logging.WriteToLog("[" + loopcount.ToString() + " BST Nodes Visited]");
                    return 0;
                }
                else
                {
                    loopcount++;
               int r=     Findrecursive(key, main, logging);
                    return 0;
                }
            }
        }
        
        public void ListItems(MainData main)
        {
            Iot(0, main);
        }
        public void Iot(int root, MainData main)
        {
             if (root != -1)
            {
                Iot(onebyone[root].LeftChPtr, main);
                DRP = onebyone[root].DataRecordPtr;
                main.GetThisData(DRP);
                Iot(onebyone[root].RightChildPtr, main);
            }
        }
        public void prettyprint(UserInterface log)
        {
            MainData main = new MainData(log, true);
            string returnedPath = SetDirectory() + "IndexBackup.bin";
            FileStream fileStream = new FileStream(returnedPath, FileMode.Open, FileAccess.ReadWrite);
            BinaryReader read = new BinaryReader(fileStream);
            log.WriteToLog("[SUB]  LCH  NAME--------------  DRP  RCH");
            for (int i = 0; i < 26; i++)
            {
                string lf = read.ReadInt16().ToString();
                char[] st = read.ReadChars(18);
                string s = new string(st);
                string dt = read.ReadInt16().ToString();
                string rf = read.ReadInt16().ToString();
                if (lf == "-1")
                    lf = "-01";
                if (rf == "-1")
                    rf = "-01";
                log.WriteToLog("[" + i.ToString().PadLeft(3, '0') + "]"+"  "+lf.PadLeft(3,'0') + "  " + s.PadLeft(18, '0') + "  " + dt.PadLeft(3, '0') + "  " + rf.PadLeft(3, '0'));
            }
         
            read.Close();
            fileStream.Close();
        }
    }
}
