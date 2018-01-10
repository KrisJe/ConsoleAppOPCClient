// $Header: $
// Copyright (c) CODE Consulting and Development, s.r.o., Plzen. All rights reserved.

// ReSharper disable CheckNamespace
#region Example
// This example shows information available about OPC event category.
using System.Diagnostics;
using OpcLabs.EasyOpc.AlarmsAndEvents;
using OpcLabs.EasyOpc.AlarmsAndEvents.AddressSpace;
using System;

namespace DocExamples {
namespace _AECategoryElement { 

    class Properties 
    { 
        public static void Main1()
        {
            var easyAEClient = new EasyAEClient();
            AECategoryElementCollection categoryElements = easyAEClient.QueryEventCategories("", "AutoJet.ACPFileServerAE.1");

            foreach (AECategoryElement categoryElement in categoryElements)
            {
                Debug.Assert(categoryElement != null);
                Debug.Assert(categoryElement.AttributeElements.Keys != null);
                Debug.Assert(categoryElement.ConditionElements.Keys != null);

                Console.WriteLine("Information about category {0}:", categoryElement);
                Console.WriteLine("    .CategoryId: {0}", categoryElement.CategoryId);
                Console.WriteLine("    .Description: {0}", categoryElement.Description);
                Console.WriteLine("    .ConditionElements:");
                foreach (string conditionKey in categoryElement.ConditionElements.Keys)
                    Console.WriteLine("        {0}", conditionKey);
                Console.WriteLine("    .AttributeElements:");
                foreach (long attributeKey in categoryElement.AttributeElements.Keys)
                    Console.WriteLine("        {0}", attributeKey);
            }
        }
    } 

}}
#endregion
// ReSharper restore CheckNamespace
