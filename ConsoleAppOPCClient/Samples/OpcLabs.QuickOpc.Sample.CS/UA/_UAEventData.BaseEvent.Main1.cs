// $Header: $ 
// Copyright (c) CODE Consulting and Development, s.r.o., Plzen. All rights reserved.

// ReSharper disable LocalizableElement
// ReSharper disable InconsistentNaming
// ReSharper disable PossibleNullReferenceException
#region Example
// This example shows how to display specific fields of incoming events that are derived from base event type.
using OpcLabs.EasyOpc.UA;
using OpcLabs.EasyOpc.UA.AddressSpace.Standard;
using OpcLabs.EasyOpc.UA.AlarmsAndConditions;
using OpcLabs.EasyOpc.UA.OperationModel;
using System;

namespace UADocExamples
{
    namespace _UAEventData
    {
        class BaseEvent
        {
            public static void Main1()
            {
                // Instantiate the client object and hook events
                var easyUAClient = new EasyUAClient();
                easyUAClient.EventNotification += easyUAClient_EventNotification;

                Console.WriteLine("Subscribing...");
                easyUAClient.SubscribeEvent(
                    "opc.tcp://opcua.demo-this.com:62544/Quickstarts/AlarmConditionServer",
                    UAObjectIds.Server,
                    1000);

                Console.WriteLine("Processing event notifications for 30 seconds...");
                System.Threading.Thread.Sleep(30 * 1000);

                Console.WriteLine("Unsubscribing...");
                easyUAClient.UnsubscribeAllMonitoredItems();

                Console.WriteLine("Waiting for 5 seconds...");
                System.Threading.Thread.Sleep(5 * 1000);
            }

            static void easyUAClient_EventNotification(object sender, EasyUAEventNotificationEventArgs e)
            {
                Console.WriteLine();

                // Display the event
                if (e.EventData == null)
                {
                    Console.WriteLine(e);
                    return;
                }
                UABaseEventObject baseEventObject = e.EventData.BaseEvent;
                Console.WriteLine("Source name: {0}", baseEventObject.SourceName);
                Console.WriteLine("Message: {0}", baseEventObject.Message);
                Console.WriteLine("Severity: {0}", baseEventObject.Severity);
            }
        }
    }
}
#endregion
// ReSharper restore PossibleNullReferenceException
// ReSharper restore LocalizableElement
// ReSharper restore InconsistentNaming
