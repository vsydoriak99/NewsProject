using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using NewsProject.DAL.Database;
using NewsProject.DAL.Repo.NewsRepo;
using GraphiQl;
using GraphQL;
using GraphQL.Types;
using NewsProject.GraphqlAPI.Queries;
using NewsProject.GraphqlAPI.Schema;
using NewsProject.GraphqlAPI.Types;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Newtonsoft;
using Microsoft.Extensions.Logging;
using NewsProject.GraphqlAPI.Mutation;

namespace NewsProject.GraphqlAPI
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

            services.AddScoped<IDependencyResolver>(_ => new FuncDependencyResolver(_.GetRequiredService));
            services.Configure<MongoSettings>(options => Configuration.GetSection("MongoConfig").Bind(options));

            services.AddControllersWithViews()
    .AddNewtonsoftJson(options =>
    options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore
);
            
            services.AddScoped<IDependencyResolver>(_ => new FuncDependencyResolver(_.GetRequiredService));
            services.AddTransient<IMongoDBContext, MongoDBContext>();
            services.AddTransient<INewsRepository, NewsRepository>();
            services.AddSingleton<IDocumentExecuter, DocumentExecuter>();
            services.AddSingleton<NewsQuery>();
            services.AddSingleton<NewsMutation>();
            services.AddSingleton<NewsType>();
            services.AddScoped<ISchema, NewsSchema>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseGraphiQl();

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
