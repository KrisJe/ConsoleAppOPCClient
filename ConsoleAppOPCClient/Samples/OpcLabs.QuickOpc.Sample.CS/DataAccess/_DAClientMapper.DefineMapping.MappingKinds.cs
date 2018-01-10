﻿// $Header: $
// Copyright (c) CODE Consulting and Development, s.r.o., Plzen. All rights reserved.

// ReSharper disable CheckNamespace
// ReSharper disable AssignNullToNotNullAttribute
#region Example
// This example for OPC DA type-less mapping shows how to define mappings of various kinds, and perform subscribe and 
// unsubscribe operations.
using System;
using System.Threading;
using OpcLabs.BaseLib.ComponentModel.Linking;
using OpcLabs.EasyOpc.DataAccess;
using OpcLabs.EasyOpc.DataAccess.Generic;
using OpcLabs.EasyOpc.DataAccess.LiveMapping;

namespace DocExamples
{
    namespace _DAClientMapper
    {
        partial class DefineMapping
        {
            class MyClassMappingKinds
            {
                public Double CurrentValue
                {
                    set
                    {
                        // Display the incoming value
                        Console.WriteLine("Value: {0}", value);
                    }
                }

                public DAVtq<Double> CurrentVtq
                {
                    set
                    {
                        // Display the incoming Vtq
                        Console.WriteLine("Vtq: {0}", value);
                    }
                }

                public Exception CurrentException
                {
                    set
                    {
                        // Display the incoming exception
                        Console.WriteLine("Exception: {0}", value);
                    }
                }

                public DAVtqResult<Double> CurrentResult
                {
                    set
                    {
                        // Display the incoming result
                        Console.WriteLine("Result: {0}", value);
                    }
                }
            }

            public static void MappingKinds()
            {
                var mapper = new DAClientMapper();
                var target = new MyClassMappingKinds();

                // Define several type-less mappings for the same source, with different mapping kinds.

                Type targetType = target.GetType();
                var source = new DAClientItemSource("OPCLabs.KitServer.2", "Demo.Ramp", 1000, DADataSource.Cache);

                mapper.DefineMapping(
                     source,
                     new DAClientItemMapping(typeof(Double)),
                     new ObjectMemberLinkingTarget(targetType, target, "CurrentValue"));

                mapper.DefineMapping(
                     source,
                     new DAClientItemMapping(typeof(Double), DAItemMappingKind.Vtq),
                     new ObjectMemberLinkingTarget(targetType, target, "CurrentVtq"));

                mapper.DefineMapping(
                     source,
                     new DAClientItemMapping(typeof(Double), DAItemMappingKind.Exception),
                     new ObjectMemberLinkingTarget(targetType, target, "CurrentException"));

                mapper.DefineMapping(
                     source,
                     new DAClientItemMapping(typeof(Double), DAItemMappingKind.Result),
                     new ObjectMemberLinkingTarget(targetType, target, "CurrentResult"));

                // Perform a subscribe operation.
                mapper.Subscribe(true);

                Thread.Sleep(30*1000);

                // Perform an unsubscribe operation.
                mapper.Subscribe(false);
            }
        }
    }
}
#endregion
// ReSharper restore AssignNullToNotNullAttribute
// ReSharper restore CheckNamespace
