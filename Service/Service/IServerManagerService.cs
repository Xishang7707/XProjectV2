using Core.Models.Results;
using ServerManager.Repo.DO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServerManager.Service
{
    public interface IServerManagerService
    {
        Task<Result> AddServer(AddServerDo model);
        Task<Result> DeleteServer(DeleteServerDo model);
    }
}
