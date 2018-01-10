// $Header: $
// Copyright (c) CODE Consulting and Development, s.r.o., Plzen. All rights reserved.

using OpcLabs.EasyOpc;
using OpcLabs.EasyOpc.DataAccess.OperationModel;
// ReSharper disable CheckNamespace
#region Example
// This example shows how to read 4 items from an OPC XML-DA server at once, and display their values, timestamps 
// and qualities.
using System;
using System.Diagnostics;
using OpcLabs.EasyOpc.DataAccess;

namespace DocExamples
{
    namespace _EasyDAClient
    {
        partial class ReadMultipleItems
        {
            public static void Xml()
            {
                var easyDAClient = new EasyDAClient();

                DAVtqResult[] vtqResults = easyDAClient.ReadMultipleItems(
                    new ServerDescriptor { UrlString = "http://opcxml.demo-this.com/XmlDaSampleServer/Service.asmx" },
                    new DAItemDescriptor[]
                    {
                        "Dynamic/Analog Types/Double", 
                        "Dynamic/Analog Types/Double[]", 
                        "Dynamic/Analog Types/Int", 
                        "SomeUnknownItem"
                    });

                for (int i = 0; i < vtqResults.Length; i++)
                {
                    Debug.Assert(vtqResults[i] != null);

                    if (vtqResults[i].Exception != null)
                    {
                        Console.WriteLine("vtqResults[{0}].Exception: {1}", i, vtqResults[i].Exception);
                        continue;
                    }
                    Console.WriteLine("vtqResults[{0}].Vtq: {1}", i, vtqResults[i].Vtq);
                }
            }
        }
    }
}
#endregion
// ReSharper restore CheckNamespace
