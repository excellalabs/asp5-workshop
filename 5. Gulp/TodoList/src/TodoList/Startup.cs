using Autofac;
using Autofac.Dnx;
using Microsoft.AspNet.Builder;
using Microsoft.AspNet.Http;
using Microsoft.Framework.DependencyInjection;
using TodoList.Services.Impl;
using System;
using Microsoft.Framework.ConfigurationModel;
using Microsoft.AspNet.Hosting;
using TodoList.Dal;

namespace TodoList
{
    public class Startup
    {
        public IConfiguration Configuration { get; set; }

        public Startup(IHostingEnvironment env)
        {
            // Setup configuration sources.
            Configuration = new Configuration()
                .AddJsonFile("config.json")
                .AddEnvironmentVariables();
        }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc();
            services.AddTransient<ITodoListProvider, TodoListProvider>();
            services.AddTransient<ITodoItemAppContext, TodoItemAppContext>();

            var connectionString = Configuration.Get("Data:DefaultConnection:ConnectionString");

            services.AddEntityFramework()
                .AddSqlServer()
                .AddDbContext<TodoItemAppContext>();
        }


        public void Configure(IApplicationBuilder app)
        {
            app.UseMvc();

            app.Use(async (context, next) =>
            {
                await context.Response.WriteAsync("Hello world!");
                await next();
            });

            app.Use(async (context, next) =>
            {
                await context.Response.WriteAsync(" This is sort of an echo Hello world!");
            });
        }
    }
}
