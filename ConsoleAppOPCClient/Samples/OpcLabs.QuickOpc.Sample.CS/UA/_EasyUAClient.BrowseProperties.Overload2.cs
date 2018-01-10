// $Header: $ 
// Copyright (c) CODE Consulting and Development, s.r.o., Plzen. All rights reserved.

// ReSharper disable LocalizableElement
// ReSharper disable PossibleNullReferenceException
#region Example
// This example shows how to obtain properties under the "Server" node in the address space.
using System;
using OpcLabs.EasyOpc.UA;
using OpcLabs.EasyOpc.UA.AddressSpace;
using OpcLabs.EasyOpc.UA.AddressSpace.Standard;

namespace UADocExamples
{
    namespace _EasyUAClient
    {
        class BrowseProperties
        {
            public static void Overload2()
            {
                // Instantiate the client object
                var easyUAClient = new EasyUAClient();

                // Obtain properties under "Server" node
                UANodeElementCollection nodeElementCollection = easyUAClient.BrowseProperties(
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
                //nodeElement.NodeId: nsu=http://opcfoundation.org/UA/;i=2254
                //nodeElement.DisplayName: ServerArray
                //
                //nodeElement.NodeId: nsu=http://opcfoundation.org/UA/;i=2255
                //nodeElement.DisplayName: NamespaceArray
                //
                //nodeElement.NodeId: nsu=http://opcfoundation.org/UA/;i=2267
                //nodeElement.DisplayName: ServiceLevel
                //
                //nodeElement.NodeId: nsu=http://opcfoundation.org/UA/;i=2994
                //nodeElement.DisplayName: Auditing            }
            }
        }
    }
}
#endregion
// ReSharper restore LocalizableElement
// ReSharper restore PossibleNullReferenceException
