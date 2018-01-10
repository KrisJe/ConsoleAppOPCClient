// $Header: $
// Copyright (c) CODE Consulting and Development, s.r.o., Plzen. All rights reserved.

using OpcLabs.EasyOpc.AlarmsAndEvents.OperationModel;
// ReSharper disable CheckNamespace
// ReSharper disable InconsistentNaming
#region Example
// This example shows how to set the filtering criteria to be used for the event subscription.
using JetBrains.Annotations;
using OpcLabs.EasyOpc.AlarmsAndEvents;
using OpcLabs.EasyOpc.DataAccess;
using System;
using System.Threading;

namespace DocExamples
{
    namespace _AESubscriptionFilter
    {

        class Properties
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
                    Sources = new AENodeDescriptor[] {"Simulation.ConditionState1", "Simulation.ConditionState3"}
                };
                // You can also filter using event types, categories, severity, and areas.
                int handle = EasyAEClient.SubscribeEvents("", "OPCLabs.KitEventServer.2", 1000, null, subscriptionFilter);

                // Allow time for initial refresh
                Thread.Sleep(5 * 1000);

                // Set some events to active state.
                // The activation below will come from a source contained in a filter and the notification will arrive.
                EasyDaClient.WriteItemValue("", "OPCLabs.KitServer.2", "SimulateEvents.ConditionState1.Activate", true);
                // The activation below will come from a source that is not contained in a filter and the notification will not arrive.
                EasyDaClient.WriteItemValue("", "OPCLabs.KitServer.2", "SimulateEvents.ConditionState2.Activate", true);

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
