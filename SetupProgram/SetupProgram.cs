/* PROJECT:  WorldDataAppCS (C#)            PROGRAM: SetupProgram
 * AUTHOR:  Rajath Aradhya
 */

using System;
//using System.IO;
using SharedClassLibrary;

namespace SetupProgram
{
    public class SetupProgram
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("OK, starting SetupProgram");

        
            string fileNameSuffix;
           
              //Manually Run this program only
                fileNameSuffix = "RawDataA3.csv";
            
            // - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - -

            UserInterface UserInterfaceObject = new UserInterface(null);
            RawData RawDataObject = new RawData(fileNameSuffix, UserInterfaceObject);
         //   MainData MainDataObject = new MainData(UserInterfaceObject, true);
            NameIndex name = new NameIndex(UserInterfaceObject, true);
            string[] ReturnedRecordArray;
            ReturnedRecordArray = RawDataObject.ReadOneLine();
            while (!RawDataObject.EndOfFile)
            {
                Console.WriteLine("Read in one country: " + ReturnedRecordArray[2] + ". Moving to process...");
                    name.ProcessNStoreRecord(ReturnedRecordArray);
                ReturnedRecordArray = RawDataObject.ReadOneLine();
            }
            name.FinishUp(UserInterfaceObject);
            //Message is in MainDataOb's FinishHeader
        //   MainDataObject.FinishHeaderAndClose();
            //Message is in UI's FinishUp
            UserInterfaceObject.FinishUp();

        }
    }
}
