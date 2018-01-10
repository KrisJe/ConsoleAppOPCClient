// $Header: $
// Copyright (c) CODE Consulting and Development, s.r.o., Plzen. All rights reserved.

using OpcLabs.EasyOpc.DataAccess.OperationModel;
// ReSharper disable CheckNamespace
// ReSharper disable InconsistentNaming
#region Example
// This example shows how subscribe to changes of multiple items, and unsubscribe from one of them.
using JetBrains.Annotations;
using OpcLabs.EasyOpc.DataAccess;
using System;
using System.Threading;

namespace DocExamples
{
    namespace _EasyDAClient
    {
        class UnsubscribeItem
        {
            public static void Main1()
            {
                using (var easyDAClient = new EasyDAClient())
                {
                    easyDAClient.ItemChanged += easyDAClient_ItemChanged;

                    int[] handleArray = easyDAClient.SubscribeMultipleItems(
                        new[] {
                            new DAItemGroupArguments("", "AutoJet.ACPFileServerDA.1", "Simulation.Random", 1000, null), 
                            new DAItemGroupArguments("", "AutoJet.ACPFileServerDA.1", "Trends.Ramp (1 min)", 1000, null), 
                            new DAItemGroupArguments("", "AutoJet.ACPFileServerDA.1", "Trends.Sine (1 min)", 1000, null),  
                            new DAItemGroupArguments("", "AutoJet.ACPFileServerDA.1", "Simulation.Register_I4", 1000, null)
                        });

                    Console.WriteLine("Processing item changed events for 30 seconds...");
                    Thread.Sleep(30 * 1000);

                    Console.WriteLine("Unsubscribing from the first item...");
                    easyDAClient.UnsubscribeItem(handleArray[0]);

                    Console.WriteLine();

                    Console.WriteLine("Processing item changed events for 30 seconds...");
                    Thread.Sleep(30 * 1000);
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
