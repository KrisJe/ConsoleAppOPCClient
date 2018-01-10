// $Header: $
// Copyright (c) CODE Consulting and Development, s.r.o., Plzen. All rights reserved.

// ReSharper disable CheckNamespace
#region Example
// This example shows how to obtain all areas directly under the root (denoted by empty string for the parent).
using OpcLabs.EasyOpc.AlarmsAndEvents;
using OpcLabs.EasyOpc.AlarmsAndEvents.AddressSpace;
using System;
using System.Diagnostics;

namespace DocExamples {
namespace _EasyAEClient { 

    class BrowseAreas 
    { 
        public static void Main1()
        {
            var easyAEClient = new EasyAEClient();
            AENodeElementCollection nodeElements = easyAEClient.BrowseAreas("", "AutoJet.ACPFileServerAE.1", "");

            foreach (AENodeElement nodeElement in nodeElements)
            {
                Debug.Assert(nodeElement != null);

                Console.WriteLine("nodeElements[\"{0}\"]:", nodeElement.Name);
                Console.WriteLine("    .QualifiedName: {0}", nodeElement.QualifiedName);
            }
        }
    } 

}}
#endregion
// ReSharper restore CheckNamespace
