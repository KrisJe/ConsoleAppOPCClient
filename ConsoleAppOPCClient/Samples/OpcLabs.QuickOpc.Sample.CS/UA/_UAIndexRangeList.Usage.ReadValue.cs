// $Header: $ 
// Copyright (c) CODE Consulting and Development, s.r.o., Plzen. All rights reserved.
// ReSharper disable InconsistentNaming
// ReSharper disable LocalizableElement
// ReSharper disable PossibleNullReferenceException
#region Example
// This example shows how to read a range of values from an array.
using OpcLabs.EasyOpc.UA;
using System;
using OpcLabs.EasyOpc.UA.OperationModel;

namespace UADocExamples
{
    namespace _UAIndexRangeList
    {
        class Usage
        {
            public static void ReadValue()
            {
                // Instantiate the client object
                var easyUAClient = new EasyUAClient();

                // Obtain the value, indicating that just the elements 2 to 4 should be returned
                object value = easyUAClient.ReadValue(
                    new UAReadArguments(
                        "http://opcua.demo-this.com:51211/UA/SampleServer",   // or "opc.tcp://opcua.demo-this.com:51210/UA/SampleServer"
                        "nsu=http://test.org/UA/Data/;ns=2;i=10305",
                        UAIndexRangeList.OneDimension(2, 4)));

                // Cast to typed array
                var arrayValue = (Int32[]) value;

                // Display results
                for (int i = 0; i < 3; i++)
                    Console.WriteLine("arrayValue[{0}]: {1}", i, arrayValue[i]);
            }
        }
    }
}
#endregion
