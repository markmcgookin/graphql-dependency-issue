using GraphQL.Server;
using GraphQL.Server.Ui.Playground;
using graphql_dependency_issue.graphql;
using graphql_dependency_issue.model;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace graphql_dependency_issue
{
    public class Startup
    {
        public IConfiguration Configuration { get; }
        public IWebHostEnvironment Environment { get; }

        public Startup(IConfiguration configuration, IWebHostEnvironment env)
        {
            Configuration = configuration;
            Environment = env;
        }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();

            //GraphQL 
            //services.AddScoped<IDependencyResolver>(s => new FuncDependencyResolver(s.GetRequiredService));
            services.AddScoped<CoreSchema>();
            services.AddScoped<TempDBContext>();
            services.AddSingleton<EmployerMessagingService>();

            services.AddGraphQL(o => { o.ExposeExceptions = Environment.IsDevelopment(); })
                .AddGraphTypes(ServiceLifetime.Scoped)
                .AddSystemTextJson()
                .AddDataLoader()
                .AddWebSockets();
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

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });

            //Graphql
            app.UseGraphQLWebSockets<CoreSchema>("/graphql");
            app.UseGraphQL<CoreSchema>();
            app.UseGraphQLPlayground(new GraphQLPlaygroundOptions());
        }
    }
}
