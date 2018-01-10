// $Header: $ 
// Copyright (c) CODE Consulting and Development, s.r.o., Plzen. All rights reserved.

// ReSharper disable LocalizableElement
// ReSharper disable PossibleNullReferenceException
#region Example
// This example shows how to browse objects under the "Objects" node and display event sources.
using System;
using OpcLabs.EasyOpc.UA;
using OpcLabs.EasyOpc.UA.AddressSpace;
using OpcLabs.EasyOpc.UA.AddressSpace.Standard;

namespace UADocExamples
{
    namespace _EasyUAClient
    {
        class BrowseEventSources
        {
            public static void Overload2()
            {
                // Start browsing from the "Objects" node
                BrowseFrom(UAObjectIds.ObjectsFolder);
            }

            private static void BrowseFrom(UANodeDescriptor nodeDescriptor)
            {
                Console.WriteLine();
                Console.WriteLine();
                Console.WriteLine("Parent node: {0}", nodeDescriptor);

                // Instantiate the client object
                var easyUAClient = new EasyUAClient();

                // Obtain notifiers
                UANodeElementCollection eventSourceNodeElementCollection = easyUAClient.BrowseEventSources(
                    "opc.tcp://opcua.demo-this.com:62544/Quickstarts/AlarmConditionServer",
                    nodeDescriptor);

                // Display notifiers
                Console.WriteLine();
                Console.WriteLine("Event sources:");
                foreach (UANodeElement eventSourceNodeElement in eventSourceNodeElementCollection)
                    Console.WriteLine(eventSourceNodeElement);

                // Obtain objects
                UANodeElementCollection objectNodeElementCollection = easyUAClient.BrowseObjects(
                    "opc.tcp://opcua.demo-this.com:62544/Quickstarts/AlarmConditionServer",
                    nodeDescriptor);

                // Recurse
                foreach (UANodeElement objectNodeElement in objectNodeElementCollection)
                    BrowseFrom(objectNodeElement);
            }
        }
    }
}
#endregion
// ReSharper restore LocalizableElement
// ReSharper restore PossibleNullReferenceException
