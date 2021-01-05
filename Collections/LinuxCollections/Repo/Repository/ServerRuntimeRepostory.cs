using Core.Models.PO;
using Core.Repo;
using Infrastruct.DB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Collections.LinuxCollections.Repo.Repository
{
    public class ServerRuntimeRepostory : RepositoryAbstract
    {
        public ServerRuntimeRepostory(CollectionContext dBContext) : base(dBContext) { }

        public Task<int> Add(PO_ServerRuntime model)
        {
            string sql = @"INSERT INTO po_serverruntime(id, name, cpusus, cpussy, cpusni, cpusid, addtime) VALUES (@id, @name, @cpusus, @cpussy, @cpusni, @cpusid, @addtime);";
            return DBContext.ExecuteAsync(sql, model);
        }
    }
}
