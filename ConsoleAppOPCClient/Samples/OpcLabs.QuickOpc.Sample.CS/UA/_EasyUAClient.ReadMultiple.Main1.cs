// $Header: $ 
// Copyright (c) CODE Consulting and Development, s.r.o., Plzen. All rights reserved.

using OpcLabs.EasyOpc.UA.OperationModel;
// ReSharper disable LocalizableElement
// ReSharper disable PossibleNullReferenceException
#region Example
// This example shows how to read data (value, timestamps, and status code) of 3 attributes at once. In this example,
// we are reading a Value attribute of 3 different nodes, but the method can also be used to read multiple attributes
// of the same node.
using OpcLabs.EasyOpc.UA;
using System;

namespace UADocExamples
{
    namespace _EasyUAClient
    {
        class ReadMultiple
        {
            public static void Main1()
            {
                // Instantiate the client object
                var easyUAClient = new EasyUAClient();

                // Obtain attribute data. By default, the Value attributes of the nodes will be read.
                UAAttributeDataResult[] attributeDataResultArray = easyUAClient.ReadMultiple(new[]
                    {
                        new UAReadArguments("http://opcua.demo-this.com:51211/UA/SampleServer", "nsu=http://test.org/UA/Data/;i=10845"),
                        new UAReadArguments("http://opcua.demo-this.com:51211/UA/SampleServer", "nsu=http://test.org/UA/Data/;i=10853"),
                        new UAReadArguments("http://opcua.demo-this.com:51211/UA/SampleServer", "nsu=http://test.org/UA/Data/;i=10855")
                    });

                // Display results
                foreach (UAAttributeDataResult attributeDataResult in attributeDataResultArray)
                    Console.WriteLine("AttributeData: {0}", attributeDataResult.AttributeData);

                // Example output:
                //
                //AttributeData: 51 {System.Int16} @11/6/2011 1:49:19 PM @11/6/2011 1:49:19 PM; Good
                //AttributeData: -1993984 {System.Single} @11/6/2011 1:49:19 PM @11/6/2011 1:49:19 PM; Good
                //AttributeData: Yellow% Dragon Cat) White Blue Dog# Green Banana- {System.String} @11/6/2011 1:49:19 PM @11/6/2011 1:49:19 PM; Good            
            }
        }
    }
}
#endregion
// ReSharper restore LocalizableElement
// ReSharper restore PossibleNullReferenceException
