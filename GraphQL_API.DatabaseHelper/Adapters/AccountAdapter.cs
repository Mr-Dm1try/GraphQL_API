using Dapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GraphQL_API.DatabaseHelper.Adapters
{
    public class AccountAdapter : BaseAdapter
    {
        internal AccountAdapter(string postgresConfig) : base(postgresConfig) { }

        public async Task<IReadOnlyDictionary<int, long>> GetNumbersByIds(IEnumerable<int> ids)
        {
            using var connect = Connection;
            connect.Open();

            var pairs = await connect.QueryAsync<KeyValuePair<int, long>>(
                "select id as Key, number as Value from account where id = any(@Ids)", new { Ids = ids });
            return new Dictionary<int, long>(pairs);
        }

        public async Task<IReadOnlyDictionary<int, decimal>> GetBalancesByIds(IEnumerable<int> ids)
        {
            using var connect = Connection;
            connect.Open();

            var pairs = await connect.QueryAsync<KeyValuePair<int, decimal>>(
                "select id as Key, balance as Value from account where id = any(@Ids)", new { Ids = ids });
            return new Dictionary<int, decimal>(pairs);
        }

        public async Task<IReadOnlyDictionary<long, decimal>> GetBalancesByNums(IEnumerable<long> nums)
        {
            using var connect = Connection;
            connect.Open();

            var pairs = await connect.QueryAsync<KeyValuePair<long, decimal>>(
                "select number as Key, balance as Value from account where number = any(@Nums)", new { Nums = nums });
            return new Dictionary<long, decimal>(pairs);
        }

        public async Task<IReadOnlyDictionary<int, DateTime>> GetDatesByIds(IReadOnlyList<int> ids)
        {
            using var connect = Connection;
            connect.Open();

            var pairs = await connect.QueryAsync<KeyValuePair<int, DateTime>>(
                "select id as Key, creation_date as Value from account where id = any(@Ids)", new { Ids = ids });
            return new Dictionary<int, DateTime>(pairs);
        }

        public async Task<IReadOnlyDictionary<long, DateTime>> GetDatesByNums(IReadOnlyList<long> nums)
        {
            using var connect = Connection;
            connect.Open();

            var pairs = await connect.QueryAsync<KeyValuePair<long, DateTime>>(
                "select number as Key, creation_date as Value from account where number = any(@Nums)", new { Nums = nums });
            return new Dictionary<long, DateTime>(pairs);
        }

        public async Task<IReadOnlyDictionary<int, IEnumerable<int>>> GetDeviceIdsByIds(IReadOnlyList<int> ids)
        {
            using var connect = Connection;
            connect.Open();

            var pairs = await connect.QueryAsync<KeyValuePair<int, IEnumerable<int>>>(
                @"select account_id as Key, array_agg(id) as Value 
                    from device 
                    where account_id = any(@Ids) 
                    group by account_id", new { Ids = ids });
            return new Dictionary<int, IEnumerable<int>>(pairs);
        }

        public async Task<IReadOnlyDictionary<long, IEnumerable<int>>> GetDeviceIdsByNums(IReadOnlyList<long> nums)
        {
            using var connect = Connection;
            connect.Open();

            var pairs = await connect.QueryAsync<KeyValuePair<long, IEnumerable<int>>>(
                @"select account.number as Key, array_agg(device.id) as Value 
                    from account inner join device on account.id = device.account_id where account.number = any(@Nums)
                    group by account.number", new { Nums = nums });

            return new Dictionary<long, IEnumerable<int>>(pairs);
        }

        public async Task<IReadOnlyDictionary<int, long>> GetContractNumsByIds(IReadOnlyList<int> ids)
        {
            using var connect = Connection;
            connect.Open();

            var pairs = await connect.QueryAsync<KeyValuePair<int, long>>(
                @"select account.id as Key, contract.number as Value 
                    from account join contract on account.contract_id = contract.id
                    where account.id = any(@Ids)", new { Ids = ids });

            return new Dictionary<int, long>(pairs);
        }

        public async Task<IReadOnlyDictionary<long, long>> GetContractNumsByNums(IReadOnlyList<long> nums)
        {
            using var connect = Connection;
            connect.Open();

            var pairs = await connect.QueryAsync<KeyValuePair<long, long>>(
                @"select account.number as Key, contract.number as Value 
                    from account join contract on account.contract_id = contract.id
                    where account.number = any(@Nums)", new { Nums = nums });

            return new Dictionary<long, long>(pairs);
        }

        public async Task<IReadOnlyDictionary<long, int>> GetIds(IReadOnlyList<long> nums)
        {
            using var connect = Connection;
            connect.Open();

            var pairs = await connect.QueryAsync<KeyValuePair<long, int>>(
                "select number as Key, id as Value from account where number = any(@Nums)", new { Nums = nums });

            return new Dictionary<long, int>(pairs);
        }
    }
}
