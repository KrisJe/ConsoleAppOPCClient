// $Header: $
// Copyright (c) CODE Consulting and Development, s.r.o., Plzen. All rights reserved.

using OpcLabs.EasyOpc.AlarmsAndEvents.OperationModel;
// ReSharper disable CheckNamespace
// ReSharper disable InconsistentNaming
#region Example
// This example shows how to for a refresh for all active conditions and inactive, unacknowledged conditions.
using JetBrains.Annotations;
using OpcLabs.EasyOpc.AlarmsAndEvents;
using OpcLabs.EasyOpc.DataAccess;
using System;
using System.Threading;

namespace DocExamples
{
    namespace _EasyAEClient
    {

        class RefreshEventSubscription
        {
            [NotNull] 
            static readonly EasyAEClient EasyAEClient = new EasyAEClient();
            [NotNull]
            static readonly EasyDAClient EasyDaClient = new EasyDAClient();

            public static void Main1()
            {
                var eventHandler = new EasyAENotificationEventHandler(easyAEClient_Notification);
                EasyAEClient.Notification += eventHandler;

                Console.WriteLine("Processing event notifications...");
                var subscriptionFilter = new AESubscriptionFilter
                {
                    Sources = new AENodeDescriptor[]
                    {"Simulation.ConditionState1", "Simulation.ConditionState2", "Simulation.ConditionState3"}
                };
                int handle = EasyAEClient.SubscribeEvents("", "OPCLabs.KitEventServer.2", 1000, null, subscriptionFilter);

                // The component will perform auto-refresh at this point, give it time to happen
                Console.WriteLine("Waiting for 10 seconds...");
                Thread.Sleep(10 * 1000);

                // Set some events to active state, which will cause them to appear in refresh
                Console.WriteLine("Activating conditions and waiting for 10 seconds...");
                EasyDaClient.WriteItemValue("", "AutoJet.ACPFileServerAE.1", "SimulateEvents.ConditionState1.Activate", true);
                EasyDaClient.WriteItemValue("", "AutoJet.ACPFileServerAE.1", "SimulateEvents.ConditionState2.Activate", true);
                Thread.Sleep(10 * 1000);

                Console.WriteLine("Refreshing subscription and waiting for 10 seconds...");
                EasyAEClient.RefreshEventSubscription(handle);
                Thread.Sleep(10 * 1000);

                EasyAEClient.UnsubscribeEvents(handle);
            }

            // Notification event handler
            static void easyAEClient_Notification([NotNull] object sender, [NotNull] EasyAENotificationEventArgs e)
            {
                Console.WriteLine();
                Console.WriteLine("Refresh: {0}", e.Refresh);
                Console.WriteLine("RefreshComplete: {0}", e.RefreshComplete);
                AEEventData eventData = e.EventData;
                if (eventData != null)
                {
                    Console.WriteLine("Event.QualifiedSourceName: {0}", eventData.QualifiedSourceName);
                    Console.WriteLine("Event.Message: {0}", eventData.Message);
                    Console.WriteLine("Event.Active: {0}", eventData.Active);
                    Console.WriteLine("Event.Acknowledged: {0}", eventData.Acknowledged);
                }
            }
        }
    }
}
#endregion
// ReSharper restore InconsistentNaming
// ReSharper restore CheckNamespace
