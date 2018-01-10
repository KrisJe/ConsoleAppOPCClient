// $Header: $ 
// Copyright (c) CODE Consulting and Development, s.r.o., Plzen. All rights reserved.

// ReSharper disable LocalizableElement
// ReSharper disable PossibleNullReferenceException
#region Example
// This example shows how to subscribe to event notifications and display each incoming event
// using a callback method that is provided as lambda expression.
using OpcLabs.EasyOpc.UA;
using System;
using OpcLabs.EasyOpc.UA.AddressSpace.Standard;

namespace UADocExamples
{
    namespace _EasyUAClient
    {
        partial class SubscribeEvent
        {
            public static void CallbackLambda()
            {
                // Instantiate the client object
                var easyUAClient = new EasyUAClient();

                Console.WriteLine("Subscribing...");
                // The callback is a lambda expression the displays the event
                easyUAClient.SubscribeEvent(
                    "opc.tcp://opcua.demo-this.com:62544/Quickstarts/AlarmConditionServer",
                    UAObjectIds.Server,
                    1000,
                    (sender, eventArgs) => Console.WriteLine(eventArgs));
                // Remark: Production code would check e.Exception before accessing e.EventData.

                Console.WriteLine("Processing event notifications for 30 seconds...");
                System.Threading.Thread.Sleep(30 * 1000);

                Console.WriteLine("Unsubscribing...");
                easyUAClient.UnsubscribeAllMonitoredItems();

                Console.WriteLine("Waiting for 2 seconds...");
                System.Threading.Thread.Sleep(2 * 1000);
            }
        }
    }
}
#endregion
// ReSharper restore PossibleNullReferenceException
// ReSharper restore LocalizableElement
