using Core.Domain;
using Core.Models.PO;
using Core.Models.Results;
using Infrastruct.DB;
using ServerManager.Domain.Entities;
using ServerManager.Domain.VO;
using ServerManager.Repo.DO;
using ServerManager.Repo.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServerManager.Service.Implememts
{
    class ServerManagerService : DomainServiceAbstract, IServerManagerService
    {
        private ServerManagerRepository ServerManagerRepository { get; }
        public ServerManagerService(ServerManagerRepository serverManagerRepository) => ServerManagerRepository = serverManagerRepository;
        public async Task<Result> AddServer(AddServerDo model)
        {
            Server server = new Server(Guid.NewGuid(), model.Name, model.Host, model.Port, model.PlatformType, model.LoginInfo);

            bool flag = await ServerManagerRepository.Add(new PO_Server
            {
                Id = server.GetPOId(),
                Name = server.Name,
                Host = server.Host,
                Port = server.Port,
                PlatformType = server.PlatformType.Type,
                LoginUser = server.LoginInfo.LoginUser,
                LoginMethod = server.LoginInfo.LoginMethod.Method,
                Password = server.LoginInfo.Password,
                PublicKey = server.LoginInfo.PublicKey,
                PublicKeyPassword = server.LoginInfo.PublicKeyPassword,
                AddTime = DateTime.Now
            }) > 0;

            Assert(flag, "添加失败");
            return new Result(flag, "添加成功");
        }

        public async Task<Result> DeleteServer(DeleteServerDo model)
        {
            bool flag = await ServerManagerRepository.Delete(model.Id);

            Assert(flag, "数据已被删除或不存在");
            return new Result(flag, "删除成功");
        }
    }
}
