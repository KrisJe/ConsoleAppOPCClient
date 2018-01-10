// $Header: $
// Copyright (c) CODE Consulting and Development, s.r.o., Plzen. All rights reserved.
// ReSharper disable CheckNamespace
#region Example
// This example shows how to write a value into a single item.

using OpcLabs.EasyOpc.DataAccess;

namespace DocExamples
{
    namespace _EasyDAClient
    {
        partial class WriteItemValue
        {
            public static void Main1()
            {
                var easyDAClient = new EasyDAClient();

                easyDAClient.WriteItemValue("", "AutoJet.ACPFileServerDA.1", "Simulation.Register_I4", 12345);
            }
        }
    }
}
#endregion
// ReSharper restore CheckNamespace
