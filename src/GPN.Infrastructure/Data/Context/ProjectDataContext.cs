using Microsoft.Data.Sqlite;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GPN.Infrastructure.Data.Context
{
    public class ProjectDataContext
    {
        private readonly string _connectionString;

        public ProjectDataContext(string connectionString)
        {
            _connectionString = connectionString;
        }

        public IDbConnection Connection
        {
            get
            {
                var connection = new SqliteConnection(_connectionString);
                connection.Open();
                return connection;
            }
        }
    }
}
