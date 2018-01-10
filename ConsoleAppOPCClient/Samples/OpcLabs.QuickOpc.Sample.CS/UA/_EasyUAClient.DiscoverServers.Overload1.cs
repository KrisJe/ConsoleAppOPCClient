// $Header: $ 
// Copyright (c) CODE Consulting and Development, s.r.o., Plzen. All rights reserved.

using OpcLabs.EasyOpc.UA.Discovery;
// ReSharper disable LocalizableElement
// ReSharper disable PossibleNullReferenceException
#region Example
// This example shows how to obtain application URLs of all OPC Unified Architecture servers on a given machine.
using OpcLabs.EasyOpc.UA;
using System;

namespace UADocExamples
{
    namespace _EasyUAClient
    {
        class DiscoverServers
        {
            public static void Overload1()
            {
                // Instantiate the client object
                var easyUAClient = new EasyUAClient();

                // Obtain collection of server elements
                UAApplicationElementCollection applicationElementCollection = easyUAClient.DiscoverServers("opcua.demo-this.com");

                // Display results
                foreach (UAApplicationElement applicationElement in applicationElementCollection)
                    Console.WriteLine("applicationElementCollection[\"{0}\"].ApplicationUriString: {1}", 
                        applicationElement.DiscoveryUriString, applicationElement.ApplicationUriString);

                // Example output:
                // applicationElementCollection["opc.tcp://opcua.demo-this.com:51210/UA/SampleServer"].ApplicationUriString: urn:Test-PC:UA Sample Server
                // applicationElementCollection["http://opcua.demo-this.com:51211/UA/SampleServer"].ApplicationUriString: urn:Test-PC:UA Sample Server
            }
        }
    }
}
#endregion
// ReSharper restore LocalizableElement
// ReSharper restore PossibleNullReferenceException
