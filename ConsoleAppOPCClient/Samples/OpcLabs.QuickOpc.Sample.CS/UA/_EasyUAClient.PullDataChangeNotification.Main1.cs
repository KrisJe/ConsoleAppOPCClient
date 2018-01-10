// $Header: $ 
// Copyright (c) CODE Consulting and Development, s.r.o., Plzen. All rights reserved.

#region Example
// This example shows how to subscribe to changes of a single monitored item, pull events, and display each change.
using OpcLabs.EasyOpc.UA;
using OpcLabs.EasyOpc.UA.OperationModel;
using System;

namespace UADocExamples
{
    namespace _EasyUAClient
    {
        class PullDataChangeNotification
        {
            public static void Main1()
            {
                // Instantiate the client object
                // In order to use event pull, you must set a non-zero queue capacity upfront.
                var easyUAClient = new EasyUAClient { PullDataChangeNotificationQueueCapacity = 1000 };

                Console.WriteLine("Subscribing...");
                easyUAClient.SubscribeDataChange(
                    "http://opcua.demo-this.com:51211/UA/SampleServer",   // or "opc.tcp://opcua.demo-this.com:51210/UA/SampleServer"
                    "nsu=http://test.org/UA/Data/;i=10853",
                    1000);

                Console.WriteLine("Processing data change events for 1 minute...");
                int endTick = Environment.TickCount + 60 * 1000;
                do
                {
                    EasyUADataChangeNotificationEventArgs eventArgs = easyUAClient.PullDataChangeNotification(2 * 1000);
                    if (eventArgs != null)
                        // Handle the notification event
                        Console.WriteLine(eventArgs);
                } while (Environment.TickCount < endTick);
            }
        }
    }
}
#endregion
