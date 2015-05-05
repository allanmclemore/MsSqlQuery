using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Threading.Tasks;
using Dapper;

namespace MsSqlQuery
{
    public class SqlQuery
    {
        public virtual IEnumerable<T> Select<T>(SqlQueryRequest request)
        {
            using (var connection = request.ConnectionFactory.Create(request.ConnectionString))
            {
                connection.Open();
                return connection.Query<T>(request.Sql, request.Parameters, request.Transaction, request.IsBuffered,
                    request.Timeout, request.CommandType);
            }
        }

        public virtual IEnumerable<T> Select<T>(SqlQueryRequest request, IDbConnection connection)
        {
            if (connection.State != ConnectionState.Open)
            {
                connection.Open();
            }
            return connection.Query<T>(request.Sql, request.Parameters, request.Transaction, request.IsBuffered,
                request.Timeout, request.CommandType);
        }

        public virtual async Task<IEnumerable<T>> SelectAsync<T>(SqlQueryRequest request)
        {
            using (var connection = (SqlConnection) request.ConnectionFactory.CreateAsync(request.ConnectionString))
            {
                await connection.OpenAsync().ConfigureAwait(false);
                return
                    await
                        connection.QueryAsync<T>(request.Sql, request.Parameters, request.Transaction, request.Timeout,
                            request.CommandType)
                            .ConfigureAwait(false);
            }
        }

        public virtual async Task<IEnumerable<T>> SelectAsync<T>(SqlQueryRequest request, IDbConnection connection)
        {
            if (connection.State != ConnectionState.Open)
            {
                await ((SqlConnection) connection).OpenAsync().ConfigureAwait(false);
            }

            return
                await
                    connection.QueryAsync<T>(request.Sql, request.Parameters, request.Transaction, request.Timeout,
                        request.CommandType)
                        .ConfigureAwait(false);
        }
    }
}