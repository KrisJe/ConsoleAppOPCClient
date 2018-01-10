// $Header: $
// Copyright (c) CODE Consulting and Development, s.r.o., Plzen. All rights reserved.

// ReSharper disable CheckNamespace
// ReSharper disable InconsistentNaming
// ReSharper disable PossibleNullReferenceException
#region Example
// This example shows how change the percent deadband of an existing subscription.
using OpcLabs.BaseLib.ComInterop;
using OpcLabs.EasyOpc.DataAccess.OperationModel;
using OpcLabs.EasyOpc.DataAccess;
using System;
using System.Threading;

namespace DocExamples
{
    namespace _EasyDAClient
    {

        partial class ChangeItemSubscription
        {
            public static void PercentDeadband()
            {
                using (var easyDAClient = new EasyDAClient())
                {
                    easyDAClient.ItemChanged += easyDAClient_ItemChanged_PercentDeadband;

                    Console.WriteLine("Subscribing with 10% deadband...");
                    int handle = easyDAClient.SubscribeItem("", "OPCLabs.KitServer.2", "Simulation.Ramp 0-100 (10 s)", 
                        VarTypes.Empty, 100, 10.0f, null);

                    Console.WriteLine("Waiting for 10 seconds...");
                    Thread.Sleep(10 * 1000);

                    Console.WriteLine("Changing subscription to 0% deadband...");
                    easyDAClient.ChangeItemSubscription(handle, new DAGroupParameters(100, 0.0f));

                    Console.WriteLine("Waiting for 10 seconds...");
                    Thread.Sleep(10 * 1000);

                    Console.WriteLine("Unsubscribing...");
                    easyDAClient.UnsubscribeAllItems();

                    Console.WriteLine("Waiting for 10 seconds...");
                    Thread.Sleep(10 * 1000);
                }
            }

            // Item changed event handler
            static void easyDAClient_ItemChanged_PercentDeadband(object sender, EasyDAItemChangedEventArgs e)
            {
                Console.WriteLine(e.Vtq);
            }
        }
    }
}
#endregion
// ReSharper restore InconsistentNaming
// ReSharper restore CheckNamespace
// ReSharper restore PossibleNullReferenceException
