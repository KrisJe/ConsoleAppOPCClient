// $Header: $
// Copyright (c) CODE Consulting and Development, s.r.o., Plzen. All rights reserved.
// ReSharper disable CheckNamespace
#region Example 
// This example shows how to obtain a structure containing property values for an OPC item, and display some property values.
using System;
using OpcLabs.EasyOpc.DataAccess;
using OpcLabs.EasyOpc.DataAccess.Extensions;

namespace DocExamples
{
    namespace _EasyDAClientExtension
    {
        class GetItemPropertyRecord
        {
            public static void Main1()
            {
                var easyDAClient = new EasyDAClient();

                // Get a structure containing values of all well-known properties
                DAItemPropertyRecord itemPropertyRecord =
                    easyDAClient.GetItemPropertyRecord("", "OPCLabs.KitServer.2", "Simulation.Random");

                // Display some of the obtained property values
                Console.WriteLine("itemPropertyRecord.AccessRights: {0}", itemPropertyRecord.AccessRights);
                Console.WriteLine("itemPropertyRecord.DataType: {0}", itemPropertyRecord.DataType);
                Console.WriteLine("itemPropertyRecord.Timestamp: {0}", itemPropertyRecord.Timestamp);
            }
        }
    }
}
#endregion
// ReSharper restore CheckNamespace
