using Core.DB;
using Infrastruct.Configs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastruct.DB
{
    public class QueryContext : PGSqlContext
    {
        public QueryContext(DBConfig dbConfig) : base(dbConfig.ConnectionString)
        {
        }
    }
}
