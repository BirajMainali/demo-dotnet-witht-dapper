using Npgsql;

namespace DapperDemo.Providers.Interface
{
    public interface ISqlConnectionProvider
    {
        NpgsqlConnection GetConnection();
    }
}