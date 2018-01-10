// $Header: $
// Copyright (c) CODE Consulting and Development, s.r.o., Plzen. All rights reserved.
// ReSharper disable CheckNamespace
// ReSharper disable InconsistentNaming
#region Example
// This example shows how to subscribe to events and display the event message with each notification, using a callback method
// specified using lambda expression.

using System.Diagnostics;
using OpcLabs.EasyOpc.AlarmsAndEvents;
using System;
using System.Threading;

namespace DocExamples
{
    namespace _EasyAEClient
    {
        partial class SubscribeEvents
        {
            public static void CallbackLambda()
            {
                // Instantiate the client object
                var easyAEClient = new EasyAEClient();

                Console.WriteLine("Subscribing...");
                // The callback is a lambda expression the displays the event message
                easyAEClient.SubscribeEvents("", "OPCLabs.KitEventServer.2", 1000,
                    (sender, eventArgs) =>
                        {
                            Debug.Assert(eventArgs != null);
                            if (eventArgs.EventData != null) 
                                Console.WriteLine(eventArgs.EventData.Message);
                        });

                Console.WriteLine("Processing event notifications for 20 seconds...");
                Thread.Sleep(20 * 1000);

                Console.WriteLine("Unsubscribing...");
                easyAEClient.UnsubscribeAllEvents();

                Console.WriteLine("Waiting for 2 seconds...");
                Thread.Sleep(2 * 1000);
            }
        }
    }
}
#endregion
// ReSharper restore InconsistentNaming
// ReSharper restore CheckNamespace
