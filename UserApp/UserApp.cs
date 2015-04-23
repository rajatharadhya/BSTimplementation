/* PROJECT: WorldDataAppCS (C#) AUTHOR:  Rajath Aradhya  PROGRAM: UserApp 
 *******************************************************************************/

using System;
using System.IO;

using SharedClassLibrary;

namespace UserApp
{
    public class UserApp
    {
        private static UserInterface UIOb;

        public static void Main(string[] args)
        {
            string nameOfFile;
            nameOfFile = "TransDataA3.txt";
             UserInterface UserInterfaceObject = new UserInterface(null);
             NameIndex nameinde = new NameIndex(UIOb, false);
        //    nameind.getbackarray();
            UIOb = new UserInterface(nameOfFile);
            string[] transactionResult = UIOb.GetOneTransaction();
            
            int transactionNumber = 0;
            int totalTrans = 0;
            MainData main = new MainData(UserInterfaceObject, true);
            UserInterfaceObject.WriteToLog("opened IndexBackup file");
            nameinde.getbackarray();
           nameinde.prettyprint(UserInterfaceObject);
            UserInterfaceObject.WriteToLog("Closed IndexBackup file");
            UIOb.WriteToLog(" ");
            UIOb.WriteToLog(" + + + + + + + + + + + + + + QN + +  + + + + + + +");
            while (!UIOb.EndOfStream)
            {
                totalTrans++;
                switch (transactionResult[0])
                {
                    case "QN":
                        UIOb.WriteToLog(transactionResult[0] + " " + transactionResult[1]);
                        transactionNumber++;
                        nameinde.QueryName(transactionResult[1].ToUpper(), UIOb,main);
                        UIOb.WriteToLog(" ");
                        break;
                    case "LN":
                        UIOb.WriteToLog("+ + + + + + + + + + + + + + + + + + + END OF QUERIES + + + + + + + + + +");
                        UIOb.WriteToLog(" ");
                        UIOb.WriteToLog("+ + + + + + + + + + + LI + + + + + + + + + + + + +");
                        UIOb.WriteToLog("CODE NAME--------------  CONTINENT----  -POPULAION  l.EXP");
                        transactionNumber++;
                        nameinde.ListItems(main);
                        UIOb.WriteToLog("+ + + + + + + + + + + + + + + + + + + END OF DATA - 26 COUNTRIES + + + + + + + + + +");
                        break;
                    default:
                        Console.WriteLine("Defaulted on trans file input");
                        break;
                }

                transactionResult = UIOb.GetOneTransaction();

            }
            UIOb.WriteToLog("UserApp completed. Transactions handled: " + transactionNumber + ". Total transactions: " + totalTrans);
            UserInterfaceObject.WriteToLog("opened IndexBackup file");
            nameinde.prettyprint(UserInterfaceObject);
            main.Close();
           UIOb.FinishUp();
        }

        //*********************** PRIVATE METHODS ********************************

    }
}
