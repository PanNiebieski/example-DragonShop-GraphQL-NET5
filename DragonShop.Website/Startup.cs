using DragonShop.Website.Clients;
using GraphQL.Client.Abstractions;
using GraphQL.Client.Http;
using GraphQL.Client.Serializer.Newtonsoft;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Net.Http;

namespace DragonShop.Website
{
    public class Startup
    {
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddHttpClient("DragonHttpClient", client =>
            {
                client.BaseAddress = new Uri("https://localhost:5001/graphql");
                client.Timeout = new TimeSpan(0, 0, 30);
                client.DefaultRequestHeaders.Clear();
            });

            services.AddScoped<IGraphQLClient>
            ((service) =>
            {

                var f = service.GetRequiredService<IHttpClientFactory>();
                var opt = new GraphQLHttpClientOptions();

                return new GraphQLHttpClient(opt,
                                new NewtonsoftJsonSerializer(),
                                f.CreateClient("DragonHttpClient"));
            }
            );


            services.AddScoped<DragonGraphClientFromNuget>();
            services.AddScoped<DragonHttpClient>();
            services.AddControllersWithViews();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseStaticFiles();

            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute("default", "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
