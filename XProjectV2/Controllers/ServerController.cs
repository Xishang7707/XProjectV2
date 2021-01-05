using Core.Models.DTO;
using Core.Models.Results;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Queries;
using Queries.DTO;
using Queries.ViewModels.Results;
using ServerManager.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace XProjectV2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ServerController : ControllerBase
    {
        private IServerManagerService ServerManagerService { get; }
        private ServerQuery ServerQuery { get; }
        public ServerController(IServerManagerService serverManagerService, ServerQuery serverQuery)
        {
            ServerManagerService = serverManagerService;
            ServerQuery = serverQuery;
        }

        [HttpPost("add")]
        public async Task<IActionResult> Add([FromBody] AddServerDTO model)
        {
            _ = int.TryParse(model.Port, out int port);
            _ = int.TryParse(model.PlatformType, out int platformType);
            _ = int.TryParse(model.LoginMethod, out int loginMethod);

            var result = await ServerManagerService.AddServer(new ServerManager.Repo.DO.AddServerDo
            {
                Name = model.Name,
                Host = model.Host,
                Port = port,
                PlatformType = new ServerManager.Domain.VO.PlatformType(platformType),
                LoginInfo = new ServerManager.Domain.VO.LoginInfo(
                   model.LoginUser,
                   new ServerManager.Domain.VO.LoginMethod(loginMethod),
                   model.Password,
                   model.PublicKey,
                   model.PublicKeyPassword)
            });

            return new RespResult
            {
                Status = result.IsSuccess ? 200 : 400,
                Msg = result.Msg
            };
        }

        [HttpPost("delete")]
        public async Task<IActionResult> Delete([FromBody] DeleteServerDTO model)
        {
            var result = await ServerManagerService.DeleteServer(new ServerManager.Repo.DO.DeleteServerDo { Id = model.Id });
            return new RespResult
            {
                Status = result.IsSuccess ? 200 : 400,
                Msg = result.Msg
            };
        }

        [HttpGet("getpages")]
        public async Task<IActionResult> GetPages([FromQuery] PageDto dto)
        {
            //return Task.FromResult(new PageResult<int>());
            return await ServerQuery.GetPages(dto);
        }
    }
}
