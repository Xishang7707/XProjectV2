using Collections.LinuxCollections;
using Infrastruct.Configs;
using Infrastruct.DB;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using PublishService.ServerPublish;
using ServerManager.Boot;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;
using XProjectV2.Middlewares;

namespace XProjectV2
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddSignalR();
            services.AddControllers();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "XProjectV2", Version = "v1" });
            });
            services.AddCors(options =>
            {
                options.AddPolicy("any", builder =>
                {
                    builder.SetIsOriginAllowed(_ => true).AllowAnyMethod().AllowAnyHeader().AllowCredentials();
                });
            });
            services.AddSingleton<DBConfig>();
            services.AddSingleton<DBContext>();
            
            NativeBoot.Register(services);
            Queries.Boot.NativeBoot.Register(services);
            Collections.Boot.NativeBoot.Register(services);
            PublishService.Boot.NativeBoot.Register(services);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, IServiceScopeFactory serviceScopeFactory)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "XProjectV2 v1"));
            }
            app.UseCors("any");
            app.UseRouting();
            app.UseMiddleware<ExceptionMiddleware>();
            app.UseAuthorization();

            //Task.Run(() =>
            //{
            //    using var scope = serviceScopeFactory.CreateScope();
            //    scope.ServiceProvider.GetRequiredService<LinuxRuntimeService>().Start();
            //});
            
            Task.Run(() =>
            {
                using var scope = serviceScopeFactory.CreateScope();
                scope.ServiceProvider.GetRequiredService<ServerPublisher>().Start();
            });

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapHub<ServerPublishHub>("/servertopic");
                endpoints.MapControllers();
            });
        }
    }
}
