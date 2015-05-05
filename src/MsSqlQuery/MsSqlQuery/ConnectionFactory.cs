using System;
using System.Data;
using System.Data.SqlClient;
using System.Data.SqlServerCe;
using System.Data.SQLite;
using MySql.Data.MySqlClient;
using Npgsql;
using Oracle.ManagedDataAccess.Client;

namespace MsSqlQuery
{
    /*
     *  Connection Factory supporting the following database provider types:
     *  Microsoft SQL Server
     *  Microsoft SQL Server Compact Edition
     *  MySql
     *  Oracle
     *  SQL Lite
     *  Postgres 
     */

    public class ConnectionFactory<T> : IConnectionFactory
    {
        public virtual IDbConnection Create(string connectionString)
        {
            if (this is ConnectionFactory<SqlConnection>)
            {
                return new SqlConnection(connectionString);
            }
            if (this is ConnectionFactory<SqlCeConnection>)
            {
                return new SqlCeConnection(connectionString);
            }
            if (this is ConnectionFactory<MySqlConnection>)
            {
                return new MySqlConnection(connectionString);
            }
            if (this is ConnectionFactory<OracleConnection>)
            {
                return new OracleConnection(connectionString);
            }
            if (this is ConnectionFactory<SQLiteConnection>)
            {
                return new SQLiteConnection(connectionString);
            }
            if (this is ConnectionFactory<NpgsqlConnection>)
            {
                return new NpgsqlConnection(connectionString);
            }
            throw new NotSupportedException("Unsupported Db Connection type" + GetType());
        }

        public virtual IDbConnection CreateAsync(string connectionString)
        {
            if (this is ConnectionFactory<SqlConnection>)
            {
                return new SqlConnection(AsyncConnectionString(connectionString));
            }
            throw new ArgumentException("Invalid connection type. CreateAsync method only supports SqlConnection type.");
        }

        private string AsyncConnectionString(string connectionString)
        {
            var builder = new SqlConnectionStringBuilder(connectionString) {AsynchronousProcessing = true};
            return builder.ToString();
        }
    }
}