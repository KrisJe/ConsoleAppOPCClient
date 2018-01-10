// $Header: $ 
// Copyright (c) CODE Consulting and Development, s.r.o., Plzen. All rights reserved.

// ReSharper disable LocalizableElement
// ReSharper disable PossibleNullReferenceException
#region Example
// This example shows how to obtain objects under the "Server" node in the address space.
using System;
using OpcLabs.EasyOpc.UA;
using OpcLabs.EasyOpc.UA.AddressSpace;
using OpcLabs.EasyOpc.UA.AddressSpace.Standard;

namespace UADocExamples
{
    namespace _EasyUAClient
    {
        class BrowseObjects
        {
            public static void Overload2()
            {
                // Instantiate the client object
                var easyUAClient = new EasyUAClient();

                // Obtain objects under "Server" node
                UANodeElementCollection nodeElementCollection = easyUAClient.BrowseObjects(
                    "http://opcua.demo-this.com:51211/UA/SampleServer", // or "opc.tcp://opcua.demo-this.com:51210/UA/SampleServer"
                    UAObjectIds.Server);

                // Display results
                foreach (UANodeElement nodeElement in nodeElementCollection)
                {
                    Console.WriteLine();
                    Console.WriteLine("nodeElement.NodeId: {0}", nodeElement.NodeId);
                    Console.WriteLine("nodeElement.DisplayName: {0}", nodeElement.DisplayName);
                }

                // Example output:
                //
                //nodeElement.NodeId: nsu=http://opcfoundation.org/UA/;i=2268
                //nodeElement.DisplayName: ServerCapabilities
                //
                //nodeElement.NodeId: nsu=http://opcfoundation.org/UA/;i=2274
                //nodeElement.DisplayName: ServerDiagnostics
                //
                //nodeElement.NodeId: nsu=http://opcfoundation.org/UA/;i=2295
                //nodeElement.DisplayName: VendorServerInfo
                //
                //nodeElement.NodeId: nsu=http://opcfoundation.org/UA/;i=2296
                //nodeElement.DisplayName: ServerRedundancy
            }
        }
    }
}
#endregion
// ReSharper restore LocalizableElement
// ReSharper restore PossibleNullReferenceException
