using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using GraphQL_API.DatabaseHelper;
using GraphQL_API.Server.Resolvers;
using HotChocolate;
using GraphQL_API.Server.Schema;
using HotChocolate.AspNetCore;
using HotChocolate.Types;

namespace GraphQL_API.Server
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
            services.CreateSingletonForEachAdapter(Program.Configuration.GetValue<string>("PostgresConnect"));
            
            services.AddDataLoaderRegistry()
                .AddGraphQL(sp => HotChocolate.Schema.Create(c => 
                {
                    c.RegisterServiceProvider(sp)
                        .Options.UseXmlDocumentation = true;

                    c.RegisterQueryType<QueryType>();

                    c.RegisterType<AccountType>()
                        .RegisterType<ContractType>()
                        .RegisterType<DeviceType>()
                        .RegisterType<LegalPersonType>()
                        .RegisterType<PhysicalPersonType>();
                }));

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            app.UseWebSockets();

            app
                .UseGraphQLHttpPost()
                .UseGraphiQL();

            app.UseHttpsRedirection();
        }
    }
}
