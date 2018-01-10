// $Header: $ 
// Copyright (c) CODE Consulting and Development, s.r.o., Plzen. All rights reserved.

using OpcLabs.EasyOpc.UA.Discovery;
// ReSharper disable LocalizableElement
// ReSharper disable PossibleNullReferenceException
#region Example
// This example shows how to obtain information about OPC UA servers available on the network.
using OpcLabs.EasyOpc.UA;
using System;

namespace UADocExamples
{
    namespace _EasyUAClient
    {
        class DiscoverServersOnNetwork
        {
            public static void Main1()
            {
                // Instantiate the client object
                var easyUAClient = new EasyUAClient();

                // Obtain collection of application elements
                UAApplicationElementCollection applicationElementCollection = 
                    easyUAClient.DiscoverServersOnNetwork("opcua.demo-this.com");

                // Display results
                foreach (UAApplicationElement applicationElement in applicationElementCollection)
                {
                    Console.WriteLine();
                    Console.WriteLine("Server name: {0}", applicationElement.ServerName);
                    Console.WriteLine("Discovery URI string: {0}", applicationElement.DiscoveryUriString);
                    Console.WriteLine("Server capabilities: {0}", applicationElement.ServerCapabilities);
                }
            }
        }
    }
}
#endregion
// ReSharper restore LocalizableElement
// ReSharper restore PossibleNullReferenceException
