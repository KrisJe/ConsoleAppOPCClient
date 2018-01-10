// $Header: $
// Copyright (c) CODE Consulting and Development, s.r.o., Plzen. All rights reserved.
using System;
using System.Collections.Generic;
using OpcLabs.BaseLib.Console;

namespace DocExamples.DataAccess
{
    static class DAExamplesMenu
    {
        public static void Main1()
        {
            var actionArray = new Action[] {
                // ReSharper disable RedundantCommaInArrayInitializer

                _DAClientMapper.DefineMapping.Main1,
                _DAClientMapper.DefineMapping.MappingKinds,
                _DAClientMapper.DefineMapping.Subscribe,

                _EasyDAClient.BrowseNodes.DataTypes,
                _EasyDAClient.BrowseNodes.Recursive,
                _EasyDAClient.BrowseNodes.RecursiveWithRead,
                _EasyDAClient.ChangeItemSubscription.PercentDeadband,
                _EasyDAClient.ChangeItemSubscription.Main1,
                _EasyDAClient.GetMultiplePropertyValues.DataType,
                _EasyDAClient.GetPropertyValue.DataType,
                _EasyDAClient.GetPropertyValue.Main1,
                _EasyDAClient.PullItemChanged.Main1,
                _EasyDAClient.ReadItem.BrowsePath,
                _EasyDAClient.ReadItem.DataTypes,
                _EasyDAClient.ReadItem.GetTypeCode,
                _EasyDAClient.ReadItem.Main1,
                _EasyDAClient.ReadItemValue.Main1,
                _EasyDAClient.ReadMultipleItems.Main1,
                _EasyDAClient.ReadMultipleItems.TimeMeasurements,
                _EasyDAClient.ReadMultipleItems.Xml,
                _EasyDAClient.SubscribeItem.CallbackLambda,
                _EasyDAClient.SubscribeItem.Main1,
                _EasyDAClient.SubscribeMultipleItems.DataTypes,
                _EasyDAClient.SubscribeMultipleItems.Main1,
                _EasyDAClient.SubscribeMultipleItems.ManyItems,
                _EasyDAClient.UnsubscribeItem.Main1,
                _EasyDAClient.WriteItemValue.Array,
                _EasyDAClient.WriteItemValue.Main1,
                _EasyDAClient.WriteMultipleItemValues.Main1,
                _EasyDAClient.WriteMultipleItemValues.TimeMeasurements,

                _EasyDAClientExtension.GetDataTypePropertyValue.Main1,
                _EasyDAClientExtension.GetItemPropertyRecord.Main1,
                _EasyDAClientExtension.GetPropertyValueDictionary.Main1,

                _EasyDAClientHoldPeriods.TopicWrite.Main1,

                // ReSharper restore RedundantCommaInArrayInitializer
            };

            var actionList = new List<Action>(actionArray);
            bool cont;
            do
            {
                Console.WriteLine();
                cont = ConsoleDialog.SelectAndPerformAction("Select action to perform", "Return", actionList);
                if (cont)
                {
                    Console.WriteLine("Press Enter to continue...");
                    Console.ReadLine();
                }
            }
            while (cont);
        }
    }
}
