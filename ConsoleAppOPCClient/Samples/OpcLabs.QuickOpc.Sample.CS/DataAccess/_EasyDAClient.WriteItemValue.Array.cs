// $Header: $
// Copyright (c) CODE Consulting and Development, s.r.o., Plzen. All rights reserved.
// ReSharper disable CheckNamespace
#region Example
// Shows how to write into an OPC item that is of array type, and read the array value back.

using System;
using OpcLabs.EasyOpc.DataAccess;

namespace DocExamples
{
    namespace _EasyDAClient
    {
        partial class WriteItemValue
        {
            public static void Array()
            {
                var client = new EasyDAClient();

                Console.WriteLine("Writing array value...");
                client.WriteItemValue("", "AutoJet.ACPFileServerDA.1", "Simulation.Register_ArrayOfI2", new Int16[] { 1234, 2345, 3456 });

                Console.WriteLine("Reading array value...");
                var value = (Int16[])client.ReadItemValue("", "AutoJet.ACPFileServerDA.1", "Simulation.Register_ArrayOfI2");
                if (value != null)
                {
                    Console.WriteLine(value[0]);
                    Console.WriteLine(value[1]);
                    Console.WriteLine(value[2]);
                }
            }
        }
    }
}
#endregion
// ReSharper restore CheckNamespace
