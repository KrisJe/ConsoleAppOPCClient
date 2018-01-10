// $Header: $ 
// Copyright (c) CODE Consulting and Development, s.r.o., Plzen. All rights reserved.

#region Example
// This example shows how to acknowledge an event.
using System;
using System.Threading;
using OpcLabs.EasyOpc.UA;
using OpcLabs.EasyOpc.UA.AddressSpace;
using OpcLabs.EasyOpc.UA.AddressSpace.Standard;
using OpcLabs.EasyOpc.UA.AlarmsAndConditions;
using OpcLabs.EasyOpc.UA.AlarmsAndConditions.Extensions;
using OpcLabs.EasyOpc.UA.Filtering;

namespace UADocExamples
{
    namespace _EasyUAClient
    {
        class Acknowledge
        {
            public static void Main1()
            {
                // Instantiate the client object
                var easyUAClient = new EasyUAClient();

                UANodeId nodeId = null;
                byte[] eventId = null;
                var anEvent = new ManualResetEvent(initialState: false);

                Console.WriteLine("Subscribing...");
                easyUAClient.SubscribeEvent(
                    "opc.tcp://opcua.demo-this.com:62544/Quickstarts/AlarmConditionServer",
                    UAObjectIds.Server,
                    1000,
                    new UAEventFilterBuilder(
                        UAFilterElements.Equals(
                        UABaseEventObject.Operands.NodeId,
                            new UANodeId(expandedText: "nsu=http://opcfoundation.org/Quickstarts/AlarmCondition;ns=2;s=1:Colours/EastTank?Yellow")),
                        UABaseEventObject.AllFields),
                    (sender, eventArgs) =>
                    {
                        if (!eventArgs.Succeeded)
                        {
                            Console.WriteLine(eventArgs.ErrorMessageBrief);
                            return;
                        }
                        if (eventArgs.EventData != null)
                        {
                            UABaseEventObject baseEventObject = eventArgs.EventData.BaseEvent;
                            Console.WriteLine(baseEventObject);

                            // Make sure we do not catch the event more than once
                            if (anEvent.WaitOne(0))
                                return;

                            nodeId = baseEventObject.NodeId;
                            eventId = baseEventObject.EventId;

                            anEvent.Set();
                        }
                    },
                    state:null);

                Console.WriteLine("Waiting for an event for 30 seconds...");
                if (!anEvent.WaitOne(30*1000))
                {
                    Console.WriteLine("Event not received");
                    return;
                }

                Console.WriteLine("Acknowledging an event...");
                easyUAClient.Acknowledge(
                    "opc.tcp://opcua.demo-this.com:62544/Quickstarts/AlarmConditionServer",
                    nodeId,
                    eventId,
                    "Acknowledged by an automated example code");

                Console.WriteLine("Waiting for 5 seconds...");
                Thread.Sleep(5 * 1000);

                Console.WriteLine("Unsubscribing...");
                easyUAClient.UnsubscribeAllMonitoredItems();

                Console.WriteLine("Waiting for 5 seconds...");
                Thread.Sleep(5 * 1000);
            }
        }
    }
}
#endregion
