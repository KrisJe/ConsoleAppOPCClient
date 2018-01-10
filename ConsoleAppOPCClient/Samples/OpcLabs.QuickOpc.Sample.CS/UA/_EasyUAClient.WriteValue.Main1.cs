// $Header: $ 
// Copyright (c) CODE Consulting and Development, s.r.o., Plzen. All rights reserved.
#region Example
// This example shows how to write a value into a single node.
using OpcLabs.EasyOpc.UA;

namespace UADocExamples
{
    namespace _EasyUAClient
    {
        class WriteValue
        {
            public static void Main1()
            {
                // Instantiate the client object
                var easyUAClient = new EasyUAClient();

                // Modify value of a node
                easyUAClient.WriteValue(
                    "http://opcua.demo-this.com:51211/UA/SampleServer",   // or "opc.tcp://opcua.demo-this.com:51210/UA/SampleServer"
                    "nsu=http://test.org/UA/Data/;i=10221",
                    12345);
            }
        }
    }
}
#endregion
