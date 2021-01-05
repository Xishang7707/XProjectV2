using Core.Models.PO;
using Core.Repo;
using Infrastruct.DB;
using PublishService.ServerPublish.Repo.ViewModels;
using Queries.ViewModels.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PublishService.ServerPublish.Repo.Repository
{
    public class ServerRuntimeRepostory : RepositoryAbstract
    {
        public ServerRuntimeRepostory(CollectionContext dBContext) : base(dBContext) { }

        public async Task<ServerRuntimeInfo> GetHomeInfo()
        {
            //(id, name, cpusus, cpussy, cpusni, cpusid, addtime) VALUES (@id, @name, @cpusus, @cpussy, @cpusni, @cpusid, @addtime);
            string sql = @"select id, cpusid, addtime from po_serverruntime order by addtime desc limit 60";
            var list = await DBContext.QueryListAsync<PO_ServerRuntime>(sql);

            var info = new ServerRuntimeInfo
            {
                Cpu = list.Select(s => new CpuItem
                {
                    Id = s.Id,
                    CpuUtilization = (int)(100 - s.CpusId),
                    Time = s.AddTime
                })
            };

            return info;
        }
    }
}
