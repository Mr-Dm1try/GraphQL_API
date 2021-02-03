using GraphQL_API.DatabaseHelper.Adapters;
using GraphQL_API.Server.DataModel;

using GreenDonut;

using HotChocolate;
using HotChocolate.Resolvers;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GraphQL_API.Server.Resolvers
{
    public class SubscriberResolvers
    {
        public static async Task<IDictionary<string, string>> GetContactDetails(IResolverContext context, [Parent] Subscriber sub, [Service] SubscriberAdapter data)
            => await context.BatchDataLoader<int, IDictionary<string, string>>("getContactDetails", data.GetContactDetails).LoadAsync(((Entity)sub).Id);

        public static async Task<IEnumerable<Contract>> GetContracts(IResolverContext context, [Parent] Subscriber sub, [Service] SubscriberAdapter data)
            => (await context.BatchDataLoader<int, IEnumerable<int>>("getContractIds", data.GetContractIds).LoadAsync(((Entity)sub).Id))
            .Select(id => new Contract { Id = id });

        public static async Task<string> GetPhysicalPersonSurname(IResolverContext context, [Parent] Subscriber sub, [Service] SubscriberAdapter data)
            => (await context.BatchDataLoader<int, string>("getFullNames", data.GetFullNames).LoadAsync(((Entity)sub).Id)).Split(' ')[0];

        public static async Task<string> GetPhysicalPersonName(IResolverContext context, [Parent] Subscriber sub, [Service] SubscriberAdapter data)
            => (await context.BatchDataLoader<int, string>("getFullNames", data.GetFullNames).LoadAsync(((Entity)sub).Id)).Split(' ')[1];

        public static async Task<string> GetPhysicalPersonMiddleName(IResolverContext context, [Parent] Subscriber sub, [Service] SubscriberAdapter data)
            => (await context.BatchDataLoader<int, string>("getFullNames", data.GetFullNames).LoadAsync(((Entity)sub).Id)).Split(' ')[2];


        public static async Task<string> GetLegalPersonName(IResolverContext context, [Parent] Subscriber sub, [Service] SubscriberAdapter data)
            => await context.BatchDataLoader<int, string>("getFullNames", data.GetFullNames).LoadAsync(((Entity)sub).Id);

        public static async Task<string> GetLegalPersonForm(IResolverContext context, [Parent] Subscriber sub, [Service] SubscriberAdapter data)
            => await context.BatchDataLoader<int, string>("getForms", data.GetForms).LoadAsync(((Entity)sub).Id);
    }
}
