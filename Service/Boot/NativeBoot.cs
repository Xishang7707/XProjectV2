using Microsoft.Extensions.DependencyInjection;
using ServerManager.Repo.Repository;
using ServerManager.Service;
using ServerManager.Service.Implememts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServerManager.Boot
{
    public class NativeBoot
    {
        public static void Register(IServiceCollection services)
        {
            services.AddScoped<ServerManagerRepository>();
            services.AddScoped<IServerManagerService, ServerManagerService>();
        }
    }
}
