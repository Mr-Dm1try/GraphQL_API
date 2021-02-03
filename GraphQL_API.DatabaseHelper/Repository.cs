using GraphQL_API.DatabaseHelper.Adapters;

using Microsoft.Extensions.DependencyInjection;

namespace GraphQL_API.DatabaseHelper
{
    public static class Repository
    {
        public static AccountAdapter accountAdapter;
        public static ContractAdapter contractAdapter;
        public static DeviceAdapter deviceAdapter;
        public static SubscriberAdapter subscriberAdapter;

        public static IServiceCollection CreateSingletonForEachAdapter(this IServiceCollection services, string postgresConfig)
        {
            accountAdapter = new AccountAdapter(postgresConfig);
            contractAdapter = new ContractAdapter(postgresConfig);
            deviceAdapter = new DeviceAdapter(postgresConfig);
            subscriberAdapter = new SubscriberAdapter(postgresConfig);

            return services?
                .AddSingleton(accountAdapter)
                .AddSingleton(contractAdapter)
                .AddSingleton(deviceAdapter)
                .AddSingleton(subscriberAdapter);
        }
    }
}
