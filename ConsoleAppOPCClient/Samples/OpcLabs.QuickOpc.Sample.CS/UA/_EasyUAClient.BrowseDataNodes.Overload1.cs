// $Header: $ 
// Copyright (c) CODE Consulting and Development, s.r.o., Plzen. All rights reserved.

using OpcLabs.EasyOpc.UA.AddressSpace;
// ReSharper disable LocalizableElement
// ReSharper disable PossibleNullReferenceException
#region Example
// This example shows how to obtain "data nodes" (objects, variables and properties) under the "Objects" node in the address
// space.
using System;
using OpcLabs.EasyOpc.UA;

namespace UADocExamples
{
    namespace _EasyUAClient
    {
        class BrowseDataNodes
        {
            public static void Overload1()
            {
                // Instantiate the client object
                var easyUAClient = new EasyUAClient();

                // Obtain data nodes under "Objects" node
                UANodeElementCollection nodeElementCollection = easyUAClient.BrowseDataNodes(
                    "http://opcua.demo-this.com:51211/UA/SampleServer"); // or "opc.tcp://opcua.demo-this.com:51210/UA/SampleServer"

                // Display results
                foreach (UANodeElement nodeElement in nodeElementCollection)
                {
                    Console.WriteLine();
                    Console.WriteLine("nodeElement.NodeId: {0}", nodeElement.NodeId);
                    Console.WriteLine("nodeElement.DisplayName: {0}", nodeElement.DisplayName);
                }

                // Example output:
                //
                //nodeElement.NodeId: nsu=http://opcfoundation.org/UA/;i=2253
                //nodeElement.DisplayName: Server
                //
                //nodeElement.NodeId: nsu=http://test.org/UA/Data/;i=10157
                //nodeElement.DisplayName: Data
                //
                //nodeElement.NodeId: nsu=http://opcfoundation.org/UA/Boiler/;i=1240
                //nodeElement.DisplayName: Boilers
                //
                //nodeElement.NodeId: nsu=http://samples.org/UA/memorybuffer;i=1025
                //nodeElement.DisplayName: MemoryBuffers            
            }
        }
    }
}
#endregion
// ReSharper restore LocalizableElement
// ReSharper restore PossibleNullReferenceException
