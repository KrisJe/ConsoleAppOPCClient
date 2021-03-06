﻿// $Header: $
// Copyright (c) CODE Consulting and Development, s.r.o., Plzen. All rights reserved.

// ReSharper disable CheckNamespace
// ReSharper disable AssignNullToNotNullAttribute
#region Example
// This example for OPC DA type-less mapping shows how to define a mapping and perform subscribe and unsubscribe operations.
using System;
using System.Threading;
using OpcLabs.BaseLib.ComponentModel.Linking;
using OpcLabs.EasyOpc.DataAccess;
using OpcLabs.EasyOpc.DataAccess.LiveMapping;

namespace DocExamples
{
    namespace _DAClientMapper
    {
        partial class DefineMapping
        {
            class MyClassSubscribe
            {
                public Double Value
                {
                    set
                    {
                        // Display the incoming value
                        Console.WriteLine(value);
                    }
                }
            }

            public static void Subscribe()
            {
                var mapper = new DAClientMapper();
                var target = new MyClassSubscribe();

                // Define a type-less mapping.

                mapper.DefineMapping(
                     new DAClientItemSource("AutoJet.ACPFileServerDA.1", "Demo.Ramp", 1000, DADataSource.Cache),
                     new DAClientItemMapping(typeof(Double)),
                     new ObjectMemberLinkingTarget(target.GetType(), target, "Value"));

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
