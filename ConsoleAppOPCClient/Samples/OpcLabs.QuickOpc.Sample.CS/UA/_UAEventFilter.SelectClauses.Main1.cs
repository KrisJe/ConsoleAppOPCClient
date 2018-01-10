// $Header: $ 
// Copyright (c) CODE Consulting and Development, s.r.o., Plzen. All rights reserved.

// ReSharper disable LocalizableElement
// ReSharper disable InconsistentNaming
// ReSharper disable PossibleNullReferenceException
#region Example
// This example shows how to select fields for event notifications.
using OpcLabs.BaseLib.OperationModel;
using OpcLabs.EasyOpc.UA;
using OpcLabs.EasyOpc.UA.AddressSpace.Standard;
using OpcLabs.EasyOpc.UA.AlarmsAndConditions;
using OpcLabs.EasyOpc.UA.Filtering;
using OpcLabs.EasyOpc.UA.OperationModel;
using System;
using System.Collections.Generic;

namespace UADocExamples
{
    namespace _UAEventFilter
    {
        class SelectClauses
        {
            public static void Main1()
            {
                // Instantiate the client object and hook events
                var easyUAClient = new EasyUAClient();
                easyUAClient.EventNotification += easyUAClient_EventNotification;

                Console.WriteLine("Subscribing...");
                easyUAClient.SubscribeEvent(
                    "opc.tcp://opcua.demo-this.com:62544/Quickstarts/AlarmConditionServer",
                    UAObjectIds.Server,
                    1000,
                    new UAAttributeFieldCollection
                    {
                        // Select specific fields using standard operand symbols
                        UABaseEventObject.Operands.NodeId,
                        UABaseEventObject.Operands.SourceNode,
                        UABaseEventObject.Operands.SourceName,
                        UABaseEventObject.Operands.Time,

                        // Select specific fields using an event type ID and a simple relative path
                        UAFilterElements.SimpleAttribute(UAObjectTypeIds.BaseEventType, "/Message"),
                        UAFilterElements.SimpleAttribute(UAObjectTypeIds.BaseEventType, "/Severity"),
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
                Console.WriteLine();

                // Display the event
                if (e.EventData == null)
                {
                    Console.WriteLine(e);
                    return;
                }
                Console.WriteLine("All fields:");
                foreach (KeyValuePair<UAAttributeField, ValueResult> pair in e.EventData.FieldResults)
                {
                    UAAttributeField attributeField = pair.Key;
                    ValueResult valueResult = pair.Value;
                    Console.WriteLine("  {0} -> {1}", attributeField, valueResult);
                }
                // Extracting a specific field using a standard operand symbol
                Console.WriteLine("Source name: {0}", 
                    e.EventData.FieldResults[UABaseEventObject.Operands.SourceName]);
                // Extracting a specific field using an event type ID and a simple relative path
                Console.WriteLine("Message: {0}", 
                    e.EventData.FieldResults[UAFilterElements.SimpleAttribute(UAObjectTypeIds.BaseEventType, "/Message")]);
            }
        }
    }
}
#endregion
// ReSharper restore PossibleNullReferenceException
// ReSharper restore LocalizableElement
// ReSharper restore InconsistentNaming
