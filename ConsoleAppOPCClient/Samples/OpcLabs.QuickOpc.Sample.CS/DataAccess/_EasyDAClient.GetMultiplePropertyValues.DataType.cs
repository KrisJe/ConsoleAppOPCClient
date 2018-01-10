// $Header: $
// Copyright (c) CODE Consulting and Development, s.r.o., Plzen. All rights reserved.

// ReSharper disable CheckNamespace
// ReSharper disable AssignNullToNotNullAttribute
// ReSharper disable PossibleNullReferenceException
#region Example
// This example shows how to obtain a data type of all OPC items under a branch.
using System;
using System.Linq;
using OpcLabs.BaseLib.ComInterop;
using OpcLabs.BaseLib.OperationModel;
using OpcLabs.EasyOpc;
using OpcLabs.EasyOpc.DataAccess;
using OpcLabs.EasyOpc.DataAccess.AddressSpace;

namespace DocExamples
{
    namespace _EasyDAClient
    {
        class GetMultiplePropertyValues
        {
            public static void DataType()
            {
                var easyDAClient = new EasyDAClient();
                ServerDescriptor serverDescriptor = "OPCLabs.KitServer.2";

                // Browse for all leaves under the "Simulation" branch
                DANodeElementCollection nodeElementCollection = easyDAClient.BrowseLeaves(serverDescriptor, "Simulation");

                // Create list of node descriptors, one for each leaf obtained
                DANodeDescriptor[] nodeDescriptorArray = nodeElementCollection
                    .Where(element => !element.IsHint)  // filter out hint leafs that do not represent real OPC items (rare)
                    .Select(element => new DANodeDescriptor(element))
                    .ToArray();

                // Get the value of DataType property; it is a 16-bit signed integer
                ValueResult[] valueResultArray = easyDAClient.GetMultiplePropertyValues(serverDescriptor, 
                    nodeDescriptorArray, DAPropertyIds.DataType);

                for (int i = 0; i < valueResultArray.Length; i++)
                {
                    DANodeDescriptor nodeDescriptor = nodeDescriptorArray[i];

                    // Check if there has been an error getting the property value
                    ValueResult valueResult = valueResultArray[i];
                    if (valueResult.Exception != null)
                    {
                        Console.WriteLine("{0}: *** {1}", nodeDescriptor.NodeId, valueResult.Exception.Message);
                        continue;
                    }

                    // Convert the data type to VarType
                    var varType = (VarType)(short)valueResult.Value;

                    // Display the obtained data type
                    Console.WriteLine("{0}: {1}", nodeDescriptor.ItemId, varType);
                }
            }
        }
    }
}
#endregion
// ReSharper restore PossibleNullReferenceException
// ReSharper restore AssignNullToNotNullAttribute
// ReSharper restore CheckNamespace
