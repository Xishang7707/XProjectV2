using Core.Models.Results;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XProjectV2.Middlewares
{
    public class ExceptionMiddleware
    {
        private readonly RequestDelegate Next;
        public ExceptionMiddleware(RequestDelegate next)
        {
            Next = next;
        }
        public async Task Invoke(HttpContext context)
        {
            try
            {
                await Next.Invoke(context);
            }
            catch (Exception ex)
            {
                var setting = new JsonSerializerSettings
                {
                    ContractResolver = new CamelCasePropertyNamesContractResolver()  //使用驼峰样式
                };
                var result = new RespResult
                {
                    Status = 400,
                    Msg = ex.Message
                };
                string body = JsonConvert.SerializeObject(result, setting);
                byte[] bodys = Encoding.UTF8.GetBytes(body);

                context.Response.StatusCode = 400;
                context.Response.ContentType = "application/json;charset=utf-8";
                await context.Response.Body.WriteAsync(bodys);
            }
        }
    }
}
