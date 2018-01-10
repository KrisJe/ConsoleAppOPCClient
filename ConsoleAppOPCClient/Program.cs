using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Threading;


//using Opc.Da;
//using Server = Opc.Da.Server;
//using Factory = OpcCom.Factory;

//using Opc.Ua.Client;


//*** OPCLabs QuickOpc ***
using DocExamples.AlarmsAndEvents;
using DocExamples.DataAccess;
using UADocExamples;




using OpcLabs.EasyOpc.DataAccess;
using OpcLabs.EasyOpc.DataAccess.AddressSpace;
using OpcLabs.EasyOpc.OperationModel;

namespace ConsoleAppOPCClient
{
    class Program
    {
        static void Main(string[] args)
        {
            //AEExamplesMenu.Main1(); //Faults

            DAExamplesMenu.Main1(); //Data

            // UAExamplesMenu.Main1();


            return;

            EasyDAClient Client = new EasyDAClient();
            Client.InstanceParameters.Timeouts.ReadItem = 1000;

            int value_age = 0;
            const string ServerClass = "AutoJet.ACPFileServerDA.1";
            const string nodeElement = "Cttmt2008.Parameter.Manual AI1.value";

            while (true)
            {
                try
                {
                    //object value = Client.ReadItemValue("", ServerClass, nodeElement);
                    object value = Client.ReadItemValue("", ServerClass, nodeElement, OpcLabs.BaseLib.ComInterop.VarTypes.Decimal);
                    Console.WriteLine("{0} = {1}", nodeElement, value);
                }
                catch (OpcException exception)
                {
                    Console.WriteLine("{0} not found!", nodeElement);
                }

                Thread.Sleep(100);
            }

            Console.ReadLine();


        }
    }
}
