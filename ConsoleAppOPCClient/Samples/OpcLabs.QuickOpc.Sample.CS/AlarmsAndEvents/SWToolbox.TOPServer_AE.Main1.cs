// $Header: $
// Copyright (c) CODE Consulting and Development, s.r.o., Plzen. All rights reserved.

// ReSharper disable CheckNamespace
// ReSharper disable InconsistentNaming
#region Example

// This example shows how to work with Software Tolbox TOP Server 5 Alarms and Events.
// Use simdemo_WithA&E.opf configuration file and write a value above 1000 to Channel1.Device1.Tag1 or Channel1.Device1.Tag2.

using System.Diagnostics;
using JetBrains.Annotations;
using OpcLabs.EasyOpc.AlarmsAndEvents;
using OpcLabs.EasyOpc.AlarmsAndEvents.AddressSpace;
using OpcLabs.EasyOpc.AlarmsAndEvents.OperationModel;
using System;
using System.Threading;

namespace DocExamples {
namespace SWToolbox { 

    class TOPServer_AE 
    { 
        public static void Main1()
        {
            var easyAEClient = new EasyAEClient();

            // Browse for some areas and sources

            AENodeElementCollection areaElements = easyAEClient.BrowseAreas("", "SWToolbox.TOPServer_AE.V5", "");
            foreach (AENodeElement areaElement in areaElements)
            {
                Debug.Assert(areaElement != null);
                Debug.Assert(areaElement.QualifiedName != null);

                Console.WriteLine("areaElements[\"{0}\"]:", areaElement.Name);
                Console.WriteLine("    .QualifiedName: {0}", areaElement.QualifiedName);

                AENodeElementCollection sourceElements = 
                    easyAEClient.BrowseSources("", "SWToolbox.TOPServer_AE.V5", areaElement.QualifiedName);
                foreach (AENodeElement sourceElement in sourceElements)
                {
                    Debug.Assert(sourceElement != null);

                    Console.WriteLine("    sourceElements[\"{0}\"]:", sourceElement.Name);
                    Console.WriteLine("        .QualifiedName: {0}", sourceElement.QualifiedName);
                }
            }

            // Query for event categories

            AECategoryElementCollection categoryElements = easyAEClient.QueryEventCategories("", "SWToolbox.TOPServer_AE.V5");
            foreach (AECategoryElement categoryElement in categoryElements)
            {
                Debug.Assert(categoryElement != null);
                Console.WriteLine("CategoryElements[\"{0}\"].Description: {1}", categoryElement.CategoryId,
                                  categoryElement.Description);
            }

            // Subscribe to events, wait, and unsubscribe

            var eventHandler = new EasyAENotificationEventHandler(easyAEClient_Notification);
            easyAEClient.Notification += eventHandler;

            int handle = easyAEClient.SubscribeEvents("", "SWToolbox.TOPServer_AE.V5", 1000);

            Console.WriteLine("Processing event notifications for 1 minute...");
            Thread.Sleep(60 * 1000);

            easyAEClient.UnsubscribeEvents(handle);
        }

        // Notification event handler
        static void easyAEClient_Notification([NotNull] object sender, [NotNull] EasyAENotificationEventArgs e)
        {
            if (e.Exception != null) Console.WriteLine("e.Exception.Message: {0}", e.Exception.Message);
            if (e.Exception != null) Console.WriteLine("e.Exception.Source: {0}", e.Exception.Source);
            Console.WriteLine("e.Refresh: {0}", e.Refresh);
            Console.WriteLine("e.RefreshComplete: {0}", e.RefreshComplete);
            if (e.EventData != null) Console.WriteLine("e.EventData.QualifiedSourceName: {0}", e.EventData.QualifiedSourceName);
            if (e.EventData != null) Console.WriteLine("e.EventData.Time: {0}", e.EventData.Time);
            if (e.EventData != null) Console.WriteLine("e.EventData.Message: {0}", e.EventData.Message);
            if (e.EventData != null) Console.WriteLine("e.EventData.EventType: {0}", e.EventData.EventType);
            if (e.EventData != null) Console.WriteLine("e.EventData.CategoryId: {0}", e.EventData.CategoryId);
            if (e.EventData != null) Console.WriteLine("e.EventData.Severity: {0}", e.EventData.Severity);
            if (e.EventData != null) Console.WriteLine("e.EventData.ConditionName: {0}", e.EventData.ConditionName);
            if (e.EventData != null) Console.WriteLine("e.EventData.SubconditionName: {0}", e.EventData.SubconditionName);
            if (e.EventData != null) Console.WriteLine("e.EventData.Enabled: {0}", e.EventData.Enabled);
            if (e.EventData != null) Console.WriteLine("e.EventData.Active: {0}", e.EventData.Active);
            if (e.EventData != null) Console.WriteLine("e.EventData.Acknowledged: {0}", e.EventData.Acknowledged);
            if (e.EventData != null) Console.WriteLine("e.EventData.Quality: {0}", e.EventData.Quality);
            if (e.EventData != null) Console.WriteLine("e.EventData.AcknowledgeRequired: {0}", e.EventData.AcknowledgeRequired);
            if (e.EventData != null) Console.WriteLine("e.EventData.ActiveTime: {0}", e.EventData.ActiveTime);
        }
    } 

}}
#endregion
// ReSharper restore InconsistentNaming
// ReSharper restore CheckNamespace
