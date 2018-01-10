// $Header: $
// Copyright (c) CODE Consulting and Development, s.r.o., Plzen. All rights reserved.
// ReSharper disable CheckNamespace
#region Example
// This example shows how to read 4 items at once, and display their values, timestamps and qualities.
using System;
using System.Diagnostics;
using OpcLabs.EasyOpc.DataAccess;
using OpcLabs.EasyOpc.DataAccess.OperationModel;

using System.Threading;

namespace DocExamples
{
    namespace _EasyDAClient
    {
        partial class ReadMultipleItems
        {
            public static void Main1()
            {
                var easyDAClient = new EasyDAClient();
                DAItemDescriptor[] dd = new DAItemDescriptor[]{ "Cttmt2008.Parameter.Manual AI1.value", "Cttmt2008.Parameter.Manual AI2.value", "Cttmt2008.Parameter.Manual AI3.value" };


                while (true)
                {
                    DAVtqResult[] vtqResults = easyDAClient.ReadMultipleItems("AutoJet.ACPFileServerDA.1", dd);

                    string[] AI = { "", "", "" };

                    for (int i = 0; i < vtqResults.Length; i++)
                    {
                        Debug.Assert(vtqResults[i] != null);
                        //Console.WriteLine("vtqResult[{0}].Vtq: {1}", i, vtqResults[i].Vtq, dd[i]);

                        String[] somedata = vtqResults[i].Vtq.ToString().Split(new char[] { ';', '@', '}', ' ' });


                        AI[i] = somedata[0];
                        //Console.WriteLine("{0} = {1}    ({2})", dd[i], somedata[0], somedata[4]);
                    }
                    Console.WriteLine("AI1={0}  AI2={1}  AI3={2}", AI[0], AI[1], AI[2]);


                    Thread.Sleep(100);
                }
            }
        }
    }
}
#endregion
// ReSharper restore CheckNamespace
