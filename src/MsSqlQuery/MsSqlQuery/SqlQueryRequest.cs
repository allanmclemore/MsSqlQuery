using System.Data;
using System.Dynamic;

namespace MsSqlQuery
{
    public class SqlQueryRequest
    {
        private readonly IConnectionFactory _connectionFactory;
        private readonly string _connectionString;
        private readonly string _sql;
        private bool _isBuffered = true;

        public SqlQueryRequest(IConnectionFactory connectionFactory, string connectionString, string sql)
        {
            _connectionFactory = connectionFactory;
            _connectionString = connectionString;
            _sql = sql;
        }

        public virtual CommandType? CommandType { get; set; }

        public virtual IConnectionFactory ConnectionFactory
        {
            get { return _connectionFactory; }
        }

        public virtual string ConnectionString
        {
            get { return _connectionString; }
        }

        public virtual bool IsBuffered
        {
            get { return _isBuffered; }
            set { _isBuffered = value; }
        }

        public virtual int? PageNumber { get; set; }
        public virtual int? PageSize { get; set; }
        public virtual ExpandoObject Parameters { get; set; }

        public virtual string Sql
        {
            get { return _sql; }
        }

        public virtual int? Timeout { get; set; }
        public virtual IDbTransaction Transaction { get; set; }
    }
}