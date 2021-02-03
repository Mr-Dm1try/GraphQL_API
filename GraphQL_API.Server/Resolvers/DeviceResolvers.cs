using GraphQL_API.DatabaseHelper.Adapters;
using GraphQL_API.Server.DataModel;

using GreenDonut;

using HotChocolate;
using HotChocolate.Resolvers;

using System;
using System.Threading.Tasks;

namespace GraphQL_API.Server.Resolvers
{
    public class DeviceResolvers
    {
        public static async Task<long> GetNumber(IResolverContext context, [Parent] SubscriberDevice device, [Service] DeviceAdapter data)
            => device.Number = device.Number = device.Number == default
                ? await context.BatchDataLoader<int, long>("getDevicesNumbers", data.GetNumbers).LoadAsync(device.Id)
                : device.Number;

        public static async Task<DateTime> GetCreationDate(IResolverContext context, [Parent] SubscriberDevice device, [Service] DeviceAdapter data)
            => device.Id != default
                ? await context.BatchDataLoader<int, DateTime>("getDevicesDatesByIds", data.GetDatesByIds).LoadAsync(device.Id)
                : await context.BatchDataLoader<long, DateTime>("getDevicesDatesByNums", data.GetDatesByNums).LoadAsync(device.Number);

        public static async Task<string> GetTariffPlan(IResolverContext context, [Parent] SubscriberDevice device, [Service] DeviceAdapter data)
            => device.Id != default
                ? await context.BatchDataLoader<int, string>("getTariffsByIds", data.GetTariffsByIds).LoadAsync(device.Id)
                : await context.BatchDataLoader<long, string>("getTariffsByNums", data.GetTariffsByNums).LoadAsync(device.Number);

        public static async Task<long> GetIMSI(IResolverContext context, [Parent] SubscriberDevice device, [Service] DeviceAdapter data)
            => device.Id != default
                ? await context.BatchDataLoader<int, long>("getImsisByIds", data.GetImsisByIds).LoadAsync(device.Id)
                : await context.BatchDataLoader<long, long>("getImsisByNums", data.GetImsisByNums).LoadAsync(device.Number);

        public static async Task<long> GetAccountNumber(IResolverContext context, [Parent] SubscriberDevice device, [Service] DeviceAdapter data)
            => device.Id != default
                ? await context.BatchDataLoader<int, long>("getAccountNumbersByIds", data.GetAccountNumbersByIds).LoadAsync(device.Id)
                : await context.BatchDataLoader<long, long>("getAccountNumbersByNums", data.GetAccountNumbersByNums).LoadAsync(device.Number);

        public static async Task<int> GetId(IResolverContext context, [Parent] SubscriberDevice device, [Service] DeviceAdapter data)
            => device.Id = device.Id == default
                ? await context.BatchDataLoader<long, int>("getContractsIds", data.GetIds).LoadAsync(device.Id)
                : device.Id;
    }
}
