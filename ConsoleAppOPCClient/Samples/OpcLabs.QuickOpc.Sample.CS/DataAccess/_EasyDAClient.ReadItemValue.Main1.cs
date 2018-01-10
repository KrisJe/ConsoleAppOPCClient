// $Header: $
// Copyright (c) CODE Consulting and Development, s.r.o., Plzen. All rights reserved.

// ReSharper disable CheckNamespace
#region Example

// This example shows how to read and display value of a single item.
// One of the shortest examples possible.

using System;
using OpcLabs.EasyOpc.DataAccess;

namespace DocExamples
{
    namespace _EasyDAClient
    {
        class ReadItemValue
        {
            public static void Main1()
            {
                var client = new EasyDAClient();
                Console.WriteLine("Reading item value...");
                Console.WriteLine(client.ReadItemValue("", "AutoJet.ACPFileServerDA.1", "Demo.Ramp"));
            }
        }
    }
}
#endregion
// ReSharper restore CheckNamespace
