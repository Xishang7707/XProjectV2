using Microsoft.Extensions.DependencyInjection;
using PublishService.ServerPublish;
using PublishService.ServerPublish.Repo.Repository;

namespace PublishService.Boot
{
    public class NativeBoot
    {
        public static void Register(IServiceCollection services)
        {
            services.AddScoped<ServerPublishHub>();
            services.AddScoped<ServerRuntimeRepostory>();
            services.AddScoped<ServerPublisher>();
        }
    }
}
