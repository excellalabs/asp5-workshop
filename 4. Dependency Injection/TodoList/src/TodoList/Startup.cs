using Autofac;
using Autofac.Dnx;
using Microsoft.AspNet.Builder;
using Microsoft.AspNet.Http;
using Microsoft.Framework.DependencyInjection;
using TodoList.Services.Impl;
using System;

namespace TodoList
{
    public class Startup
    {
        // Use built-in IoC Container
        //public void ConfigureServices(IServiceCollection services)
        //{
        //    services.AddMvc();
        //    services.AddTransient<ITodoListProvider, TodoListProvider>();

        //    // services.AddSingleton<ITodoListProvider, TodoListProvider>();
        //    // services.AddScoped<ITodoListProvider, TodoListProvider>();

        //    // var specificListProvider = new TodoListProvider();
        //    // services.AddInstance<ITodoListProvider>(specificListProvider);
        //}

        // Use another IoC Container
        public IServiceProvider ConfigureServices(IServiceCollection services)
        {
            services.AddMvc();
            return this.ConfigureAutofac(services);

            //services.AddTransient<ITodoListProvider, TodoListProvider>();
            //return services.BuildServiceProvider();
        }

        public IServiceProvider ConfigureAutofac(IServiceCollection services)
        {
            // Pull this out into your other methods or modules if it gets too big
            var builder = new ContainerBuilder();
            builder.RegisterType<TodoListProvider>().As<ITodoListProvider>();

            // Register the services that were previously registered with the built in DI
            builder.Populate(services);

            var container = builder.Build();
            return container.Resolve<IServiceProvider>();
        }

        /* Boileplate code generated with new app
        public void Configure(IApplicationBuilder app)
        {
            app.Run(async (context) =>
            {
                await context.Response.WriteAsync("Hello World!");
            });
        }
        --- */

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
