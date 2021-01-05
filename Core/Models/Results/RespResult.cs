using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Core.Models.Results
{
    public class RespResult : IActionResult
    {
        public int Status { get; set; }
        public string Msg { get; set; }

        public async Task ExecuteResultAsync(ActionContext context)
        {
            var setting = new JsonSerializerSettings
            {
                ContractResolver = new CamelCasePropertyNamesContractResolver()  //使用驼峰样式
            };
            context.HttpContext.Response.StatusCode = 200;
            context.HttpContext.Response.ContentType = "application/json;charset=utf-8";

            string body = JsonConvert.SerializeObject(this, setting);
            byte[] bodys = Encoding.UTF8.GetBytes(body);
            await context.HttpContext.Response.Body.WriteAsync(bodys);
        }
    }
}
