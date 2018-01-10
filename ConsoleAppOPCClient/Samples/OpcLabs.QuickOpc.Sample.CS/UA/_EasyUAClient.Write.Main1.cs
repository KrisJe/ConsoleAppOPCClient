// $Header: $ 
// Copyright (c) CODE Consulting and Development, s.r.o., Plzen. All rights reserved.

using OpcLabs.EasyOpc.UA.OperationModel;

#region Example
// This example shows how to write data (a value, timestamps and status code) into a single attribute of a node.
using System;
using OpcLabs.EasyOpc.UA;

namespace UADocExamples
{
    namespace _EasyUAClient
    {
        class Write
        {
            public static void Main1()
            {
                // Instantiate the client object
                var easyUAClient = new EasyUAClient();

                try
                {
                    // Modify data of a node's attribute
                    easyUAClient.Write(
                        "http://opcua.demo-this.com:51211/UA/SampleServer",   // or "opc.tcp://opcua.demo-this.com:51210/UA/SampleServer"
                        "nsu=http://test.org/UA/Data/;i=10221",
                        new UAAttributeData(12345, UASeverity.GoodOrSuccess, DateTime.UtcNow));
                    // Writing server timestamp is not supported by the sample server.

                    // The UA Test Server does not support this, and therefore a failure will occur.
                }
                catch (UAException uaException)
                {
                    Console.WriteLine("Failure: {0}", uaException.GetBaseException().Message);
                }
            }
        }
    }
}
#endregion
