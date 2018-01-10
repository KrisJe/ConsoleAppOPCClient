﻿// $Header: $
// Copyright (c) CODE Consulting and Development, s.r.o., Plzen. All rights reserved.

// ReSharper disable CheckNamespace
#region Example
// This example shows how to subscribe to item changes and obtain the events by pulling them.
using System;
using OpcLabs.EasyOpc.DataAccess;
using OpcLabs.EasyOpc.DataAccess.OperationModel;

namespace DocExamples
{
    namespace _EasyDAClient
    {
        class PullItemChanged
        {
            public static void Main1()
            {
                // In order to use event pull, you must set a non-zero queue capacity upfront.
                var easyDAClient = new EasyDAClient { PullItemChangedQueueCapacity = 1000 };

                Console.WriteLine("Subscribing item changes...");
                easyDAClient.SubscribeItem("", "OPCLabs.KitServer.2", "Simulation.Random", 1000);

                Console.WriteLine("Processing item changes for 1 minute...");
                int endTick = Environment.TickCount + 60*1000;
                do
                {
                    EasyDAItemChangedEventArgs eventArgs = easyDAClient.PullItemChanged(2*1000);
                    if (eventArgs != null)
                        // Handle the notification event
                        Console.WriteLine(eventArgs);
                } while (Environment.TickCount < endTick);

                Console.WriteLine("Unsubscribing item changes...");
                easyDAClient.UnsubscribeAllItems();

                Console.WriteLine("Finished.");
            }
        }
    }
}
#endregion
// ReSharper restore CheckNamespace
