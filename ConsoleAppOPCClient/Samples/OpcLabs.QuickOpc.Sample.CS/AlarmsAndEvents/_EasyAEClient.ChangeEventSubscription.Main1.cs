// $Header: $
// Copyright (c) CODE Consulting and Development, s.r.o., Plzen. All rights reserved.

using OpcLabs.EasyOpc.AlarmsAndEvents.OperationModel;
// ReSharper disable CheckNamespace
// ReSharper disable InconsistentNaming
#region Example
// This example shows how to subscribe to events display the event message with each notification. It also shows how to 
// unsubscribe afterwards.
using JetBrains.Annotations;
using OpcLabs.EasyOpc.AlarmsAndEvents;
using System;
using System.Threading;

namespace DocExamples
{
    namespace _EasyAEClient
    {

        class ChangeEventSubscription
        {
            public static void Main1()
            {
                using (var easyAEClient = new EasyAEClient())
                {
                    var eventHandler = new EasyAENotificationEventHandler(easyAEClient_Notification);
                    easyAEClient.Notification += eventHandler;

                    Console.WriteLine("Subscribing...");
                    int handle = easyAEClient.SubscribeEvents("", "OPCLabs.KitEventServer.2", 500);

                    Console.WriteLine("Waiting for 10 seconds...");
                    Thread.Sleep(10 * 1000);

                    Console.WriteLine("Changing subscription...");
                    easyAEClient.ChangeEventSubscription(handle, 5 * 1000);

                    Console.WriteLine("Waiting for 50 seconds...");
                    Thread.Sleep(50 * 1000);

                    easyAEClient.UnsubscribeEvents(handle);
                }
            }

            // Notification event handler
            static void easyAEClient_Notification([NotNull] object sender, [NotNull] EasyAENotificationEventArgs e)
            {
                if (e.EventData != null) 
                    Console.WriteLine(e.EventData.Message);
            }
        }
    }
}
#endregion
// ReSharper restore InconsistentNaming
// ReSharper restore CheckNamespace
