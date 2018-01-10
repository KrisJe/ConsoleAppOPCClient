// $Header: $
// Copyright (c) CODE Consulting and Development, s.r.o., Plzen. All rights reserved.
// ReSharper disable CheckNamespace
#region Example
// This example shows how to obtain current state information for the condition instance corresponding to a Source and 
// certain ConditionName.

using OpcLabs.EasyOpc.AlarmsAndEvents;
using System;

namespace DocExamples {
namespace _EasyAEClient { 

    class GetConditionState 
    { 
        public static void Main1()
        {
            var easyAEClient = new EasyAEClient();
            AEConditionState conditionState = easyAEClient.GetConditionState("", "OPCLabs.KitEventServer.2", 
                "Simulation.ConditionState1", "Simulated");

            Console.WriteLine("ConditionState:");
            Console.WriteLine("    .ActiveSubcondition: {0}", conditionState.ActiveSubcondition);
            Console.WriteLine("    .Enabled: {0}", conditionState.Enabled);
            Console.WriteLine("    .Active: {0}", conditionState.Active);
            Console.WriteLine("    .Acknowledged: {0}", conditionState.Acknowledged);
            Console.WriteLine("    .Quality: {0}", conditionState.Quality);
            // Remark: IAEConditionState has many more properties
        }
	} 

}}
#endregion
// ReSharper restore CheckNamespace
