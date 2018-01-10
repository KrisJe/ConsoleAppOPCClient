// $Header: $ 
// Copyright (c) CODE Consulting and Development, s.r.o., Plzen. All rights reserved.

using OpcLabs.BaseLib.OperationModel;
using OpcLabs.EasyOpc.UA.OperationModel;
// ReSharper disable LocalizableElement
// ReSharper disable PossibleNullReferenceException
#region Example
// This example shows how to read the Value attributes of 3 different nodes at once. Using the same method, it is also possible 
// to read multiple attributes of the same node.
using OpcLabs.EasyOpc.UA;
using System;

namespace UADocExamples
{
    namespace _EasyUAClient
    {
        class ReadMultipleValues
        {
            public static void Main1()
            {
                // Instantiate the client object
                var easyUAClient = new EasyUAClient();

                // Obtain values. By default, the Value attributes of the nodes will be read.
                ValueResult[] valueResultArray = easyUAClient.ReadMultipleValues(new[]
                    {
                        new UAReadArguments("http://opcua.demo-this.com:51211/UA/SampleServer", "nsu=http://test.org/UA/Data/;i=10845"),
                        new UAReadArguments("http://opcua.demo-this.com:51211/UA/SampleServer", "nsu=http://test.org/UA/Data/;i=10853"),
                        new UAReadArguments("http://opcua.demo-this.com:51211/UA/SampleServer", "nsu=http://test.org/UA/Data/;i=10855")
                    });

                // Display results
                foreach (ValueResult valueResult in valueResultArray)
                    Console.WriteLine("Value: {0}", valueResult.Value);

                // Example output:
                //
                //Value: 8
                //Value: -8.06803E+21
                //Value: Strawberry Pig Banana Snake Mango Purple Grape Monkey Purple? Blueberry Lemon^            
            }
        }
    }
}
#endregion
// ReSharper restore LocalizableElement
// ReSharper restore PossibleNullReferenceException
