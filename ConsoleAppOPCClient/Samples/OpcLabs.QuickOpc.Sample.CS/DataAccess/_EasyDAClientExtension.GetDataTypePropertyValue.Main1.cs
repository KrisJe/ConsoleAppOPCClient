// $Header: $
// Copyright (c) CODE Consulting and Development, s.r.o., Plzen. All rights reserved.

// ReSharper disable CheckNamespace
#region Example 
// This example shows how to obtain a data type of an OPC item.
using System;
using OpcLabs.BaseLib.ComInterop;
using OpcLabs.EasyOpc.DataAccess;
using OpcLabs.EasyOpc.DataAccess.Extensions;

namespace DocExamples
{
    namespace _EasyDAClientExtension
    {
        class GetDataTypePropertyValue
        {
            public static void Main1()
            {
                var easyDAClient = new EasyDAClient();

                // Get the DataType property value, already converted to VarType
                VarType varType = easyDAClient.GetDataTypePropertyValue("", "AutoJet.ACPFileServerDA.1", "Simulation.Random");

                // Display the obtained data type
                Console.WriteLine("VarType: {0}", varType); // Display data type symbolically
            }
        }
    }
}
#endregion
// ReSharper restore CheckNamespace
