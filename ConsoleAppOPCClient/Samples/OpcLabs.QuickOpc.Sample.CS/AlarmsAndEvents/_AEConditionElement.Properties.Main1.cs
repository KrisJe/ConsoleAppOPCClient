// $Header: $
// Copyright (c) CODE Consulting and Development, s.r.o., Plzen. All rights reserved.

// ReSharper disable CheckNamespace
#region Example
// This example shows information available about OPC event condition.
using System.Diagnostics;
using JetBrains.Annotations;
using OpcLabs.EasyOpc.AlarmsAndEvents;
using OpcLabs.EasyOpc.AlarmsAndEvents.AddressSpace;
using System;
using System.Collections.Generic;

namespace DocExamples {
namespace _AEConditionElement { 

    class Properties 
    {
        static void DumpSubconditionNames([NotNull] IEnumerable<string> subconditionNames)
        {
            foreach (string name in subconditionNames) Console.WriteLine("            {0}", name);
        }

        public static void Main1()
        {
            var easyAEClient = new EasyAEClient();
            AECategoryElementCollection categoryElements = easyAEClient.QueryEventCategories("", "AutoJet.ACPFileServerAE.1");

            foreach (AECategoryElement categoryElement in categoryElements)
            {
                Debug.Assert(categoryElement != null);

                Console.WriteLine("Category {0}:", categoryElement);
                foreach (AEConditionElement conditionElement in categoryElement.ConditionElements)
                {
                    Debug.Assert(conditionElement != null);

                    Console.WriteLine("    Information about condition \"{0}\":", conditionElement);
                    Console.WriteLine("        .Name: {0}", conditionElement.Name);
                    Console.WriteLine("        .SubconditionNames:");
                    DumpSubconditionNames(conditionElement.SubconditionNames);
                }
            }
        }
    } 

}}
#endregion
// ReSharper restore CheckNamespace
