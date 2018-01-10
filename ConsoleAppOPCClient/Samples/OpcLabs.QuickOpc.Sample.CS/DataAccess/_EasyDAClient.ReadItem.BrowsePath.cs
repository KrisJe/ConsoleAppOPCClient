// $Header: $
// Copyright (c) CODE Consulting and Development, s.r.o., Plzen. All rights reserved.
// ReSharper disable CheckNamespace
#region Example
// This example shows how to read a single item using a browse path, and display its value, timestamp and quality.

using System;
using OpcLabs.EasyOpc;
using OpcLabs.EasyOpc.DataAccess;

namespace DocExamples
{
    namespace _EasyDAClient
    {
        partial class ReadItem
        {
            public static void BrowsePath()
            {
                var easyDAClient = new EasyDAClient();

                DAVtq vtq = easyDAClient.ReadItem(
                    new ServerDescriptor("", "AutoJet.ACPFileServerDA.1"), 
                    new DAItemDescriptor(null, "/Simulation/Random"));

                Console.WriteLine("Vtq: {0}", vtq);
            }
        }
    }
}
#endregion
// ReSharper restore CheckNamespace
