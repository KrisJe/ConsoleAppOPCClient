// $Header: $
// Copyright (c) CODE Consulting and Development, s.r.o., Plzen. All rights reserved.

// ReSharper disable CheckNamespace
// ReSharper disable PossibleNullReferenceException
#region Example 
// This example shows how to obtain a data type of an OPC item.
using System;
using OpcLabs.BaseLib.ComInterop;
using OpcLabs.EasyOpc.DataAccess;   

namespace DocExamples
{
    namespace _EasyDAClient
    {
        partial class GetPropertyValue
        {
            public static void DataType()
            {
                var easyDAClient = new EasyDAClient();

                // Get the value of DataType property; it is a 16-bit signed integer
                var dataType = (short)easyDAClient.GetPropertyValue("", "AutoJet.ACPFileServerDA.1", "Simulation.Random",
                    DAPropertyIds.DataType);
                // Convert the data type to VarType
                var varType = (VarType)dataType;

                // Display the obtained data type
                Console.WriteLine("DataType: {0}", dataType);   // Display data type as numerical value
                Console.WriteLine("VarType: {0}", varType);     // Display data type symbolically

                // Code below illustrates how decisions can be made based on type
                switch (varType.InternalValue)
                {
                    case VarTypes.R8:
                        Console.WriteLine("The data type is VarTypes.R8, as we expected.");
                        break;

                    // other cases may come here ...

                    default:
                        Console.WriteLine("The data type is not as we expected!");
                        break;
                }
            }
        }
    }
}
#endregion
// ReSharper restore PossibleNullReferenceException
// ReSharper restore CheckNamespace
