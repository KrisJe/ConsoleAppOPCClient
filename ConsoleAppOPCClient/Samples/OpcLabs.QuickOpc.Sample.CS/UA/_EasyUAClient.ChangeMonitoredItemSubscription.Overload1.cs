﻿// $Header: $ 
// Copyright (c) CODE Consulting and Development, s.r.o., Plzen. All rights reserved.

using OpcLabs.EasyOpc.UA.OperationModel;
// ReSharper disable InconsistentNaming
// ReSharper disable LocalizableElement
// ReSharper disable PossibleNullReferenceException
#region Example
// This example shows how to change the sampling rate of an existing monitored item subscription.
using OpcLabs.EasyOpc.UA;
using System;

namespace UADocExamples
{
    namespace _EasyUAClient
    {
        class ChangeMonitoredItemSubscription
        {
            public static void Overload1()
            {
                var easyUAClient = new EasyUAClient();
                easyUAClient.DataChangeNotification += easyUAClient_DataChangeNotification;

                Console.WriteLine("Subscribing...");
                int handle = easyUAClient.SubscribeDataChange(
                    "http://opcua.demo-this.com:51211/UA/SampleServer",   // or "opc.tcp://opcua.demo-this.com:51210/UA/SampleServer"
                    "nsu=http://test.org/UA/Data/;i=10853",
                    1000);

                Console.WriteLine("Processing monitored item changed events for 10 seconds...");
                System.Threading.Thread.Sleep(10 * 1000);

                Console.WriteLine("Changing subscription...");
                easyUAClient.ChangeMonitoredItemSubscription(handle, 100);

                Console.WriteLine("Processing monitored item changed events for 10 seconds...");
                System.Threading.Thread.Sleep(10 * 1000);

                Console.WriteLine("Unsubscribing...");
                easyUAClient.UnsubscribeAllMonitoredItems();

                Console.WriteLine("Waiting for 5 seconds...");
                System.Threading.Thread.Sleep(5 * 1000);
            }

            static void easyUAClient_DataChangeNotification(object sender, EasyUADataChangeNotificationEventArgs e)
            {
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
