using System;
using System.IO;
using Micro.PlatformService.AsyncDataServices;
using Micro.PlatformService.Data;
using Micro.PlatformService.SyncDataServices.Grpc;
using Micro.PlatformService.SyncDataServices.Http;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;

namespace Micro.PlatformService
{
    public class Startup
    {
        public IConfiguration Configuration { get; }
        private readonly IHostEnvironment _env;
        public Startup(IConfiguration configuration, IHostEnvironment env)
        {
            Configuration = configuration;
            _env = env;
        }

        public void ConfigureServices(IServiceCollection services)
        {
            if (_env.IsDevelopment())
            {
                Console.WriteLine("--> InMemDB using...");
                services.AddDbContext<AppDbContext>(options =>
                    options.UseInMemoryDatabase("InMemDB")); //This will be used at development enviroment. When we move on to production stage at Kubernetes, we will switch to SqlServer.
            }
            else
            {
                Console.WriteLine("--> Sql Server using...");
                services.AddDbContext<AppDbContext>(options =>
                    options.UseSqlServer(Configuration.GetConnectionString("PlatformSqlConnection")));
            }
            services.AddScoped<IPlatformRepo, PlatformRepo>();
            services.AddSingleton<IMessageBusClient, MessageBusClient>();
            services.AddHttpClient<ICommandDataClient, HttpCommandDataClient>();
            services.AddGrpc();
            services.AddControllers();
            services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "Micro.PlatformService", Version = "v1" });
            });

            Console.WriteLine($"--> Commands Service endpoint:{Configuration["CommandService"]}");
        }
        public void Configure(IApplicationBuilder app)
        {
            if (_env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "Micro.PlatformService v1"));
            }

            //app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
                endpoints.MapGrpcService<GrpcPlatformService>();
                // This is for serve up proto file to client as contract.(Optional)
                endpoints.MapGet("/Protos/platforms.proto", async context =>
                {
                    await context.Response.WriteAsync(File.ReadAllText("Protos/platforms.proto"));
                });
            });

            PrepDb.PrepPopulation(app, _env.IsProduction());
        }
    }
}
