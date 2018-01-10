// $Header: $
// Copyright (c) CODE Consulting and Development, s.r.o., Plzen. All rights reserved.

// ReSharper disable CheckNamespace
// ReSharper disable AssignNullToNotNullAttribute
#region Example
// This example shows how to recursively browse the nodes in the OPC address space.
using System;
using System.IO;
using System.Diagnostics;
using OpcLabs.EasyOpc;
using OpcLabs.EasyOpc.DataAccess;
using OpcLabs.EasyOpc.DataAccess.AddressSpace;





namespace DocExamples
{
    namespace _EasyDAClient
    {
        partial class BrowseNodes
        {

            

            public static void Recursive()
            {
                var stopwatch = new Stopwatch();
                stopwatch.Start();

                var easyDAClient = new EasyDAClient();
                _branchCount = 0;
                _leafCount = 0;
                BrowseFromNode(easyDAClient, "AutoJet.ACPFileServerDA.1", "");

                stopwatch.Stop();
                Console.WriteLine("Browsing has taken (milliseconds): {0}", stopwatch.ElapsedMilliseconds);
                Console.WriteLine("Branch count: {0}", _branchCount);
                Console.WriteLine("Leaf count: {0}", _leafCount);
            }

            private static void BrowseFromNode(
                EasyDAClient client,
                ServerDescriptor serverDescriptor,
                DANodeDescriptor parentNodeDescriptor)
            {
                Debug.Assert(client != null);
                Debug.Assert(serverDescriptor != null);
                Debug.Assert(parentNodeDescriptor != null);

                Boolean append = false;

                if (parentNodeDescriptor.ToString() == "") append = false;
                else append = true;


                // Obtain all node elements under parentNodeDescriptor
                var browseParameters = new DABrowseParameters();    // no filtering whatsoever
                DANodeElementCollection nodeElementCollection = 
                    client.BrowseNodes(serverDescriptor, parentNodeDescriptor, browseParameters);
                // Remark: that BrowseNodes(...) may also throw OpcException; a production code should contain handling for 
                // it, here omitted for brevity.

                foreach (DANodeElement nodeElement in nodeElementCollection)
                {
                    Debug.Assert(nodeElement != null);

                    Console.WriteLine(nodeElement);
                    using (StreamWriter opcfile = new System.IO.StreamWriter(@"C:\Users\kiekensk\source\repos\ConsoleAppOPCClient\ConsoleAppOPCClient\dump\Cttmt2008 OPC dump.txt", append))
                    {
                        opcfile.WriteLine(nodeElement);
                    }


                    // If the node is a branch, browse recursively into it.
                    if (nodeElement.IsBranch)
                    {
                        _branchCount++;
                        BrowseFromNode(client, serverDescriptor, nodeElement);
                    }
                    else
                    {
                        _leafCount++;
                    }
                }
            }

            private static int _branchCount;
            private static int _leafCount;
        }
    }
}
#endregion
// ReSharper restore AssignNullToNotNullAttribute
// ReSharper restore CheckNamespace
