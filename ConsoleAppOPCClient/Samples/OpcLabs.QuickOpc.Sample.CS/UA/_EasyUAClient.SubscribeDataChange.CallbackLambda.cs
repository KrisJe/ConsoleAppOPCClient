// $Header: $ 
// Copyright (c) CODE Consulting and Development, s.r.o., Plzen. All rights reserved.
// ReSharper disable LocalizableElement
// ReSharper disable PossibleNullReferenceException
#region Example
// This example shows how to subscribe to changes of a single monitored item, and display the value of the item with each change
// using a callback method that is provided as lambda expression.
using OpcLabs.EasyOpc.UA;
using System;

namespace UADocExamples
{
    namespace _EasyUAClient
    {
        partial class SubscribeDataChange
        {
            public static void CallbackLambda()
            {
                // Instantiate the client object
                var easyUAClient = new EasyUAClient();

                Console.WriteLine("Subscribing...");
                // The callback is a lambda expression the displays the value
                easyUAClient.SubscribeDataChange(
                    "http://opcua.demo-this.com:51211/UA/SampleServer",   // or "opc.tcp://opcua.demo-this.com:51210/UA/SampleServer"
                    "nsu=http://test.org/UA/Data/;i=10853",
                    1000,
                    (sender, eventArgs) => Console.WriteLine(eventArgs.AttributeData.Value));
                // Remark: Production code would check eventArgs.Exception before accessing eventArgs.AttributeData.

                Console.WriteLine("Processing data change events for 10 seconds...");
                System.Threading.Thread.Sleep(10 * 1000);

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
