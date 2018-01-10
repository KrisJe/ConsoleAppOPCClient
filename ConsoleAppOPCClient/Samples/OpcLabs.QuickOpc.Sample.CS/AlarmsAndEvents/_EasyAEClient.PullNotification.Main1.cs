// $Header: $
// Copyright (c) CODE Consulting and Development, s.r.o., Plzen. All rights reserved.

// ReSharper disable CheckNamespace
// ReSharper disable InconsistentNaming
#region Example
// This example shows how to subscribe to events and obtain the notification events by pulling them.
using OpcLabs.EasyOpc.AlarmsAndEvents;
using OpcLabs.EasyOpc.AlarmsAndEvents.OperationModel;
using System;

namespace DocExamples
{
    namespace _EasyAEClient
    {
        class PullNotification
        {
            public static void Main1()
            {
                // In order to use event pull, you must set a non-zero queue capacity upfront.
                using (var easyAEClient = new EasyAEClient { PullNotificationQueueCapacity = 1000 })
                {
                    Console.WriteLine("Subscribing events...");
                    int handle = easyAEClient.SubscribeEvents("", "OPCLabs.KitEventServer.2", 1000);

                    Console.WriteLine("Processing event notifications for 1 minute...");
                    int endTick = Environment.TickCount + 60 * 1000;
                    do
                    {
                        EasyAENotificationEventArgs eventArgs = easyAEClient.PullNotification(2 * 1000);
                        if (eventArgs != null)
                            // Handle the notification event
                            Console.WriteLine(eventArgs);
                    } while (Environment.TickCount < endTick);

                    Console.WriteLine("Unsubscribing events...");
                    easyAEClient.UnsubscribeEvents(handle);

                    Console.WriteLine("Finished.");
                }
            }
        }
    }
}
#endregion
// ReSharper restore InconsistentNaming
// ReSharper restore CheckNamespace
