// $Header: $ 
// Copyright (c) CODE Consulting and Development, s.r.o., Plzen. All rights reserved.

using OpcLabs.EasyOpc.UA.OperationModel;

#region Example
// This example shows how to write values into 3 nodes at once.
using OpcLabs.EasyOpc.UA;

namespace UADocExamples
{
    namespace _EasyUAClient
    {
        partial class WriteMultipleValues
        {
            public static void Main1()
            {
                // Instantiate the client object
                var easyUAClient = new EasyUAClient();

                // Modify value of a node
                easyUAClient.WriteMultipleValues(new[]
                    {
                        new UAWriteValueArguments("http://opcua.demo-this.com:51211/UA/SampleServer",
                            "nsu=http://test.org/UA/Data/;i=10221", 23456),
                        new UAWriteValueArguments("http://opcua.demo-this.com:51211/UA/SampleServer",
                            "nsu=http://test.org/UA/Data/;i=10226", 2.34567890),
                        new UAWriteValueArguments("http://opcua.demo-this.com:51211/UA/SampleServer",
                            "nsu=http://test.org/UA/Data/;i=10227", "ABC")
                    });
            }
        }
    }
}
#endregion
