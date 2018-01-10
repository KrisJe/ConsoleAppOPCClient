// $Header: $ 
// Copyright (c) CODE Consulting and Development, s.r.o., Plzen. All rights reserved.
#region Example
// This example for OPC UA type-less mapping shows how to define a mapping and perform a read operation.
using System;
using System.Diagnostics;
using OpcLabs.BaseLib.ComponentModel.Linking;
using OpcLabs.BaseLib.Extensions;
using OpcLabs.EasyOpc.UA;
using OpcLabs.EasyOpc.UA.LiveMapping;

namespace UADocExamples
{
    namespace _UAClientMapper
    {
        class DefineMapping
        {
            class MyClass
            {
                public object Value { get; set; }
            }

            public static void Main1()
            {
#region Example-DefineAndRead
                var mapper = new UAClientMapper();
                var target = new MyClass();

                // Define a type-less mapping.

                var memberInfo = target.GetType().GetSingleMember("Value");
                Debug.Assert(memberInfo != null);

                mapper.DefineMapping(
                    new UAClientDataMappingSource(
                        "opc.tcp://opcua.demo-this.com:51210/UA/SampleServer",
                        "nsu=http://test.org/UA/Data/;i=10389",
                        UAAttributeId.Value,
                        UAIndexRangeList.Empty,
                        UAReadParameters.CacheMaximumAge),
                    new UAClientDataMapping(typeof(Int32)),
                    new ObjectMemberLinkingTarget(target.GetType(), target, memberInfo));

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
