using GraphQL_API.DatabaseHelper.Adapters;
using GraphQL_API.Server.DataModel;
using GraphQL_API.Server.Resolvers;

using HotChocolate.Types;

namespace GraphQL_API.Server.Schema
{
    public class LegalPersonType : ObjectType<LegalPerson>
    {
        protected override void Configure(IObjectTypeDescriptor<LegalPerson> descriptor)
        {
            descriptor.Field(t => t.Name)
                .Resolver(ctx => SubscriberResolvers.GetLegalPersonName(ctx, ctx.Parent<Subscriber>(), ctx.Service<SubscriberAdapter>()));

            descriptor.Field(t => t.OrganizationForm)
                .Resolver(ctx => SubscriberResolvers.GetLegalPersonForm(ctx, ctx.Parent<Subscriber>(), ctx.Service<SubscriberAdapter>()));

            descriptor.Field(t => t.ContactDetails)
                .Resolver(ctx => SubscriberResolvers.GetContactDetails(ctx, ctx.Parent<Subscriber>(), ctx.Service<SubscriberAdapter>()));

            descriptor.Field(t => t.Contracts)
                .Resolver(ctx => SubscriberResolvers.GetContracts(ctx, ctx.Parent<Subscriber>(), ctx.Service<SubscriberAdapter>()));
            
            descriptor.Field(t => t.Id)
                    .Resolver(ctx => ((Entity)ctx.Parent<Subscriber>()).Id);
        }
    }
}
