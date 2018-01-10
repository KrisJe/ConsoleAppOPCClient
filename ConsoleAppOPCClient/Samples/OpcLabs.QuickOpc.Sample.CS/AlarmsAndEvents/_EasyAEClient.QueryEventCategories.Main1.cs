// $Header: $
// Copyright (c) CODE Consulting and Development, s.r.o., Plzen. All rights reserved.

// ReSharper disable CheckNamespace
#region Example
// This example shows how to enumerate all event categories provided by the OPC server. For each category, it displays its Id 
// and description.
using System.Diagnostics;
using OpcLabs.EasyOpc.AlarmsAndEvents;
using OpcLabs.EasyOpc.AlarmsAndEvents.AddressSpace;
using System;

namespace DocExamples {
namespace _EasyAEClient { 

    class QueryEventCategories 
    { 
        public static void Main1()
        {
            var easyAEClient = new EasyAEClient();
            AECategoryElementCollection categoryElements = easyAEClient.QueryEventCategories("", "OPCLabs.KitEventServer.2");

            foreach (AECategoryElement categoryElement in categoryElements)
            {
                Debug.Assert(categoryElement != null);
                Console.WriteLine("CategoryElements[\"{0}\"].Description: {1}", categoryElement.CategoryId, categoryElement.Description);
            }
        }
	} 

}}
#endregion
// ReSharper restore CheckNamespace
