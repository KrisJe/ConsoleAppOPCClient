// $Header: $
// Copyright (c) CODE Consulting and Development, s.r.o., Plzen. All rights reserved.

// ReSharper disable CheckNamespace
// ReSharper disable InconsistentNaming
#region Example

// Hooking up events and receiving OPC item changes.

using OpcLabs.EasyOpc.DataAccess;
using System;
using System.Threading;
using OpcLabs.EasyOpc.DataAccess.OperationModel;

namespace DocExamples
{
    namespace _EasyDAClient
    {
        partial class SubscribeItem
        {
            public static void Main1()
            {
                using (var client = new EasyDAClient())
                {
                    var eventHandler = new EasyDAItemChangedEventHandler(client_ItemChanged);
                    client.ItemChanged += eventHandler;

                    Console.WriteLine("Subscribing item...");
                    client.SubscribeItem("", "OPCLabs.KitServer.2", "Demo.Ramp", 200);
                    Thread.Sleep(30 * 1000);
                    client.UnsubscribeAllItems();
                    client.ItemChanged -= eventHandler;
                }
            }

            static void client_ItemChanged(object sender, EasyDAItemChangedEventArgs e)
            {
                if (e.Exception != null)
                    Console.WriteLine(e.Exception);
                else
                    Console.WriteLine(e.Vtq);
            }
        }
    }
}
#endregion
// ReSharper restore CheckNamespace
// ReSharper restore InconsistentNaming
