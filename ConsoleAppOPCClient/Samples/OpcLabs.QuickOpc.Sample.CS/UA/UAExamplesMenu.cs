// $Header: $
// Copyright (c) CODE Consulting and Development, s.r.o., Plzen. All rights reserved.

using System;
using System.Collections.Generic;
using OpcLabs.BaseLib.Console;

namespace UADocExamples
{
    static class UAExamplesMenu
    {
        public static void Main1()
        {
            var actionArray = new Action[] {
                // ReSharper disable RedundantCommaInArrayInitializer
                _EasyUAClient.Acknowledge.Main1,
                _EasyUAClient.BrowseDataNodes.Overload1,
                _EasyUAClient.BrowseEventSources.Overload2,
                _EasyUAClient.BrowseNodes.Main1,
                _EasyUAClient.BrowseNotifiers.Overload2,
                _EasyUAClient.BrowseObjects.Overload2,
                _EasyUAClient.BrowseProperties.Overload2,
                _EasyUAClient.BrowseDataVariables.Overload2,
                _EasyUAClient.ChangeMonitoredItemSubscription.Overload1,
                _EasyUAClient.ChangeMultipleMonitoredItemSubscriptions.Overload2,
                _EasyUAClient.DiscoverServers.Overload1,
                _EasyUAClient.DiscoverServersOnNetwork.Main1,
                _EasyUAClient.GetMonitoredItemArguments.Main1,
                _EasyUAClient.GetMonitoredItemArgumentsDictionary.Main1,
                _EasyUAClient.PullDataChangeNotification.Main1,
                _EasyUAClient.PullEventNotification.Main1,
                _EasyUAClient.Read.Main1,
                _EasyUAClient.ReadMultiple.Main1,
                _EasyUAClient.ReadMultipleValues.Main1,
                _EasyUAClient.ReadValue.Overload1,
                _EasyUAClient.SubscribeDataChange.CallbackLambda,
                _EasyUAClient.SubscribeDataChange.Overload1,
                _EasyUAClient.SubscribeEvent.CallbackLambda,
                _EasyUAClient.SubscribeEvent.Overload1,
                _EasyUAClient.SubscribeMultipleMonitoredItems.Main1,
                _EasyUAClient.SubscribeMultipleMonitoredItems.Events,
                _EasyUAClient.UnsubscribeAllMonitoredItems.Main1,
                _EasyUAClient.UnsubscribeMonitoredItem.Main1,
                _EasyUAClient.UnsubscribeMultipleMonitoredItems.Main1,
                _EasyUAClient.Write.Main1,
                _EasyUAClient.WriteMultiple.TestSuccess,
                _EasyUAClient.WriteMultipleValues.Main1,
                _EasyUAClient.WriteMultipleValues.TestSuccess,
                _EasyUAClient.WriteValue.Main1,

                _UAClientMapper.DefineMapping.Main1,

                _UAEventData.BaseEvent.Main1,
                _UAEventData.FieldResults.Main1,

                _UAEventFilter.SelectClauses.Main1,
                _UAEventFilter.WhereClause.Main1,

                _UAIndexRangeList.Usage.ReadValue,

                _UANodeId._Construction.Main1,
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
