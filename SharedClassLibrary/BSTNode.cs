/* PROJECT: WorldDataAppCS (C#)         CLASS: BSTNode
 * AUTHOR: Rajath Aradhya
*******************************************************************************/


using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SharedClassLibrary
{
   
    class BSTNode
    {
        
            public short leftChPtr;
            public short rightChildPtr;
            public short dataRecordPtr;
            public string keyValue;

            public string KeyValue
            {
                get { return keyValue; }
                set { keyValue = value; }
            }

            public short DataRecordPtr
            {
                get { return dataRecordPtr; }
                set { dataRecordPtr = value; }
            }

            public short LeftChPtr
            {
                get { return leftChPtr; }
                set { leftChPtr = value; }


            }
            public short RightChildPtr
            {
                get { return rightChildPtr; }
                set { rightChildPtr = value; }
            }

        
    }
}
