﻿/* PROJECT:  WorldDataAppCS (C#)            PROGRAM: SetupProgram
 * AUTHOR: 
 * OOP CLASSES USED (for Asgn 1):  RawData, UserInterface, NameIndex
 *      PLUS FOR FUTURE ASGN:  DataStorage, CodeIndex
 * FILES ACCESSED: (only INDIRECTLY through the OOP classes)
 *      INPUT:   RawData*.csv           (handled by RawData class)
 *      OUTPUT:  Log.txt                (handled by UserInterface class)
 *      OUTPUT:  NameIndexBackup*.txt   (handled by NameIndex class)
 *      PLUS FOR FUTURE ASGN:
 *          OUTPUT: MainData*.bin (& "INPUT" to check for "empty locations")
 *                                      (handled by DataStorage class)
 *          OUTPUT: CodeIndexBackup*.bin (handled by CodeIndex class)
 *          AND NameIndexBackup*.bin will be a BINARY file, not TEXT
 *      where * is the appropriate fileNameSuffix.
 * DESCRIPTION:  The program itself is just the CONTROLLER which UTILIZES
 *      the SERVICES (public methods) of various OOP classes.
 *      It creates an internal NameIndex from data in the RawData file,
 *      saving the index to a file to port it to UserApp.
 *      Status messages are sent to the Log file.
 *      PLUS FOR FUTURE ASGN:
 *          Creates a random access MainData file and an internal CodeIndex,
 *          again saving the index to a file to port it to UserApp.
 * CONTROLLER ALGORITHM:  Traditional sequential-stream processing - i.e., 
 *      loop til done with RawData
 *      {   input 1 data set from RawData
 *          use that data to construct an entry for NameIndex (calling
 *                  appropriate service method in that class)
 *      }
 *      finish up with RawData
 *      finish up with NameIndex
 *      PLUS FOR FUTURE ASGN: "use that data" would also include writing
 *          a MainData record and constructing an entry for CodeIndex
 *          (Similarly, finish up would need to. . .)
 * CAUTION:  The program code below DOES NOT DEAL DIRECTLY WITH
 *      RawData or NameIndex or Log.  Appropriate OOP classes handle those.   
 *******************************************************************************/

using System;

using SharedClassLibrary;

namespace SetupProgram
{
    public class SetupProgram
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("OK, starting SetupProgram");

            // Detect whether this program is being run by AutoTesterUtility,
            //      or manually by developer & fix fileNameSuffixes accordingly.
            //      (for RawData*, NameIndexBackup*).
            string fileNameSuffix;
            if (args.Length > 0)
            {
                fileNameSuffix = args[0];
            }
            else
            {
                fileNameSuffix = "Tester";
            }
            // - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - -





        }
        //*********************** PRIVATE METHODS ********************************




    }
}
