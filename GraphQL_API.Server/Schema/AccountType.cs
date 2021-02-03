using GraphQL_API.DatabaseHelper.Adapters;
using GraphQL_API.Server.DataModel;
using GraphQL_API.Server.Resolvers;

using HotChocolate.Types;

namespace GraphQL_API.Server.Schema
{
    public class AccountType : ObjectType<Account>
    {
        protected override void Configure(IObjectTypeDescriptor<Account> descriptor)
        {
            descriptor.Field(t => t.Number)
                .Resolver(ctx => AccountResolvers.GetNumber(ctx, ctx.Parent<Account>(), ctx.Service<AccountAdapter>()));

            descriptor.Field(t => t.Balance)
                .Resolver(ctx => AccountResolvers.GetBalance(ctx, ctx.Parent<Account>(), ctx.Service<AccountAdapter>()));

            descriptor.Field(t => t.CreationDate)
                .Resolver(ctx => AccountResolvers.GetCreationDate(ctx, ctx.Parent<Account>(), ctx.Service<AccountAdapter>()));

            descriptor.Field(t => t.Devices)
                .Resolver(ctx => AccountResolvers.GetDevices(ctx, ctx.Parent<Account>(), ctx.Service<AccountAdapter>()));

            descriptor.Field(t => t.ContractNumber)
                .Resolver(ctx => AccountResolvers.GetСontractNumber(ctx, ctx.Parent<Account>(), ctx.Service<AccountAdapter>()));

            descriptor.Field(t => t.Id)
               .Resolver(ctx => AccountResolvers.GetId(ctx, ctx.Parent<Account>(), ctx.Service<AccountAdapter>()));
        }
    }
}
