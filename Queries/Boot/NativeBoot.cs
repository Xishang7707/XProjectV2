using Infrastruct.DB;
using Microsoft.Extensions.DependencyInjection;

namespace Queries.Boot
{
    public class NativeBoot
    {
        public static void Register(IServiceCollection services)
        {
            services.AddScoped<QueryContext>();
            services.AddScoped<ServerQuery>();
        }
    }
}
