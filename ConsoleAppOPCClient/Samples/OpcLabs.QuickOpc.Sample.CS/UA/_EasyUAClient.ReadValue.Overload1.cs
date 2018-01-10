// $Header: $ 
// Copyright (c) CODE Consulting and Development, s.r.o., Plzen. All rights reserved.
// ReSharper disable LocalizableElement
#region Example
// This example shows how to read value of a single node, and display it.
using OpcLabs.EasyOpc.UA;
using System;

namespace UADocExamples
{
    namespace _EasyUAClient
    {
        class ReadValue
        {
            public static void Overload1()
            {
                // Instantiate the client object
                var easyUAClient = new EasyUAClient();

                // Obtain value of a node
                object value = easyUAClient.ReadValue(
                    "http://opcua.demo-this.com:51211/UA/SampleServer",   // or "opc.tcp://opcua.demo-this.com:51210/UA/SampleServer"
                    "nsu=http://test.org/UA/Data/;i=10853");

                // Display results
                Console.WriteLine("value: {0}", value);
            }
        }
    }
}
#endregion
// ReSharper restore LocalizableElement
