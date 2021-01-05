using Core.DB;
using Infrastruct.Configs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastruct.DB
{
    public class CollectionContext : PGSqlContext
    {
        public CollectionContext(DBConfig dbConfig) : base(dbConfig.ConnectionConnectionString)
        {
        }
    }
}
