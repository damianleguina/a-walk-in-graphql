using GraphQL;
using GraphQL.Server.Ui.Playground;
using GraphQL.Types;
using GraphQLNetCore.Api.GraphQL;
using GraphQLNetCore.Api.GraphQL.Types;
using GraphQLNetCore.Data;
using GraphQLNetCore.Data.Repositories;
using GraphQLNetCore.Data.Repositories.Interfaces.Entities;
using GraphQLNetCore.DatabaseSeedHelper;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace GraphQLNetCore.Api
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers().AddNewtonsoftJson(options => options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore);
            services.AddDbContext<GraphQLContext>(options => options.UseInMemoryDatabase(databaseName: "GraphQLDb"), ServiceLifetime.Singleton);
            services.AddSingleton<ISkillRepository, SkillRepository>();
            services.AddSingleton<IPersonRepository, PersonRepository>();
            services.AddSingleton<IDocumentExecuter, DocumentExecuter>();
            services.AddSingleton<RootQuery>();
            services.AddSingleton<SkillType>();
            services.AddSingleton<PersonType>();
            services.AddSingleton<ISchema>(s => new GraphQLSchema(new FuncDependencyResolver(type => (IGraphType)s.GetRequiredService(type))));
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.SeedDatabase();

            app.UseGraphQLPlayground(new GraphQLPlaygroundOptions());

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}