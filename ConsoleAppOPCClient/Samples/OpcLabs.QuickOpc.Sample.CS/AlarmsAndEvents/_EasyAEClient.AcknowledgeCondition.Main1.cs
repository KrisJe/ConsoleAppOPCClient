// $Header: $
// Copyright (c) CODE Consulting and Development, s.r.o., Plzen. All rights reserved.

using OpcLabs.EasyOpc.AlarmsAndEvents.OperationModel;
// ReSharper disable CheckNamespace
// ReSharper disable InconsistentNaming
#region Example
// This example shows how to acknowledge an event condition in the OPC server.
using JetBrains.Annotations;
using OpcLabs.EasyOpc.AlarmsAndEvents;
using OpcLabs.EasyOpc.DataAccess;
using System;
using System.Threading;

namespace DocExamples
{
    namespace _EasyAEClient
    {

        class AcknowledgeCondition
        {
            [NotNull]
            static readonly EasyAEClient EasyAEClient = new EasyAEClient();
            [NotNull]
            static readonly EasyDAClient EasyDAClient = new EasyDAClient();

            static volatile bool _done;

            public static void Main1()
            {
                var eventHandler = new EasyAENotificationEventHandler(easyAEClient_Notification);
                EasyAEClient.Notification += eventHandler;

                Console.WriteLine("Processing event notifications for 1 minute...");
                var subscriptionFilter = new AESubscriptionFilter
                {
                    Sources = new AENodeDescriptor[] {"Simulation.ConditionState1"}
                };
                int handle = EasyAEClient.SubscribeEvents("", "OPCLabs.KitEventServer.2", 1000, null, subscriptionFilter);

                // Give the refresh operation time to complete
                Thread.Sleep(5 * 1000);

                // Trigger an acknowledgeable event
                EasyDAClient.WriteItemValue("", "OPCLabs.KitServer.2", "SimulateEvents.ConditionState1.Activate", true);

                _done = false;
                DateTime endTime = DateTime.Now + new TimeSpan(0, 0, 5);
                while ((!_done) && (DateTime.Now < endTime))
                    Thread.Sleep(1000);

                // Give some time to also receive the acknowledgement notification
                Thread.Sleep(5 * 1000);

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
                    Console.WriteLine("Event.AcknowledgeRequired: {0}", eventData.AcknowledgeRequired);

                    if (eventData.AcknowledgeRequired)
                    {
                        Console.WriteLine(">>>>> ACKNOWLEDGING THIS EVENT");
                        EasyAEClient.AcknowledgeCondition("", "OPCLabs.KitEventServer.2", "Simulation.ConditionState1", "Simulated",
                            eventData.ActiveTime, eventData.Cookie);
                        Console.WriteLine(">>>>> EVENT ACKNOWLEDGED");
                        _done = true;
                    }
                }
            }
        }
    }
}
#endregion
// ReSharper restore InconsistentNaming
// ReSharper restore CheckNamespace
