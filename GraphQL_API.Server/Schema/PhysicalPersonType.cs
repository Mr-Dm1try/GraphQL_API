using GraphQL_API.DatabaseHelper.Adapters;
using GraphQL_API.Server.DataModel;
using GraphQL_API.Server.Resolvers;

using HotChocolate.Types;

namespace GraphQL_API.Server.Schema
{
    public class PhysicalPersonType : ObjectType<PhysicalPerson>
    {
        protected override void Configure(IObjectTypeDescriptor<PhysicalPerson> descriptor)
        {
            descriptor.Field(t => t.Surname)
                .Resolver(ctx => SubscriberResolvers.GetPhysicalPersonSurname(ctx, ctx.Parent<Subscriber>(), ctx.Service<SubscriberAdapter>()));

            descriptor.Field(t => t.Name)
                .Resolver(ctx => SubscriberResolvers.GetPhysicalPersonName(ctx, ctx.Parent<Subscriber>(), ctx.Service<SubscriberAdapter>()));

            descriptor.Field(t => t.MiddleName)
                .Resolver(ctx => SubscriberResolvers.GetPhysicalPersonMiddleName(ctx, ctx.Parent<Subscriber>(), ctx.Service<SubscriberAdapter>()));

            descriptor.Field(t => t.ContactDetails)
                .Resolver(ctx => SubscriberResolvers.GetContactDetails(ctx, ctx.Parent<Subscriber>(), ctx.Service<SubscriberAdapter>()));

            descriptor.Field(t => t.Contracts)
                .Resolver(ctx => SubscriberResolvers.GetContracts(ctx, ctx.Parent<Subscriber>(), ctx.Service<SubscriberAdapter>()));
           
            descriptor.Field(t => t.Id)
                    .Resolver(ctx => ((Entity)ctx.Parent<Subscriber>()).Id);
        }
    }
}
