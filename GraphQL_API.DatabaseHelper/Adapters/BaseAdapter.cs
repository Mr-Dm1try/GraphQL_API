using Npgsql;
using System.Data;

namespace GraphQL_API.DatabaseHelper.Adapters
{
    public class BaseAdapter
    {
        private string _config;
        internal BaseAdapter(string postgresConfig)
        {
            _config = postgresConfig;
        }

        internal IDbConnection Connection => new NpgsqlConnection(_config);
    }
}