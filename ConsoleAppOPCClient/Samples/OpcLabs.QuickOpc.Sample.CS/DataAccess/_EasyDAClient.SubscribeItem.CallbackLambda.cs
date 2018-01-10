// $Header: $
// Copyright (c) CODE Consulting and Development, s.r.o., Plzen. All rights reserved.

// ReSharper disable CheckNamespace
#region Example

// This example shows how subscribe to changes of multiple items and display the value of the item with each change,
// using a callback method specified using lambda expression.

using System.Diagnostics;
using OpcLabs.EasyOpc.DataAccess;
using System;
using System.Threading;

namespace DocExamples
{
    namespace _EasyDAClient
    {
        partial class SubscribeItem
        {
            public static void CallbackLambda()
            {
                // Instantiate the client object
                var easyDAClient = new EasyDAClient();

                Console.WriteLine("Subscribing...");
                // The callback is a lambda expression the displays the value
                easyDAClient.SubscribeItem("", "AutoJet.ACPFileServerDA.1", "Simulation.Random", 1000,
                    (sender, eventArgs) =>
                        {
                            Debug.Assert(eventArgs != null);

                            if (eventArgs.Exception != null)
                                Console.WriteLine(eventArgs.Exception.ToString());
                            else
                            {
                                Debug.Assert(eventArgs.Vtq != null);
                                Console.WriteLine(eventArgs.Vtq.ToString());
                            }
                        });

                Console.WriteLine("Processing item changed events for 10 seconds...");
                Thread.Sleep(10 * 1000);

                Console.WriteLine("Unsubscribing...");
                easyDAClient.UnsubscribeAllItems();

                Console.WriteLine("Waiting for 2 seconds...");
                Thread.Sleep(2 * 1000);
            }
        }
    }
}
#endregion
// ReSharper restore CheckNamespace
