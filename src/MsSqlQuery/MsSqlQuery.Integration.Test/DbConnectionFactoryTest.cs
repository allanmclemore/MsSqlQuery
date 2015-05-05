using System.Data.SqlClient;
using System.Data.SqlServerCe;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MySql.Data.MySqlClient;
using Npgsql;
using Oracle.ManagedDataAccess.Client;
using Shouldly;

namespace MsSqlQuery.Integration.Test
{
    [TestClass]
    public class DbConnectionFactoryTest
    {
        [TestMethod]
        public void ShouldCreateConnectionWhenDbConnectionFactoryIsSqlConnection()
        {
            var factory = new ConnectionFactory<SqlConnection>();
            var conn = factory.Create("");
            conn.ShouldBeOfType(typeof (SqlConnection));
        }

        [TestMethod]
        public void ShouldCreateConnectionWhenDbConnectionFactoryIsSqlCeConnection()
        {
            var factory = new ConnectionFactory<SqlCeConnection>();
            var conn = factory.Create("");
            conn.ShouldBeOfType(typeof (SqlCeConnection));
        }

        [TestMethod]
        public void ShouldCreateConnectionWhenDbConnectionFactoryIsMySqlConnection()
        {
            var factory = new ConnectionFactory<MySqlConnection>();
            var conn = factory.Create("");
            conn.ShouldBeOfType(typeof (MySqlConnection));
        }

        [TestMethod]
        public void ShouldCreateConnectionWhenDbConnectionFactoryIsOracleConnection()
        {
            var factory = new ConnectionFactory<OracleConnection>();
            var conn = factory.Create("");
            conn.ShouldBeOfType(typeof (OracleConnection));
        }

        [TestMethod]
        public void ShouldCreateConnectionWhenDbConnectionFactoryIsPostgresConnection()
        {
            var factory = new ConnectionFactory<NpgsqlConnection>();
            var conn = factory.Create("");
            conn.ShouldBeOfType(typeof (NpgsqlConnection));
        }
    }
}