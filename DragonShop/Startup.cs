using DragonShop.Api.GraphQL;
using DragonShop.Infrastructure.Persitence;
using GraphQL.Server;
using GraphQL.Utilities;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Server.Kestrel.Core;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace DragonShop.Api
{


    public class Startup
    {
        public IConfiguration Configuration { get; }



        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }


        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc();
            services.AddDragonPersitence(Configuration);

            services.AddScoped<DragonSchema>();

            services.AddGraphQL((o, p) =>
           {
               var logger = p.GetRequiredService<ILogger<Startup>>();
               o.UnhandledExceptionDelegate = ctx =>
                   logger.LogError("{Error} occurred", ctx.OriginalException.Message);

           })

             .AddGraphTypes(ServiceLifetime.Scoped)
             .AddUserContextBuilder(httpContext => new GraphQLUserContext { User = httpContext.User })
             .AddDataLoader()
             .AddNewtonsoftJson();

            // If using Kestrel:
            services.Configure<KestrelServerOptions>(options =>
            {
                options.AllowSynchronousIO = true;
            });

            // If using IIS:
            services.Configure<IISServerOptions>(options =>
            {
                options.AllowSynchronousIO = true;
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        //public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        //{
        //    if (env.IsDevelopment())
        //    {
        //        app.UseDeveloperExceptionPage();
        //    }

        //    app.UseRouting();

        //    app.UseEndpoints(endpoints =>
        //    {
        //        endpoints.MapGet("/", async context =>
        //        {
        //            await context.Response.WriteAsync("Hello World!");
        //        });
        //    });
        //}

        public void Configure(IApplicationBuilder app, DragonShopDbContext dbContext)
        {
            app.UseGraphQL<DragonSchema>();
            app.UseGraphQLPlayground();
            dbContext.Seed();

        }
    }
}
