// $Header: $
// Copyright (c) CODE Consulting and Development, s.r.o., Plzen. All rights reserved.

using OpcLabs.EasyOpc.AlarmsAndEvents.OperationModel;
using OpcLabs.EasyOpc.DataAccess;
// ReSharper disable CheckNamespace
// ReSharper disable InconsistentNaming
#region Example
// This example shows how to filter the events by their category.
using JetBrains.Annotations;
using OpcLabs.EasyOpc.AlarmsAndEvents;
using System;
using System.Threading;

namespace DocExamples
{
    namespace _EasyAEClient
    {
        partial class SubscribeEvents
        {
            [NotNull]
            static readonly EasyAEClient EasyAEClient = new EasyAEClient();
            [NotNull]
            static readonly EasyDAClient EasyDaClient = new EasyDAClient();

            public static void FilterByCategories()
            {
                var eventHandler = new EasyAENotificationEventHandler(easyAEClient_Notification_FilterByCategories);
                EasyAEClient.Notification += eventHandler;

                Console.WriteLine("Processing event notifications...");
                var subscriptionFilter = new AESubscriptionFilter
                {
                    Categories = new long[] { 15531778 }
                };
                // You can also filter using event types, severity, areas, and sources.
                int handle = EasyAEClient.SubscribeEvents("", "OPCLabs.KitEventServer.2", 1000, null, subscriptionFilter);

                // Allow time for initial refresh
                Thread.Sleep(5 * 1000);

                // Set some events to active state.
                EasyDaClient.WriteItemValue("", "OPCLabs.KitServer.2", "SimulateEvents.ConditionState1.Activate", true);
                EasyDaClient.WriteItemValue("", "OPCLabs.KitServer.2", "SimulateEvents.ConditionState2.Activate", true);

                Thread.Sleep(10 * 1000);

                EasyAEClient.UnsubscribeEvents(handle);
            }

            // Notification event handler
            static void easyAEClient_Notification_FilterByCategories(
                [NotNull] object sender, 
                [NotNull] EasyAENotificationEventArgs e)
            {
                Console.WriteLine();
                Console.WriteLine(e);
                Console.WriteLine("Refresh: {0}", e.Refresh);
                Console.WriteLine("RefreshComplete: {0}", e.RefreshComplete);
                AEEventData eventData = e.EventData;
                if (eventData != null)
                {
                    Console.WriteLine("Event.CategoryId: {0}", eventData.CategoryId);
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
