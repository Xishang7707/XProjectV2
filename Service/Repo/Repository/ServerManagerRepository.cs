using Core.Models.PO;
using Core.Repo;
using Infrastruct.DB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServerManager.Repo.Repository
{
    class ServerManagerRepository : RepositoryAbstract
    {
        public ServerManagerRepository(DBContext dBContext) : base(dBContext) { }

        public Task<int> Add(PO_Server model)
        {
            string sql = @"INSERT INTO po_server(id, name, platformtype, loginuser, loginmethod, password, publickey, publickeypassword, addtime, host, port) 
                            VALUES (@id, @name, @platformtype, @loginuser, @loginmethod, @password, @publickey, @publickeypassword, @addtime, @host, @port);";
            return DBContext.ExecuteAsync(sql, model);
        }

        public async Task<bool> Delete(string id)
        {
            string sql = @"delete from po_server where id=@id";
            return await DBContext.ExecuteAsync(sql, new { id }) > 0;
        }
    }
}
