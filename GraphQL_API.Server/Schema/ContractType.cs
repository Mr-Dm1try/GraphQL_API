using GraphQL_API.DatabaseHelper.Adapters;
using GraphQL_API.Server.DataModel;
using GraphQL_API.Server.Resolvers;

using HotChocolate.Types;

namespace GraphQL_API.Server.Schema
{
    public class ContractType : ObjectType<Contract>
    {
        protected override void Configure(IObjectTypeDescriptor<Contract> descriptor)
        {
            descriptor.Field(t => t.Number)
                .Resolver(ctx => ContractResolvers.GetNumber(ctx, ctx.Parent<Contract>(), ctx.Service<ContractAdapter>()));

            descriptor.Field(t => t.CreationDate)
                .Resolver(ctx => ContractResolvers.GetCreationDate(ctx, ctx.Parent<Contract>(), ctx.Service<ContractAdapter>()));

            descriptor.Field(t => t.Accounts)
                .Resolver(ctx => ContractResolvers.GetAccounts(ctx, ctx.Parent<Contract>(), ctx.Service<ContractAdapter>()));

            descriptor.Field(t => t.SubscriberId)
                .Resolver(ctx => ContractResolvers.GetSubscriberId(ctx, ctx.Parent<Contract>(), ctx.Service<ContractAdapter>()));
            
            descriptor.Field(t => t.Id)
                    .Resolver(ctx => ContractResolvers.GetId(ctx, ctx.Parent<Contract>(), ctx.Service<ContractAdapter>()));
        }
    }
}
