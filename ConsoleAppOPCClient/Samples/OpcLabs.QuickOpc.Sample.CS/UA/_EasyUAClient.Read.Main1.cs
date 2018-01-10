// $Header: $ 
// Copyright (c) CODE Consulting and Development, s.r.o., Plzen. All rights reserved.
// ReSharper disable LocalizableElement
#region Example
// This example shows how to read and display data of an attribute (value, timestamps, and status code).
using OpcLabs.EasyOpc.UA;
using System;

namespace UADocExamples
{
    namespace _EasyUAClient
    {
        class Read
        {
            public static void Main1()
            {
                // Instantiate the client object
                var easyUAClient = new EasyUAClient();

                // Obtain attribute data. By default, the Value attribute of a node will be read.
                UAAttributeData attributeData = easyUAClient.Read(
                    "http://opcua.demo-this.com:51211/UA/SampleServer",   // or "opc.tcp://opcua.demo-this.com:51210/UA/SampleServer"
                    "nsu=http://test.org/UA/Data/;i=10853");

                // Display results
                Console.WriteLine("Value: {0}", attributeData.Value);
                Console.WriteLine("ServerTimestamp: {0}", attributeData.ServerTimestamp);
                Console.WriteLine("SourceTimestamp: {0}", attributeData.SourceTimestamp);
                Console.WriteLine("StatusCode: {0}", attributeData.StatusCode);

                // Example output:
                //
                //Value: -2.230064E-31
                //ServerTimestamp: 11/6/2011 1:34:30 PM
                //SourceTimestamp: 11/6/2011 1:34:30 PM
                //StatusCode: Good
            }
        }
    }
}
#endregion
// ReSharper restore LocalizableElement
