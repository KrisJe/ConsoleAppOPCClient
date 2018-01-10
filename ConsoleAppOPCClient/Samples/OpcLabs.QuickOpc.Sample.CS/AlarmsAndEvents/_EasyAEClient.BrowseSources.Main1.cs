// $Header: $
// Copyright (c) CODE Consulting and Development, s.r.o., Plzen. All rights reserved.

// ReSharper disable CheckNamespace
#region Example
// This example shows how to obtain all sources under the "Simulation" area.
using System.Diagnostics;
using OpcLabs.EasyOpc.AlarmsAndEvents;
using OpcLabs.EasyOpc.AlarmsAndEvents.AddressSpace;
using System;

namespace DocExamples
{
    namespace _EasyAEClient
    {

        class BrowseSources
        {
            public static void Main1()
            {
                var easyAEClient = new EasyAEClient();
                //AENodeElementCollection nodeElements = easyAEClient.BrowseSources("", "OPCLabs.KitEventServer.2", "Simulation");
                AENodeElementCollection nodeElements = easyAEClient.BrowseSources("", "AutoJet.ACPFileServerAE.1", "AI1 sensor fault");

                foreach (AENodeElement nodeElement in nodeElements)
                {
                    Debug.Assert(nodeElement != null);

                    Console.WriteLine("nodeElements[\"{0}\"]:", nodeElement.Name);
                    Console.WriteLine("    .QualifiedName: {0}", nodeElement.QualifiedName);
                }
            }
        }

    }
}
#endregion
// ReSharper restore CheckNamespace
