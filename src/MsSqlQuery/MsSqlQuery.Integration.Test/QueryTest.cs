using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data.SqlServerCe;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Shouldly;

namespace MsSqlQuery.Integration.Test
{
    [TestClass]
    public class QueryTest
    {
        [TestMethod]
        public void ShouldReturnResultsWhenQueryHasResults()
        {
            var sql = "SELECT [Employee ID] as Id,[Last Name] as LastName,[First Name] as FirstName FROM Employees";
            var request = new SqlQueryRequest(new ConnectionFactory<SqlCeConnection>(), Global.ConnectionString(), sql);
            var query = new SqlQuery();
            var result = query.Select<Employee>(request).ToList();

            result.ShouldBeOfType(typeof (List<Employee>));
            result.ShouldNotBeEmpty();
        }

        public class Employee
        {
            public int Id { get; set; }
            public string FirstName { get; set; }
            public string LastName { get; set; }
        }
    }
}