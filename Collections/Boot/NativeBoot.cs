using Collections.LinuxCollections;
using Collections.LinuxCollections.Repo.Repository;
using Infrastruct.DB;
using Microsoft.Extensions.DependencyInjection;

namespace Collections.Boot
{
    public class NativeBoot
    {
        public static void Register(IServiceCollection services)
        {
            services.AddScoped<CollectionContext>();
            services.AddScoped<ServerRuntimeRepostory>();
            services.AddScoped<LinuxRuntimeService>();
        }
    }
}
