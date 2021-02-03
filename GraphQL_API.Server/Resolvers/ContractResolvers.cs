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
    public class ContractResolvers
    {
        public static async Task<long> GetNumber(IResolverContext context, [Parent] Contract contract, [Service] ContractAdapter data)
            => contract.Number = contract.Number = contract.Number == default
                ? await context.BatchDataLoader<int, long>("getContractsNumbers", data.GetNumbers).LoadAsync(contract.Id)
                : contract.Number;

        public static async Task<DateTime> GetCreationDate(IResolverContext context, [Parent] Contract contract, [Service] ContractAdapter data)
            => contract.Id != default
                ? await context.BatchDataLoader<int, DateTime>("getContractsDatesByIds", data.GetDatesByIds).LoadAsync(contract.Id)
                : await context.BatchDataLoader<long, DateTime>("getContractsDatesByNums", data.GetDatesByNums).LoadAsync(contract.Number);

        public static async Task<IEnumerable<Account>> GetAccounts(IResolverContext context, [Parent] Contract contract, [Service] ContractAdapter data)
            => contract.Accounts = (contract.Id != default
                ? await context.BatchDataLoader<int, IEnumerable<int>>("getAccountIdsByIds", data.GetAccountIdsByIds).LoadAsync(contract.Id)
                : await context.BatchDataLoader<long, IEnumerable<int>>("getAccountIdsByNums", data.GetAccountIdsByNums).LoadAsync(contract.Number))
            .Select(id => new Account { Id = id });

        public static async Task<long> GetSubscriberId(IResolverContext context, [Parent] Contract contract, [Service] ContractAdapter data)
            => contract.Id != default
                ? await context.BatchDataLoader<int, int>("getSubscriberIdsByIds", data.GetSubscriberIdsByIds).LoadAsync(contract.Id)
                : await context.BatchDataLoader<long, int>("getSubscriberIdsByNums", data.GetSubscriberIdsByNums).LoadAsync(contract.Number);

        public static async Task<int> GetId(IResolverContext context, [Parent] Contract contract, [Service] ContractAdapter data)
            => contract.Id = contract.Id == default
                ? await context.BatchDataLoader<long, int>("getContractsIds", data.GetIds).LoadAsync(contract.Id)
                : contract.Id;
    }
}
