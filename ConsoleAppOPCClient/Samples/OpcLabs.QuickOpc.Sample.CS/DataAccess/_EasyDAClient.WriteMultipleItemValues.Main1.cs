// $Header: $
// Copyright (c) CODE Consulting and Development, s.r.o., Plzen. All rights reserved.

// ReSharper disable CheckNamespace
#region Example

// Shows how to write into multiple OPC items using a single method call, and read multiple item values back.

using System;
using System.Diagnostics;
using OpcLabs.BaseLib.OperationModel;
using OpcLabs.EasyOpc.DataAccess;
using OpcLabs.EasyOpc.DataAccess.OperationModel;

namespace DocExamples
{
    namespace _EasyDAClient
    {
        partial class WriteMultipleItemValues
        {
            public static void Main1()
            {
                var client = new EasyDAClient();

                Console.WriteLine("Writing multiple item values...");
                OperationResult[] resultArray = client.WriteMultipleItemValues(
                    new[] { 
                    new DAItemValueArguments("", "OPCLabs.KitServer.2", "Simulation.Register_I2", 12345), 
                    new DAItemValueArguments("", "OPCLabs.KitServer.2", "Simulation.Register_R4", 234.56)
                });


                for (int i = 0; i < resultArray.Length; i++)
                {
                    Debug.Assert(resultArray[i] != null);
                    if (resultArray[i].Succeeded)
                        Console.WriteLine("Result {0}: success", i);
                    else
                    {
                        Debug.Assert(resultArray[i].Exception != null);
                        Console.WriteLine("Result {0}: {1}", i, resultArray[i].Exception.GetBaseException().Message);
                    }
                }
            }
        }
    }
}
#endregion
// ReSharper restore CheckNamespace
