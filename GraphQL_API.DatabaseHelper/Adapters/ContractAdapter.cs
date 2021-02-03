using Dapper;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace GraphQL_API.DatabaseHelper.Adapters
{
    public class ContractAdapter : BaseAdapter
    {
        internal ContractAdapter(string postgresConfig) : base(postgresConfig) { }

        public async Task<IReadOnlyDictionary<int, long>> GetNumbers(IReadOnlyList<int> ids)
        {
            using var connect = Connection;
            connect.Open();

            var pairs = await connect.QueryAsync<KeyValuePair<int, long>>(
                "select id as Key, number as Value from contract where id = any(@Ids)", new { Ids = ids });
            return new Dictionary<int, long>(pairs);
        }

        public async Task<IReadOnlyDictionary<int, DateTime>> GetDatesByIds(IReadOnlyList<int> ids)
        {
            using var connect = Connection;
            connect.Open();

            var pairs = await connect.QueryAsync<KeyValuePair<int, DateTime>>(
                "select id as Key, creation_date as Value from contract where id = any(@Ids)", new { Ids = ids });
            return new Dictionary<int, DateTime>(pairs);
        }

        public async Task<IReadOnlyDictionary<long, DateTime>> GetDatesByNums(IReadOnlyList<long> nums)
        {
            using var connect = Connection;
            connect.Open();

            var pairs = await connect.QueryAsync<KeyValuePair<long, DateTime>>(
                "select number as Key, creation_date as Value from contract where number = any(@Nums)", new { Nums = nums });
            return new Dictionary<long, DateTime>(pairs);
        }

        public async Task<IReadOnlyDictionary<int, IEnumerable<int>>> GetAccountIdsByIds(IReadOnlyList<int> ids)
        {
            using var connect = Connection;
            connect.Open();

            var pairs = await connect.QueryAsync<KeyValuePair<int, IEnumerable<int>>>(
                @"select contract_id as Key, array_agg(id) as Value 
                    from account 
                    where contract_id = any(@Ids) 
                    group by contract_id", new { Ids = ids });
            return new Dictionary<int, IEnumerable<int>>(pairs);
        }
        public async Task<IReadOnlyDictionary<long, IEnumerable<int>>> GetAccountIdsByNums(IReadOnlyList<long> nums)
        {
            using var connect = Connection;
            connect.Open();

            var pairs = await connect.QueryAsync<KeyValuePair<long, IEnumerable<int>>>(
                @"select contract.number as Key, array_agg(account.id) as Value 
                    from contract inner join account on contract.id = account.contract_id where contract.number = any(@Nums)
                    group by contract.number", new { Nums = nums });

            return new Dictionary<long, IEnumerable<int>>(pairs);
        }

        public async Task<IReadOnlyDictionary<int, int>> GetSubscriberIdsByIds(IReadOnlyList<int> ids)
        {
            using var connect = Connection;
            connect.Open();

            var pairs = await connect.QueryAsync<KeyValuePair<int, int>>(
                "select id as Key, subscriber_id as Value from contract where id = any(@Ids)", new { Ids = ids });
            return new Dictionary<int, int>(pairs);
        }

        public async Task<IReadOnlyDictionary<long, int>> GetSubscriberIdsByNums(IReadOnlyList<long> nums)
        {
            using var connect = Connection;
            connect.Open();

            var pairs = await connect.QueryAsync<KeyValuePair<long, int>>(
                "select number as Key, subscriber_id as Value from contract where number = any(@Nums)", new { Nums = nums });
            return new Dictionary<long, int>(pairs);
        }

        public async Task<IReadOnlyDictionary<long, int>> GetIds(IReadOnlyList<long> nums)
        {
            using var connect = Connection;
            connect.Open();

            var pairs = await connect.QueryAsync<KeyValuePair<long, int>>(
                "select number as Key, id as Value from contract where number = any(@Nums)", new { Nums = nums });
            return new Dictionary<long, int>(pairs);
        }
    }
}
