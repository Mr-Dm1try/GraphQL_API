using Dapper;

using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GraphQL_API.DatabaseHelper.Adapters
{
    public class SubscriberAdapter : BaseAdapter
    {
        internal SubscriberAdapter(string postgresConfig) : base(postgresConfig) { }

        public bool IsPhysical(int id)
        {
            using var connect = Connection;
            connect.Open();

            var orgForm = connect.Query<string>("select organization_form from subscriber where id = @Id", new { Id = id });
            return string.IsNullOrEmpty(orgForm.FirstOrDefault());
        }

        public async Task<IReadOnlyDictionary<int, IDictionary<string, string>>> GetContactDetails(IReadOnlyList<int> ids)
        {
            using var connect = Connection;
            connect.Open();

            var pairs = await connect.QueryAsync<KeyValuePair<int, IEnumerable<string>>>("select id as Key, contact_details as Value from subscriber where id = any(@Ids)", new { Ids = ids });
            return pairs.ToDictionary(pair => pair.Key, 
                pair => (IDictionary<string, string>)pair.Value.ToDictionary(row => row.Split(':')[0], row => row.Split(':')[1]));
        }

        public IDictionary<int, bool> GetAllIds()
        {
            using var connect = Connection;
            connect.Open();

            var pairs = connect.Query<KeyValuePair<int, string>>("select id as Key, organization_form as Value from subscriber");
            return pairs.ToDictionary(pair => pair.Key, pair => string.IsNullOrEmpty(pair.Value));
        }

        public async Task<IReadOnlyDictionary<int, IEnumerable<int>>> GetContractIds(IReadOnlyList<int> ids)
        {
            using var connect = Connection;
            connect.Open();

            var pairs = await connect.QueryAsync<KeyValuePair<int, IEnumerable<int>>>("select subscriber_id as Key, array_agg(id) as Value from contract where subscriber_id = any(@Ids) group by subscriber_id", new { Ids = ids });
            return new Dictionary<int, IEnumerable<int>>(pairs);
        }

        public async Task<IReadOnlyDictionary<int, string>> GetFullNames(IReadOnlyList<int> ids)
        {
            using var connect = Connection;
            connect.Open();

            var pairs = await connect.QueryAsync<KeyValuePair<int, string>>("select id as Key, full_name as Value from subscriber where id = any(@Ids)", new { Ids = ids });
            return new Dictionary<int, string>(pairs);
        }

        public async Task<IReadOnlyDictionary<int, string>> GetForms(IReadOnlyList<int> ids)
        {
            using var connect = Connection;
            connect.Open();

            var pairs = await connect.QueryAsync<KeyValuePair<int, string>>("select id as Key, organization_form as Value from subscriber where id = any(@Ids)", new { Ids = ids });
            return new Dictionary<int, string>(pairs);
        }
    }
}
