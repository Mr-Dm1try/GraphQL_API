using HotChocolate.Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GraphQL_API.Server.Schema
{
    public class QueryType : ObjectType<Query>
    {
        protected override void Configure(IObjectTypeDescriptor<Query> descriptor)
        {
            descriptor.Field(t => t.GetAccountsByIds(default))
                .Argument("ids", a => a.Type<NonNullType<ListType<IntType>>>());

            descriptor.Field(t => t.GetAccountsByNumbers(default))
                .Argument("numbers", a => a.Type<NonNullType<ListType<LongType>>>());

            descriptor.Field(t => t.GetAllSubscribers(default));

            descriptor.Field(t => t.GetContractsByIds(default))
                .Argument("ids", a => a.Type<NonNullType<ListType<IntType>>>());

            descriptor.Field(t => t.GetContractsByNumbers(default))
                .Argument("numbers", a => a.Type<NonNullType<ListType<LongType>>>());

            descriptor.Field(t => t.GetDevicesByIds(default))
                .Argument("ids", a => a.Type<NonNullType<ListType<IntType>>>());

            descriptor.Field(t => t.GetDevicesByNumbers(default))
                .Argument("numbers", a => a.Type<NonNullType<ListType<LongType>>>());

            descriptor.Field(t => t.GetSubscribersByIds(default, default))
                .Argument("ids", a => a.Type<NonNullType<ListType<IntType>>>());
        }
    }
}
