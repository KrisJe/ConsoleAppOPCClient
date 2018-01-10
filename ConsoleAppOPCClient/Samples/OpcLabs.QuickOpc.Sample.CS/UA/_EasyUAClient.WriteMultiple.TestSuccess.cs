// $Header: $ 
// Copyright (c) CODE Consulting and Development, s.r.o., Plzen. All rights reserved.

using OpcLabs.BaseLib.OperationModel;
using OpcLabs.EasyOpc.UA.OperationModel;
// ReSharper disable CoVariantArrayConversion
// ReSharper disable PossibleNullReferenceException
#region Example
// This example shows how to write data (a value, timestamps and status code) into 3 nodes at once, test for success of each 
// write and display the exception message in case of failure.
using System;
using OpcLabs.EasyOpc.UA;

namespace UADocExamples
{
    namespace _EasyUAClient
    {
        class WriteMultiple
        {
            public static void TestSuccess()
            {
                // Instantiate the client object
                var easyUAClient = new EasyUAClient();

                // Modify data of nodes' attributes
                OperationResult[] operationResultArray = easyUAClient.WriteMultiple(new[]
                    {
                        new UAWriteArguments("http://opcua.demo-this.com:51211/UA/SampleServer", "nsu=http://test.org/UA/Data/;i=10221", 
                            new UAAttributeData(23456, UASeverity.GoodOrSuccess, DateTime.UtcNow)),
                        new UAWriteArguments("http://opcua.demo-this.com:51211/UA/SampleServer", "nsu=http://test.org/UA/Data/;i=10226", 
                            new UAAttributeData(2.34567890, UASeverity.GoodOrSuccess, DateTime.UtcNow)),
                        new UAWriteArguments("http://opcua.demo-this.com:51211/UA/SampleServer", "nsu=http://test.org/UA/Data/;i=10227", 
                            new UAAttributeData("ABC", UASeverity.GoodOrSuccess, DateTime.UtcNow))
                        // Writing server timestamp is not supported by the sample server.
                    });

                // The UA Test Server does not support this, and therefore failures will occur.

                for (int i = 0; i < operationResultArray.Length; i++)
                    if (operationResultArray[i].Succeeded)
                        Console.WriteLine("Result {0}: success", i);
                    else
                        Console.WriteLine("Result {0}: {1}", i, operationResultArray[i].Exception.GetBaseException().Message);
            }
        }
    }
}
#endregion
// ReSharper restore CoVariantArrayConversion
// ReSharper restore PossibleNullReferenceException
