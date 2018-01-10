// $Header: $
// Copyright (c) CODE Consulting and Development, s.r.o., Plzen. All rights reserved.

// ReSharper disable CheckNamespace
// ReSharper disable InconsistentNaming
#region Example

// Shows how different data types can be subscribed to, including rare types and arrays of values.

using JetBrains.Annotations;
using OpcLabs.EasyOpc.DataAccess;
using OpcLabs.EasyOpc.DataAccess.OperationModel;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading;

namespace DocExamples
{
    namespace _EasyDAClient
    {
        partial class SubscribeMultipleItems
        {
            static void client_ItemChanged([NotNull] object sender, [NotNull] EasyDAItemChangedEventArgs e)
            {
                Console.WriteLine();
                Console.WriteLine("ItemDescriptor.Arguments.ItemId: {0}", e.Arguments.ItemDescriptor.ItemId);
                if (e.Exception != null)
                    Console.WriteLine("Exception: {0}", e.Exception);
                else
                {
                    Debug.Assert(e.Vtq != null);
                    Console.WriteLine("Vtq: {0}", e.Vtq);
                }
            }

            public static void DataTypes()
            {
                IEnumerable<DAItemGroupArguments> arguments = new[]
                {
                    "Simulation.Register_EMPTY",
                    "Simulation.Register_NULL",
                    "Simulation.Register_DISPATCH",

                    "Simulation.ReadValue_I2",
                    "Simulation.ReadValue_I4",
                    "Simulation.ReadValue_R4",
                    "Simulation.ReadValue_R8",
                    "Simulation.ReadValue_CY",
                    "Simulation.ReadValue_DATE",
                    "Simulation.ReadValue_BSTR",
                    "Simulation.ReadValue_BOOL",
                    "Simulation.ReadValue_DECIMAL",
                    "Simulation.ReadValue_I1",
                    "Simulation.ReadValue_UI1",
                    "Simulation.ReadValue_UI2",
                    "Simulation.ReadValue_UI4",
                    "Simulation.ReadValue_INT",
                    "Simulation.ReadValue_UINT",

                    "Simulation.ReadValue_ArrayOfI2",
                    "Simulation.ReadValue_ArrayOfI4",
                    "Simulation.ReadValue_ArrayOfR4",
                    "Simulation.ReadValue_ArrayOfR8",
                    "Simulation.ReadValue_ArrayOfCY",
                    "Simulation.ReadValue_ArrayOfDATE",
                    "Simulation.ReadValue_ArrayOfBSTR",
                    "Simulation.ReadValue_ArrayOfBOOL",
                    //"Simulation.ReadValue_ArrayOfDECIMAL",
                    "Simulation.ReadValue_ArrayOfI1",
                    "Simulation.ReadValue_ArrayOfUI1",
                    "Simulation.ReadValue_ArrayOfUI2",
                    "Simulation.ReadValue_ArrayOfUI4",
                    "Simulation.ReadValue_ArrayOfINT",
                    "Simulation.ReadValue_ArrayOfUINT",
                }.Select(itemId => new DAItemGroupArguments("", "OPCLabs.KitServer.2", itemId, 3*1000, null));

                var eventHandler = new EasyDAItemChangedEventHandler(client_ItemChanged);
                var client = new EasyDAClient();
                client.ItemChanged += eventHandler;

                Console.WriteLine("Subscribing items...");
                client.SubscribeMultipleItems(arguments.ToArray());
                Thread.Sleep(30 * 1000);
                client.UnsubscribeAllItems();
                client.ItemChanged -= eventHandler;
            }
        }
    }
}
#endregion
// ReSharper restore InconsistentNaming
// ReSharper restore CheckNamespace
