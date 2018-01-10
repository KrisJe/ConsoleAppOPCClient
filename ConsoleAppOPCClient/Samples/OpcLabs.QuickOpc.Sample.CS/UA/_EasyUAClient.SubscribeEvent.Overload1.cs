// $Header: $ 
// Copyright (c) CODE Consulting and Development, s.r.o., Plzen. All rights reserved.

// ReSharper disable LocalizableElement
// ReSharper disable InconsistentNaming
// ReSharper disable PossibleNullReferenceException
#region Example
// This example shows how to subscribe to event notifications and display each incoming event.
using OpcLabs.EasyOpc.UA;
using OpcLabs.EasyOpc.UA.AddressSpace.Standard;
using OpcLabs.EasyOpc.UA.OperationModel;
using System;

namespace UADocExamples
{
    namespace _EasyUAClient
    {
        partial class SubscribeEvent
        {
            public static void Overload1()
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
                // Display the event
                Console.WriteLine(e);
            }
        }
    }
}
#endregion
// ReSharper restore PossibleNullReferenceException
// ReSharper restore LocalizableElement
// ReSharper restore InconsistentNaming
