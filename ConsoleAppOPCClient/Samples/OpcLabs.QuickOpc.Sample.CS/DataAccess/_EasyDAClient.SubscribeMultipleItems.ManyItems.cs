// $Header: $
// Copyright (c) CODE Consulting and Development, s.r.o., Plzen. All rights reserved.

using OpcLabs.EasyOpc.DataAccess.OperationModel;
// ReSharper disable CheckNamespace
// ReSharper disable InconsistentNaming
#region Example
// This example shows how subscribe to large number of items.
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
            public static void ManyItems()
            {
                using (var easyDAClient = new EasyDAClient())
                {
                    easyDAClient.ItemChanged += easyDAClient_ItemChanged_ManyItems;

                    const int numberOfItems = 1000;

                    Console.WriteLine("Preparing arguments...");
                    var argumentArray = new DAItemGroupArguments[numberOfItems];
                    for (int i = 0; i < numberOfItems; i++)
                    {
                        int copy = (i / 100) + 1;
                        int phase = (i % 100) + 1;
                        string itemId = String.Format("Simulation.Incrementing.Copy_{0}.Phase_{1}", copy, phase);
                        argumentArray[i] = new DAItemGroupArguments("", "OPCLabs.KitServer.2", itemId, 50, null);
                    }

                    Console.WriteLine("Subscribing to {0} items...", numberOfItems);
                    easyDAClient.SubscribeMultipleItems(argumentArray);

                    Console.WriteLine("Processing item changed events for 1 minute...");
                    Thread.Sleep(60 * 1000);
                }
            }

            // Item changed event handler
            static void easyDAClient_ItemChanged_ManyItems([NotNull] object sender, [NotNull] EasyDAItemChangedEventArgs e)
            {
                Console.WriteLine("{0}: {1}", e.Arguments.ItemDescriptor.ItemId, e.Vtq);
            }
        }
    }
}
#endregion
// ReSharper restore InconsistentNaming
// ReSharper restore CheckNamespace
