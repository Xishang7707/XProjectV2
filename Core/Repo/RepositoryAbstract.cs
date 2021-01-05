using Core.DB;
using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Repo
{
    public class RepositoryAbstract
    {
        protected PGSqlContext DBContext { get; }
        public RepositoryAbstract(PGSqlContext dbContext) => DBContext = dbContext;
    }
}
