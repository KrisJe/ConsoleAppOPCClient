// $Header: $
// Copyright (c) CODE Consulting and Development, s.r.o., Plzen. All rights reserved.
// ReSharper disable CheckNamespace
#region Example
// This example shows how the OPC server can quickly be disconnected after writing a value into one of its OPC items.

using OpcLabs.EasyOpc.DataAccess;

namespace DocExamples
{
    namespace _EasyDAClientHoldPeriods
    {
        class TopicWrite
        {
            public static void Main1()
            {
                var easyDAClient = new EasyDAClient();

                easyDAClient.InstanceParameters.HoldPeriods.TopicWrite = 100; // in milliseconds

                easyDAClient.WriteItemValue("", "AutoJet.ACPFileServerDA.1", "Simulation.Register_I4", 12345);
            }
        }
    }
}
#endregion
// ReSharper restore CheckNamespace
