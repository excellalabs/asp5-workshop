using Microsoft.AspNet.Builder;
using Microsoft.AspNet.Http;
using Microsoft.Framework.DependencyInjection;

namespace TodoList
{
    public class Startup
    {
        public void ConfigureServices(IServiceCollection services)
        {
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
