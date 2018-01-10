// $Header: $
// Copyright (c) CODE Consulting and Development, s.r.o., Plzen. All rights reserved.

// ReSharper disable CheckNamespace
#region Example
// This example shows how to enumerate all event conditions associated with the specified event source.
using System.Diagnostics;
using OpcLabs.EasyOpc.AlarmsAndEvents;
using OpcLabs.EasyOpc.AlarmsAndEvents.AddressSpace;
using System;

namespace DocExamples {
namespace _EasyAEClient { 

    class QuerySourceConditions 
    { 
        public static void Main1()
        {
            var easyAEClient = new EasyAEClient();
            AEConditionElementCollection conditionElements = easyAEClient.QuerySourceConditions(
                "", "OPCLabs.KitEventServer.2", "Simulation.ConditionState1");

            foreach (AEConditionElement conditionElement in conditionElements)
            {
                Debug.Assert(conditionElement != null);
                Console.WriteLine("ConditionElements[\"{0}\"]: {1} subcondition(s)", 
                    conditionElement.Name, conditionElement.SubconditionNames.Length);
            }
        }
    } 

}}
#endregion
// ReSharper restore CheckNamespace
