// $Header: $
// Copyright (c) CODE Consulting and Development, s.r.o., Plzen. All rights reserved.

using OpcLabs.EasyOpc.AlarmsAndEvents.OperationModel;
// ReSharper disable CheckNamespace
// ReSharper disable InconsistentNaming
#region Example
// This example shows how to subscribe to events with specified event attributes, and obtain the attribute values in event 
// notifications.
using System;
using System.Collections.Generic;
using System.Threading;
using JetBrains.Annotations;
using OpcLabs.EasyOpc.AlarmsAndEvents;
using OpcLabs.EasyOpc.DataAccess;

namespace DocExamples
{
    namespace _EasyAENotificationEventArgs
    {
        class AttributeValues
        {
            public static void Main1()
            {
                var easyAEClient = new EasyAEClient();
                var easyDAClient = new EasyDAClient();

                var eventHandler = new EasyAENotificationEventHandler(easyAEClient_Notification);
                easyAEClient.Notification += eventHandler;

                // Inactivate the event condition (we will later activate it and receive the notification)
                easyDAClient.WriteItemValue("", "OPCLabs.KitServer.2", "SimulateEvents.ConditionState1.Inactivate", true);

                var subscriptionFilter = new AESubscriptionFilter
                {
                    Sources = new AENodeDescriptor[] {"Simulation.ConditionState1"}
                };

                // Prepare a dictionary holding requested event attributes for each event category
                // The event category IDs and event attribute IDs are hard-coded here, but can be obtained from the OPC 
                // server by querying as well.
                var returnedAttributesByCategory = new AEAttributeSetDictionary();
                returnedAttributesByCategory[0x00ECFF02] = new long[] {0x00EB0003, 0x00EB0008};

                Console.WriteLine("Subscribing to events...");
                int handle = easyAEClient.SubscribeEvents("", "OPCLabs.KitEventServer.2", 1000, null, subscriptionFilter, 
                    returnedAttributesByCategory);

                // Give the refresh operation time to complete
                Thread.Sleep(5 * 1000);

                // Trigger an event carrying specified attributes (activate the condition)
                easyDAClient.WriteItemValue("", "OPCLabs.KitServer.2",
                    "SimulateEvents.ConditionState1.AttributeValues.15400963", 123456);
                easyDAClient.WriteItemValue("", "OPCLabs.KitServer.2", 
                    "SimulateEvents.ConditionState1.AttributeValues.15400968", "Some string value");
                easyDAClient.WriteItemValue("", "OPCLabs.KitServer.2", "SimulateEvents.ConditionState1.Activate", true);

                Console.WriteLine("Processing event notifications for 10 seconds...");
                Thread.Sleep(10 * 1000);

                easyAEClient.UnsubscribeEvents(handle);
            }

            // Notification event handler
            static void easyAEClient_Notification([NotNull] object sender, [NotNull] EasyAENotificationEventArgs e)
            {
                if (!e.Refresh && (e.EventData != null))
                {
                    // Display all received event attribute IDs and their corresponding values
                    Console.WriteLine("Event attribute count: {0}", e.EventData.AttributeValues.Count);
                    foreach (KeyValuePair<long, object> pair in e.EventData.AttributeValues)
                        Console.WriteLine("    {0}: {1}", pair.Key, pair.Value);
                }
            }
        }
    }
}
#endregion
// ReSharper restore InconsistentNaming
// ReSharper restore CheckNamespace
