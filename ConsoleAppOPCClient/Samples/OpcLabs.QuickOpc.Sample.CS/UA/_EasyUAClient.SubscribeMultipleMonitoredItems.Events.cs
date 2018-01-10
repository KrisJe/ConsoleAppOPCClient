// $Header: $ 
// Copyright (c) CODE Consulting and Development, s.r.o., Plzen. All rights reserved.

// ReSharper disable LocalizableElement
// ReSharper disable InconsistentNaming
// ReSharper disable PossibleNullReferenceException
#region Example
// This example shows how to subscribe to multiple events.
using OpcLabs.EasyOpc.UA;
using OpcLabs.EasyOpc.UA.AddressSpace;
using OpcLabs.EasyOpc.UA.AddressSpace.Standard;
using OpcLabs.EasyOpc.UA.AlarmsAndConditions;
using OpcLabs.EasyOpc.UA.Filtering;
using OpcLabs.EasyOpc.UA.OperationModel;
using System;

namespace UADocExamples
{
    namespace _EasyUAClient
    {
        partial class SubscribeMultipleMonitoredItems
        {
            public static void Events()
            {
                // Instantiate the client object and hook events
                var easyUAClient = new EasyUAClient();
                easyUAClient.EventNotification += easyUAClient_EventNotification;

                Console.WriteLine("Subscribing...");
                easyUAClient.SubscribeMultipleMonitoredItems(new[]
                    {
                        new EasyUAMonitoredItemArguments("firstState", 
                            "opc.tcp://opcua.demo-this.com:62544/Quickstarts/AlarmConditionServer", 
                            UAObjectIds.Server,
                            new UAMonitoringParameters(1000, new UAEventFilterBuilder(
                                UAFilterElements.GreaterThanOrEqual(UABaseEventObject.Operands.Severity, 500),
                                UABaseEventObject.AllFields)))
                            { AttributeId = UAAttributeId.EventNotifier },
                        new EasyUAMonitoredItemArguments("secondState", 
                            "opc.tcp://opcua.demo-this.com:62544/Quickstarts/AlarmConditionServer", 
                            UAObjectIds.Server,
                            new UAMonitoringParameters(2000, new UAEventFilterBuilder(
                                UAFilterElements.Equals(
                                    UABaseEventObject.Operands.SourceNode, 
                                    new UANodeId("nsu=http://opcfoundation.org/Quickstarts/AlarmCondition;ns=2;s=1:Metals/SouthMotor")),
                                UABaseEventObject.AllFields)))
                            { AttributeId = UAAttributeId.EventNotifier },
                    });

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
