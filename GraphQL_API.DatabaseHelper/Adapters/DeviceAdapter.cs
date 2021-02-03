using Dapper;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace GraphQL_API.DatabaseHelper.Adapters
{
    public class DeviceAdapter : BaseAdapter
    {
        internal DeviceAdapter(string postgresConfig) : base(postgresConfig) { }

        public async Task<IReadOnlyDictionary<int, long>> GetNumbers(IReadOnlyList<int> ids)
        {
            using var connect = Connection;
            connect.Open();

            var pairs = await connect.QueryAsync<KeyValuePair<int, long>>(
                "select id as Key, number as Value from device where id = any(@Ids)", new { Ids = ids });
            return new Dictionary<int, long>(pairs);
        }

        public async Task<IReadOnlyDictionary<int, DateTime>> GetDatesByIds(IReadOnlyList<int> ids)
        {
            using var connect = Connection;
            connect.Open();

            var pairs = await connect.QueryAsync<KeyValuePair<int, DateTime>>(
                "select id as Key, creation_date as Value from device where id = any(@Ids)", new { Ids = ids });
            return new Dictionary<int, DateTime>(pairs);
        }

        public async Task<IReadOnlyDictionary<long, DateTime>> GetDatesByNums(IReadOnlyList<long> nums)
        {
            using var connect = Connection;
            connect.Open();

            var pairs = await connect.QueryAsync<KeyValuePair<long, DateTime>>(
                "select number as Key, creation_date as Value from device where number = any(@Nums)", new { Nums = nums });
            return new Dictionary<long, DateTime>(pairs);
        }

        public async Task<IReadOnlyDictionary<int, string>> GetTariffsByIds(IReadOnlyList<int> ids)
        {
            using var connect = Connection;
            connect.Open();

            var pairs = await connect.QueryAsync<KeyValuePair<int, string>>(
                "select id as Key, tariff_plan as Value from device where id = any(@Ids)", new { Ids = ids });
            return new Dictionary<int, string>(pairs);
        }

        public async Task<IReadOnlyDictionary<long, string>> GetTariffsByNums(IReadOnlyList<long> nums)
        {
            using var connect = Connection;
            connect.Open();

            var pairs = await connect.QueryAsync<KeyValuePair<long, string>>(
                "select number as Key, tariff_plan as Value from device where number = any(@Nums)", new { Nums = nums });
            return new Dictionary<long, string>(pairs);
        }

        public async Task<IReadOnlyDictionary<int, long>> GetImsisByIds(IReadOnlyList<int> ids)
        {
            using var connect = Connection;
            connect.Open();

            var pairs = await connect.QueryAsync<KeyValuePair<int, long>>(
                "select id as Key, imsi as Value from device where id = any(@Ids)", new { Ids = ids });
            return new Dictionary<int, long>(pairs);
        }

        public async Task<IReadOnlyDictionary<long, long>> GetImsisByNums(IReadOnlyList<long> nums)
        {
            using var connect = Connection;
            connect.Open();

            var pairs = await connect.QueryAsync<KeyValuePair<long, long>>(
                "select number as Key, imsi as Value from device where number = any(@Nums)", new { Nums = nums });
            return new Dictionary<long, long>(pairs);
        }

        public async Task<IReadOnlyDictionary<int, long>> GetAccountNumbersByIds(IReadOnlyList<int> ids)
        {
            using var connect = Connection;
            connect.Open();

            var pairs = await connect.QueryAsync<KeyValuePair<int, long>>(
                @"select device.id as Key, account.number as Value 
                    from device join account on device.account_id = account.id
                    where device.id = any(@Ids)", new { Ids = ids });

            return new Dictionary<int, long>(pairs);
        }

        public async Task<IReadOnlyDictionary<long, long>> GetAccountNumbersByNums(IReadOnlyList<long> nums)
        {
            using var connect = Connection;
            connect.Open();

            var pairs = await connect.QueryAsync<KeyValuePair<long, long>>(
                @"select device.number as Key, account.number as Value 
                    from device join account on device.account_id = account.id
                    where device.number = any(@Nums)", new { Nums = nums });
            return new Dictionary<long, long>(pairs);
        }

        public async Task<IReadOnlyDictionary<long, int>> GetIds(IReadOnlyList<long> nums)
        {
            using var connect = Connection;
            connect.Open();

            var pairs = await connect.QueryAsync<KeyValuePair<long, int>>(
                "select number as Key, id as Value from device where number = any(@Nums)", new { Nums = nums });
            return new Dictionary<long, int>(pairs);
        }
    }
}
