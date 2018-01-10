// $Header: $ 
// Copyright (c) CODE Consulting and Development, s.r.o., Plzen. All rights reserved.

#region Example
// This example shows how to subscribe to event notifications, pull events, and display each incoming event.
using OpcLabs.EasyOpc.UA;
using OpcLabs.EasyOpc.UA.OperationModel;
using OpcLabs.EasyOpc.UA.AddressSpace.Standard;
using System;

namespace UADocExamples
{
    namespace _EasyUAClient
    {
        class PullEventNotification
        {
            public static void Main1()
            {
                // Instantiate the client object
                // In order to use event pull, you must set a non-zero queue capacity upfront.
                var easyUAClient = new EasyUAClient { PullEventNotificationQueueCapacity = 1000 };

                Console.WriteLine("Subscribing...");
                easyUAClient.SubscribeEvent(
                    "opc.tcp://opcua.demo-this.com:62544/Quickstarts/AlarmConditionServer",
                    UAObjectIds.Server, 
                    1000);

                Console.WriteLine("Processing event notifications for 30 seconds...");
                int endTick = Environment.TickCount + 30 * 1000;
                do
                {
                    EasyUAEventNotificationEventArgs eventArgs = easyUAClient.PullEventNotification(2 * 1000);
                    if (eventArgs != null)
                        // Handle the notification event
                        Console.WriteLine(eventArgs);
                } while (Environment.TickCount < endTick);
            }
        }
    }
}
#endregion
