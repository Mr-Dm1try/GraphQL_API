using GraphQL_API.DatabaseHelper.Adapters;
using GraphQL_API.Server.DataModel;

using HotChocolate.Resolvers;

using System.Collections.Generic;
using System.Linq;

namespace GraphQL_API.Server.Schema
{
    public class Query
    {
        /// <summary>
        /// Получить абонентов по ИД
        /// </summary>
        public IEnumerable<Subscriber> GetSubscribersByIds(IResolverContext context, IEnumerable<int> ids)
            => ids.Select(id => context.Service<SubscriberAdapter>().IsPhysical(id)
                ? (Subscriber)new PhysicalPerson { Id = id } : new LegalPerson { Id = id });

        /// <summary>
        /// Получить всех абонентов
        /// </summary>
        public IEnumerable<Subscriber> GetAllSubscribers(IResolverContext context)
            => context.Service<SubscriberAdapter>().GetAllIds().Select(pair => pair.Value
                ? (Subscriber)new PhysicalPerson { Id = pair.Key } : new LegalPerson { Id = pair.Key });

        /// <summary>
        /// Получить контракты по ИД
        /// </summary>
        public IEnumerable<Contract> GetContractsByIds(IEnumerable<int> ids)
            => ids.Select(id => new Contract { Id = id });

        /// <summary>
        /// Получить контракты по номерам
        /// </summary>
        public IEnumerable<Contract> GetContractsByNumbers(IEnumerable<long> numbers)
            => numbers.Select(num => new Contract { Number = num });

        /// <summary>
        /// Получить лицевые счета по ИД
        /// </summary>
        public IEnumerable<Account> GetAccountsByIds(IEnumerable<int> ids)
            => ids.Select(id => new Account { Id = id });

        /// <summary>
        /// Получить лицевые счета по номерам
        /// </summary>
        public IEnumerable<Account> GetAccountsByNumbers(IEnumerable<long> numbers)
            => numbers.Select(num => new Account { Number = num });

        /// <summary>
        /// Получить приложения абонентов по ИД
        /// </summary>
        public IEnumerable<SubscriberDevice> GetDevicesByIds(IEnumerable<int> ids)
            => ids.Select(id => new SubscriberDevice { Id = id });

        /// <summary>
        /// Получить приложения абонентов по ИД
        /// </summary>
        public IEnumerable<SubscriberDevice> GetDevicesByNumbers(IEnumerable<int> numbers)
            => numbers.Select(num => new SubscriberDevice { Number = num });
    }
}
