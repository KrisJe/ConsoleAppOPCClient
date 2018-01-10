// $Header: $ 
// Copyright (c) CODE Consulting and Development, s.r.o., Plzen. All rights reserved.

using OpcLabs.BaseLib.OperationModel;
using OpcLabs.EasyOpc.UA.OperationModel;
// ReSharper disable CoVariantArrayConversion
// ReSharper disable PossibleNullReferenceException
#region Example
// This example shows how to write values into 3 nodes at once, test for success of each write and display the exception 
// message in case of failure.
using System;
using OpcLabs.EasyOpc.UA;

namespace UADocExamples
{
    namespace _EasyUAClient
    {
        partial class WriteMultipleValues
        {
            public static void TestSuccess()
            {
                // Instantiate the client object
                var easyUAClient = new EasyUAClient();

                // Modify value of a node
                OperationResult[] operationResultArray = easyUAClient.WriteMultipleValues(new[]
                    {
                        new UAWriteValueArguments("http://opcua.demo-this.com:51211/UA/SampleServer",
                            "nsu=http://test.org/UA/Data/;i=10221", 23456),
                        new UAWriteValueArguments("http://opcua.demo-this.com:51211/UA/SampleServer",
                            "nsu=http://test.org/UA/Data/;i=10226", "This string cannot be converted to Double"),
                        new UAWriteValueArguments("http://opcua.demo-this.com:51211/UA/SampleServer",
                            "nsu=http://test.org/UA/Data/;s=UnknownNode", "ABC")
                    });

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
