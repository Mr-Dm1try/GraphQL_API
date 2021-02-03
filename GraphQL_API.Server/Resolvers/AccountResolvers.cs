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
    public class AccountResolvers
    {
        public static async Task<long> GetNumber(IResolverContext context, [Parent] Account account, [Service] AccountAdapter data)
            => account.Number = account.Number == default
                ? await context.BatchDataLoader<int, long>("getAccountsNumbers", data.GetNumbersByIds).LoadAsync(account.Id)
                : account.Number;

        public static async Task<decimal> GetBalance(IResolverContext context, [Parent] Account account, [Service] AccountAdapter data)
            => account.Id != default
                ? await context.BatchDataLoader<int, decimal>("getBalancesByIds", data.GetBalancesByIds).LoadAsync(account.Id)
                : await context.BatchDataLoader<long, decimal>("getBalancesByNums", data.GetBalancesByNums).LoadAsync(account.Number);

        public static async Task<DateTime> GetCreationDate(IResolverContext context, [Parent] Account account, [Service] AccountAdapter data)
            => account.Id != default
                ? await context.BatchDataLoader<int, DateTime>("getAccountsDatesByIds", data.GetDatesByIds).LoadAsync(account.Id)
                : await context.BatchDataLoader<long, DateTime>("GetAccountsDatesByNums", data.GetDatesByNums).LoadAsync(account.Number);

        public static async Task<IEnumerable<SubscriberDevice>> GetDevices(IResolverContext context, [Parent] Account account, [Service] AccountAdapter data)
            => account.Devices = (account.Id != default
                ? await context.BatchDataLoader<int, IEnumerable<int>>("getDeviceIdsByIds", data.GetDeviceIdsByIds).LoadAsync(account.Id)
                : await context.BatchDataLoader<long, IEnumerable<int>>("getDeviceIdsByNums", data.GetDeviceIdsByNums).LoadAsync(account.Number))
            .Select(id => new SubscriberDevice { Id = id });

        public static async Task<long> GetСontractNumber(IResolverContext context, [Parent] Account account, [Service] AccountAdapter data)
            => account.Id != default
                ? await context.BatchDataLoader<int, long>("getContractNumsByIds", data.GetContractNumsByIds).LoadAsync(account.Id)
                : await context.BatchDataLoader<long, long>("getContractNumsByNums", data.GetContractNumsByNums).LoadAsync(account.Number);

        public static async Task<int> GetId(IResolverContext context, [Parent] Account account, [Service] AccountAdapter data)
            => account.Id = account.Id == default
                ? await context.BatchDataLoader<long, int>("getAccountsIds", data.GetIds).LoadAsync(account.Id)
                : account.Id;
    }
}
