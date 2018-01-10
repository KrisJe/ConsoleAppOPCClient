// $Header: $
// Copyright (c) CODE Consulting and Development, s.r.o., Plzen. All rights reserved.
// ReSharper disable CheckNamespace
#region Example
// This example shows how to obtain all ProgIDs of all OPC Alarms and Events servers on the local machine.
using System.Diagnostics;
using OpcLabs.EasyOpc;
using OpcLabs.EasyOpc.AlarmsAndEvents;
using System;

namespace DocExamples {
namespace _EasyAEClient { 

    class BrowseServers 
    { 
        public static void Main1()
        {
            var easyAEClient = new EasyAEClient();
            ServerElementCollection serverElements = easyAEClient.BrowseServers("");

            foreach (ServerElement serverElement in serverElements)
            {
                Debug.Assert(serverElement != null);
                Console.WriteLine("serverElements[\"{0}\"].ProgId: {1}", serverElement.Clsid, serverElement.ProgId);
            }
        }
    } 

}}
#endregion
// ReSharper restore CheckNamespace
