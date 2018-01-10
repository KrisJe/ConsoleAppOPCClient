// $Header: $
// Copyright (c) CODE Consulting and Development, s.r.o., Plzen. All rights reserved.

using OpcLabs.EasyOpc.AlarmsAndEvents.OperationModel;
// ReSharper disable CheckNamespace
// ReSharper disable InconsistentNaming
#region Example
// This example shows how to unsubscribe from all event notifications.
using JetBrains.Annotations;
using OpcLabs.EasyOpc.AlarmsAndEvents;
using System;
using System.Threading;

namespace DocExamples
{
    namespace _EasyAEClient
    {

        class UnsubscribeAllEvents
        {
            public static void Main1()
            {
                using (var easyAEClient = new EasyAEClient())
                {
                    var eventHandler = new EasyAENotificationEventHandler(easyAEClient_Notification);
                    easyAEClient.Notification += eventHandler;

                    Console.WriteLine("Subscribing...");
                    easyAEClient.SubscribeEvents("", "OPCLabs.KitEventServer.2", 1000);

                    Console.WriteLine("Waiting for 10 seconds...");
                    Thread.Sleep(10 * 1000);

                    Console.WriteLine("Unsubscribing...");
                    easyAEClient.UnsubscribeAllEvents();

                    Console.WriteLine("Waiting for 10 seconds...");
                    Thread.Sleep(10 * 1000);
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
