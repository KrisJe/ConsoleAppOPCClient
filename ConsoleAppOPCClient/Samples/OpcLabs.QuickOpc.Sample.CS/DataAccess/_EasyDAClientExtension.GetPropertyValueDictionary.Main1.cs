// $Header: $
// Copyright (c) CODE Consulting and Development, s.r.o., Plzen. All rights reserved.
// ReSharper disable CheckNamespace
// ReSharper disable PossibleNullReferenceException
#region Example 
// This example shows how to obtain a dictionary of OPC property values for an OPC item, and extract property values.
using System;
using OpcLabs.EasyOpc.DataAccess;
using OpcLabs.EasyOpc.DataAccess.Extensions;

namespace DocExamples
{
    namespace _EasyDAClientExtension
    {
        class GetPropertyValueDictionary
        {
            public static void Main1()
            {
                var easyDAClient = new EasyDAClient();

                // Get dictionary of property values, for all well-known properties
                DAPropertyValueDictionary propertyValueDictionary = 
                    easyDAClient.GetPropertyValueDictionary("", "OPCLabs.KitServer.2", "Simulation.Random");

                // Display some of the obtained property values
                // The production code should also check for the .Exception first, before getting .Value
                Console.WriteLine("propertyValueDictionary[DAPropertyId.AccessRights].Value: {0}",
                    propertyValueDictionary[DAPropertyIds.AccessRights].Value);
                Console.WriteLine("propertyValueDictionary[DAPropertyId.DataType].Value: {0}",
                    propertyValueDictionary[DAPropertyIds.DataType].Value);
                Console.WriteLine("propertyValueDictionary[DAPropertyId.Timestamp].Value: {0}",
                    propertyValueDictionary[DAPropertyIds.Timestamp].Value);
            }
        }
    }
}
#endregion
// ReSharper restore CheckNamespace
// ReSharper restore PossibleNullReferenceException
