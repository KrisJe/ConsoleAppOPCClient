// $Header: $ 
// Copyright (c) CODE Consulting and Development, s.r.o., Plzen. All rights reserved.

// ReSharper disable LocalizableElement
#region Example
// Shows how to obtain references of all kinds to nodes of all classes, from the "Server" node in the address space.
using System;
using System.Diagnostics;
using OpcLabs.EasyOpc.UA;
using OpcLabs.EasyOpc.UA.AddressSpace;
using OpcLabs.EasyOpc.UA.AddressSpace.Standard;

namespace UADocExamples
{
    namespace _EasyUAClient
    {
        class BrowseNodes
        {
            public static void Main1()
            {
                // Instantiate the client object
                var easyUAClient = new EasyUAClient();

                // Obtain nodes under "Server" node
                UANodeElementCollection nodeElementCollection = easyUAClient.BrowseNodes(
                    "http://opcua.demo-this.com:51211/UA/SampleServer", // or "opc.tcp://opcua.demo-this.com:51210/UA/SampleServer"
                    UAObjectIds.Server,
                    new UABrowseParameters(UANodeClass.All, new [] { UAReferenceTypeIds.References } ));

                // Display results
                foreach (UANodeElement nodeElement in nodeElementCollection)
                {
                    Debug.Assert(nodeElement != null);
                    Console.WriteLine();
                    Console.WriteLine("nodeElement.NodeId: {0}", nodeElement.NodeId);
                    Console.WriteLine("nodeElement.DisplayName: {0}", nodeElement.DisplayName);
                }
            }
        }
    }
}
#endregion
// ReSharper restore LocalizableElement
