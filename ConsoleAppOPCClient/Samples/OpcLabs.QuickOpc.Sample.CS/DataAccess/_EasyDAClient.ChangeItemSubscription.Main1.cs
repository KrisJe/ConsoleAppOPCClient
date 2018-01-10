// $Header: $
// Copyright (c) CODE Consulting and Development, s.r.o., Plzen. All rights reserved.

using OpcLabs.EasyOpc.DataAccess.OperationModel;
// ReSharper disable CheckNamespace
// ReSharper disable InconsistentNaming
#region Example
// This example shows how change the update rate of an existing subscription.
using JetBrains.Annotations;
using OpcLabs.EasyOpc.DataAccess;
using System;
using System.Threading;

namespace DocExamples
{
    namespace _EasyDAClient
    {

        partial class ChangeItemSubscription
        {
            public static void Main1()
            {
                using (var easyDAClient = new EasyDAClient())
                {
                    easyDAClient.ItemChanged += easyDAClient_ItemChanged;

                    Console.WriteLine("Subscribing...");
                    int handle = easyDAClient.SubscribeItem("", "AutoJet.ACPFileServerDA.1", "Simulation.Random", 1000);

                    Console.WriteLine("Waiting for 10 seconds...");
                    Thread.Sleep(10 * 1000);

                    Console.WriteLine("Changing subscription...");
                    easyDAClient.ChangeItemSubscription(handle, new DAGroupParameters(100));

                    Console.WriteLine("Waiting for 10 seconds...");
                    Thread.Sleep(10 * 1000);

                    Console.WriteLine("Unsubscribing...");
                    easyDAClient.UnsubscribeAllItems();

                    Console.WriteLine("Waiting for 10 seconds...");
                    Thread.Sleep(10 * 1000);
                }
            }

            // Item changed event handler
            static void easyDAClient_ItemChanged([NotNull] object sender, [NotNull] EasyDAItemChangedEventArgs e)
            {
                Console.WriteLine(e.Vtq);
            }
        }
    }
}
#endregion
// ReSharper restore InconsistentNaming
// ReSharper restore CheckNamespace
