// $Header: $
// Copyright (c) CODE Consulting and Development, s.r.o., Plzen. All rights reserved.

using OpcLabs.EasyOpc.DataAccess.OperationModel;
// ReSharper disable CheckNamespace
// ReSharper disable InconsistentNaming
#region Example
// This example shows how subscribe to changes of multiple items and display the value of the item with each change.
using JetBrains.Annotations;
using OpcLabs.EasyOpc.DataAccess;
using System;
using System.Threading;

namespace DocExamples
{
    namespace _EasyDAClient
    {
        partial class SubscribeMultipleItems
        {
            public static void Main1()
            {
                using (var easyDAClient = new EasyDAClient())
                {
                    easyDAClient.ItemChanged += easyDAClient_ItemChanged;

                    easyDAClient.SubscribeMultipleItems(
                        new[] {
                            new DAItemGroupArguments("", "OPCLabs.KitServer.2", "Simulation.Random", 1000, null), 
                            new DAItemGroupArguments("", "OPCLabs.KitServer.2", "Trends.Ramp (1 min)", 1000, null), 
                            new DAItemGroupArguments("", "OPCLabs.KitServer.2", "Trends.Sine (1 min)", 1000, null),  
                            new DAItemGroupArguments("", "OPCLabs.KitServer.2", "Simulation.Register_I4", 1000, null)
                        });

                    Console.WriteLine("Processing item changed events for 1 minute...");
                    Thread.Sleep(60 * 1000);
                }
            }

            // Item changed event handler
            static void easyDAClient_ItemChanged([NotNull] object sender, [NotNull] EasyDAItemChangedEventArgs e)
            {
                Console.WriteLine("{0}: {1}", e.Arguments.ItemDescriptor.ItemId, e.Vtq);
            }
        }
    }
}
#endregion
// ReSharper restore InconsistentNaming
// ReSharper restore CheckNamespace
