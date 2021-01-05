using Core.Models.Results;
using Core.Repo;
using Dapper;
using Infrastruct.DB;
using Queries.DTO;
using Queries.ViewModels;
using Queries.ViewModels.Results;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Queries
{
    public class ServerQuery : RepositoryAbstract
    {
        public ServerQuery(QueryContext dbContext) : base(dbContext) { }

        public async Task<PageResult<ServerPageItem>> GetPages(PageDto dto)
        {
            string limit = @"offset @pass limit @pageSize";
            string total = @"select count(1) from po_server";
            string list = @"select id, name, loginuser, host, port from po_server";

            DynamicParameters p = new DynamicParameters();
            int count = await DBContext.QueryAsync<int>($"{total}", p);
            int pages = (count / dto.PageSize) + (count % dto.PageSize > 0 ? 1 : 0);
            pages = Math.Max(pages, 1);
            int pageIndex = Math.Min(dto.PageIndex, pages);
            int pass = (pageIndex - 1) * dto.PageSize;
            p.Add("pass", pass);
            p.Add("pageSize", dto.PageSize);

            return new PageResult<ServerPageItem>
            {
                Status = 200,
                Msg = "请求成功",
                PageIndex = pageIndex,
                PageSize = dto.PageSize,
                Total = count,
                Pages = pages,
                Data = await DBContext.QueryListAsync<ServerPageItem>($"{list} {limit}", p)
            };
        }
    }
}
