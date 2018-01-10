// $Header: $ 
// Copyright (c) CODE Consulting and Development, s.r.o., Plzen. All rights reserved.

using OpcLabs.EasyOpc.UA.OperationModel;
// ReSharper disable LocalizableElement
// ReSharper disable InconsistentNaming
// ReSharper disable PossibleNullReferenceException
#region Example
// This example shows how change the sampling rate of multiple existing monitored item subscriptions.
using OpcLabs.EasyOpc.UA;
using System;

namespace UADocExamples
{
    namespace _EasyUAClient
    {
        class ChangeMultipleMonitoredItemSubscriptions
        {
            public static void Overload2()
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

                Console.WriteLine("Processing monitored item changed events for 10 seconds...");
                System.Threading.Thread.Sleep(10 * 1000);

                Console.WriteLine("Changing subscriptions...");
                easyUAClient.ChangeMultipleMonitoredItemSubscriptions(handleArray, 100);

                Console.WriteLine("Processing monitored item changed events for 10 seconds...");
                System.Threading.Thread.Sleep(10 * 1000);

                Console.WriteLine("Unsubscribing...");
                easyUAClient.UnsubscribeAllMonitoredItems();

                Console.WriteLine("Waiting for 5 seconds...");
                System.Threading.Thread.Sleep(5 * 1000);
            }

            static void easyUAClient_DataChangeNotification(object sender, EasyUADataChangeNotificationEventArgs e)
            {
                // Display value
                // Remark: Production code would check e.Exception before accessing e.AttributeData.
                Console.WriteLine("{0}: {1}", e.Arguments.NodeDescriptor, e.AttributeData.Value);
            }
        }
    }
}
#endregion
// ReSharper restore PossibleNullReferenceException
// ReSharper restore LocalizableElement
// ReSharper restore InconsistentNaming
