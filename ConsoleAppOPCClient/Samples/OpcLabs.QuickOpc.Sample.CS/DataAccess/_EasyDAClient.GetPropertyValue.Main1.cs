// $Header: $
// Copyright (c) CODE Consulting and Development, s.r.o., Plzen. All rights reserved.
// ReSharper disable CheckNamespace
#region Example 
// This example shows how to get a value of a single OPC property.
//
// Note that some properties may not have a useful value initially (e.g. until the item is activated in a group), which also the
// case with Timestamp property as implemented by the demo server. This behavior is server-dependent, and normal. You can run 
// IEasyDAClient.ReadItemValue.Main.vbs shortly before this example, in order to obtain better property values. Your code may 
// also subscribe to the item in order to assure that it remains active.

using System;
using OpcLabs.EasyOpc.DataAccess;

namespace DocExamples
{
    namespace _EasyDAClient
    {
        partial class GetPropertyValue
        {
            public static void Main1()
            {
                var easyDAClient = new EasyDAClient();

                object value = easyDAClient.GetPropertyValue("", "OPCLabs.KitServer.2", "Simulation.Random", 
                    DAPropertyIds.Timestamp);

                Console.WriteLine(value);
            }
        }
    }
}
#endregion
// ReSharper restore CheckNamespace
