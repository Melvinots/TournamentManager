using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Options;
using System.Data;
using TournamentManager.Models.appsettings;

namespace TournamentManager.Data
{
    public class DbManager(IOptions<Appsettings> options) 
    {
        private readonly string connString = options.Value.ConnectionStrings.ProjectDB;

        public SqlCommand BuildSP(string query)
        {
            var cmd = new SqlCommand
            {
                CommandType = CommandType.StoredProcedure,
                CommandText = query
            };
            return cmd;
        }

        public void AddParameter(SqlCommand cmd, string name, SqlDbType type, object value)
        {
            cmd.Parameters.Add(name, type).Value = value ?? DBNull.Value;
        }

        public async Task<List<T>> ExecuteReaderAsync<T>(SqlCommand cmd) where T : class
        {
            using var conn = new SqlConnection(connString);
            cmd.Connection = conn;

            await conn.OpenAsync();
            using var reader = await cmd.ExecuteReaderAsync();

            var dt = new DataTable();
            dt.Load(reader);

            return await Mapper.MapAsync<T>(dt);
        }

        public async Task ExecuteNonQueryAsync(SqlCommand cmd)
        {
            using var conn = new SqlConnection(connString);
            cmd.Connection = conn;

            await conn.OpenAsync();
            await cmd.ExecuteNonQueryAsync();
        }
    }
}
