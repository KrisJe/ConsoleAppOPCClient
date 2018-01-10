// $Header: $
// Copyright (c) CODE Consulting and Development, s.r.o., Plzen. All rights reserved.

// ReSharper disable CheckNamespace
#region Example
// This example shows information available about OPC event attribute.
using System.Diagnostics;
using OpcLabs.EasyOpc.AlarmsAndEvents;
using OpcLabs.EasyOpc.AlarmsAndEvents.AddressSpace;
using System;

namespace DocExamples {
namespace _AEAttributeElement {

    class Properties 
    { 
        public static void Main1()
        {
            var easyAEClient = new EasyAEClient();
            AECategoryElementCollection categoryElements = easyAEClient.QueryEventCategories("", "AutoJet.ACPFileServerAE.1");

            foreach (AECategoryElement categoryElement in categoryElements)
            {
                Debug.Assert(categoryElement != null);

                Console.WriteLine("Category {0}:", categoryElement);
                foreach (AEAttributeElement attributeElement in categoryElement.AttributeElements)
                {
                    Debug.Assert(attributeElement != null);

                    Console.WriteLine("    Information about attribute {0}:", attributeElement);
                    Console.WriteLine("        .AttributeId: {0}", attributeElement.AttributeId);
                    Console.WriteLine("        .Description: {0}", attributeElement.Description);
                    Console.WriteLine("        .DataType: {0}", attributeElement.DataType);
                }
            }
        }
	} 

}}
#endregion
// ReSharper restore CheckNamespace
