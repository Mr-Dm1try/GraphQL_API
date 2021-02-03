using GraphQL_API.DatabaseHelper.Adapters;
using GraphQL_API.Server.DataModel;
using GraphQL_API.Server.Resolvers;

using HotChocolate.Types;

namespace GraphQL_API.Server.Schema
{
    public class DeviceType : ObjectType<SubscriberDevice>
    {
        protected override void Configure(IObjectTypeDescriptor<SubscriberDevice> descriptor)
        {
            descriptor.Field(t => t.Number)
                .Resolver(ctx => DeviceResolvers.GetNumber(ctx, ctx.Parent<SubscriberDevice>(), ctx.Service<DeviceAdapter>()));

            descriptor.Field(t => t.CreationDate)
                .Resolver(ctx => DeviceResolvers.GetCreationDate(ctx, ctx.Parent<SubscriberDevice>(), ctx.Service<DeviceAdapter>()));

            descriptor.Field(t => t.TariffPlan)
                .Resolver(ctx => DeviceResolvers.GetTariffPlan(ctx, ctx.Parent<SubscriberDevice>(), ctx.Service<DeviceAdapter>()));

            descriptor.Field(t => t.IMSI)
                .Resolver(ctx => DeviceResolvers.GetIMSI(ctx, ctx.Parent<SubscriberDevice>(), ctx.Service<DeviceAdapter>()));

            descriptor.Field(t => t.AccountNumber)
                .Resolver(ctx => DeviceResolvers.GetAccountNumber(ctx, ctx.Parent<SubscriberDevice>(), ctx.Service<DeviceAdapter>()));
            
            descriptor.Field(t => t.Id)
                    .Resolver(ctx => DeviceResolvers.GetId(ctx, ctx.Parent<SubscriberDevice>(), ctx.Service<DeviceAdapter>()));
        }
    }
}
