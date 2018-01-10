// $Header: $ 
// Copyright (c) CODE Consulting and Development, s.r.o., Plzen. All rights reserved.

using OpcLabs.EasyOpc.UA.OperationModel;
// ReSharper disable LocalizableElement
// ReSharper disable InconsistentNaming
#region Example
// This example shows how to obtain parameters of certain monitored item subscription.
using OpcLabs.EasyOpc.UA;
using System;

namespace UADocExamples
{
    namespace _EasyUAClient
    {
        class GetMonitoredItemArguments
        {
            public static void Main1()
            {
                // Instantiate the client object and hook events
                var easyUAClient = new EasyUAClient();
                easyUAClient.DataChangeNotification += easyUAClient_DataChangeNotification;

                Console.WriteLine("Subscribing...");
                int[] handleArray = easyUAClient.SubscribeMultipleMonitoredItems(new[]
                    {
                        new EasyUAMonitoredItemArguments(null, "http://opcua.demo-this.com:51211/UA/SampleServer", 
                            "nsu=http://test.org/UA/Data/;i=10845", 1000),
                        new EasyUAMonitoredItemArguments(null, "http://opcua.demo-this.com:51211/UA/SampleServer", 
                            "nsu=http://test.org/UA/Data/;i=10853", 1000),
                        new EasyUAMonitoredItemArguments(null, "http://opcua.demo-this.com:51211/UA/SampleServer", 
                            "nsu=http://test.org/UA/Data/;i=10855", 1000)
                    });

                Console.WriteLine("Getting monitored item arguments...");
                EasyUAMonitoredItemArguments monitoredItemArguments =
                    easyUAClient.GetMonitoredItemArguments(handleArray[2]);
                Console.WriteLine("NodeDescriptor: {0}", monitoredItemArguments.NodeDescriptor);
                Console.WriteLine("SamplingInterval: {0}", monitoredItemArguments.MonitoringParameters.SamplingInterval);
                Console.WriteLine("PublishingInterval: {0}", monitoredItemArguments.SubscriptionParameters.PublishingInterval);

                Console.WriteLine("Waiting for 5 seconds...");
                System.Threading.Thread.Sleep(5 * 1000);

                Console.WriteLine("Unsubscribing...");
                easyUAClient.UnsubscribeAllMonitoredItems();

                Console.WriteLine("Waiting for 5 seconds...");
                System.Threading.Thread.Sleep(5 * 1000);
            }

            static void easyUAClient_DataChangeNotification(object sender, EasyUADataChangeNotificationEventArgs e)
            {
                // Your code would do the processing here
            }
        }
    }
}
#endregion
// ReSharper restore LocalizableElement
// ReSharper restore InconsistentNaming
