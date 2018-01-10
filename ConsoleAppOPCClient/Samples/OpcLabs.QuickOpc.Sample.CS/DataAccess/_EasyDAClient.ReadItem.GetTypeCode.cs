// $Header: $
// Copyright (c) CODE Consulting and Development, s.r.o., Plzen. All rights reserved.
// ReSharper disable CheckNamespace
#region Example 
// This example shows how to read a single item and obtains a type code of the received value.

using System;
using OpcLabs.EasyOpc.DataAccess;

namespace DocExamples
{
    namespace _EasyDAClient
    {
        partial class ReadItem
        {
            public static void GetTypeCode()
            {
                var easyDAClient = new EasyDAClient();

                DAVtq vtq = easyDAClient.ReadItem("", "OPCLabs.KitServer.2", "Simulation.Random");

                if (vtq.Value != null)
                {
                    TypeCode typeCode = Type.GetTypeCode(vtq.Value.GetType());

                    Console.WriteLine("TypeCode: {0}", typeCode);
                }
            }
        }
    }
}
#endregion
// ReSharper restore CheckNamespace
