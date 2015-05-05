using System.Data;

namespace MsSqlQuery
{
    public interface IConnectionFactory
    {
        IDbConnection Create(string connectionString);
        IDbConnection CreateAsync(string connectionString);
    }
}