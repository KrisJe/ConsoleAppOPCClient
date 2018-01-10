// $Header: $
// Copyright (c) CODE Consulting and Development, s.r.o., Plzen. All rights reserved.

// ReSharper disable CheckNamespace
// ReSharper disable AssignNullToNotNullAttribute
#region Example
// This example for OPC DA type-less mapping shows how to define a mapping and perform a read operation.
using System;
using OpcLabs.BaseLib.ComponentModel.Linking;
using OpcLabs.EasyOpc.DataAccess;
using OpcLabs.EasyOpc.DataAccess.LiveMapping;

namespace DocExamples
{
    namespace _DAClientMapper
    {
        partial class DefineMapping
        {
            class MyClass
            {
                public object Value { get; set; }
            }

            public static void Main1()
            {
                #region Example-DefineAndRead
                var mapper = new DAClientMapper();
                var target = new MyClass();

                // Define a type-less mapping.

                mapper.DefineMapping(
                     new DAClientItemSource("AutoJet.ACPFileServerDA.1", "Cttmt2008.Parameter.Manual AI2", DADataSource.Cache),
                     new DAClientItemMapping(typeof(Int32)),
                     new ObjectMemberLinkingTarget(target.GetType(), target, "Value"));

                // Perform a read operation.
                mapper.Read();
                #endregion

                // Display the result.
                Console.WriteLine(target.Value);
            }
        }
    }
}
#endregion
// ReSharper restore AssignNullToNotNullAttribute
// ReSharper restore CheckNamespace
