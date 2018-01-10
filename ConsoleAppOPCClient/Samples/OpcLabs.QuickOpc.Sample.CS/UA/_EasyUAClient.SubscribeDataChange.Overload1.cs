// $Header: $ 
// Copyright (c) CODE Consulting and Development, s.r.o., Plzen. All rights reserved.

using OpcLabs.EasyOpc.UA.OperationModel;
// ReSharper disable LocalizableElement
// ReSharper disable InconsistentNaming
// ReSharper disable PossibleNullReferenceException
#region Example
// This example shows how to subscribe to changes of a single monitored item and display the value of the item with each change.
using OpcLabs.EasyOpc.UA;
using System;

namespace UADocExamples
{
    namespace _EasyUAClient
    {
        partial class SubscribeDataChange
        {
            public static void Overload1()
            {
                // Instantiate the client object and hook events
                var easyUAClient = new EasyUAClient();
                easyUAClient.DataChangeNotification += easyUAClient_DataChangeNotification;

                Console.WriteLine("Subscribing...");
                easyUAClient.SubscribeDataChange(
                    "http://opcua.demo-this.com:51211/UA/SampleServer",   // or "opc.tcp://opcua.demo-this.com:51210/UA/SampleServer"
                    "nsu=http://test.org/UA/Data/;i=10853",
                    1000);

                Console.WriteLine("Processing data change events for 20 seconds...");
                System.Threading.Thread.Sleep(20 * 1000);

                Console.WriteLine("Unsubscribing...");
                easyUAClient.UnsubscribeAllMonitoredItems();

                Console.WriteLine("Waiting for 5 seconds...");
                System.Threading.Thread.Sleep(5 * 1000);
            }

            static void easyUAClient_DataChangeNotification(object sender, EasyUADataChangeNotificationEventArgs e)
            {
                // Display value
                // Remark: Production code would check e.Exception before accessing e.AttributeData.
                Console.WriteLine(e.AttributeData.Value);
            }
        }
    }
}
#endregion
// ReSharper restore PossibleNullReferenceException
// ReSharper restore LocalizableElement
// ReSharper restore InconsistentNaming
