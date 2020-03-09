using ClienteCaixa.Data.InMemory;
using graphiql;
using GraphQL;
using GraphQL.Types;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using OperacaoCaixa.Api.Helpers;
using OperacaoCaixa.Api.Models;
using OperacaoCaixa.Core.Data;
using OperacaoCaixa.Data;
using OperacaoCaixa.Data.Repositories;
using System.Collections.Generic;

namespace OperacaoCaixa.Api
{
    public class Startup
    {
        private IHostingEnvironment Env { get; set; }
        public IConfiguration Configuration { get; }

        public Startup(IHostingEnvironment env)
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(env.ContentRootPath)
                .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
                .AddJsonFile($"appsettings.{env.EnvironmentName}.json", optional: true)
                .AddEnvironmentVariables();
            Configuration = builder.Build();
            Env = env;
        }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc();
           
            services.AddHttpContextAccessor();

            services.AddTransient<IPessoaRepository, PessoaRepository>();
            services.AddTransient<IContaClienteRepository, ContaClienteRepository>();
            services.AddTransient<IContaSaldoRepository, ContaSaldoRepository>();
            services.AddTransient<IContaOperacaoRepository, ContaOperacaoRepository>();
            services.AddScoped<IDocumentExecuter, DocumentExecuter>();

            services.AddScoped<ContextServiceLocator>();
            services.AddScoped<OperacaoCaixaQuery>();
            services.AddScoped<GraphQLQuery>();
            services.AddScoped<OperacaoCaixaMutation>();
            services.AddScoped<ClienteType>();
            services.AddScoped<ContaSaldoType>();
            services.AddScoped<ContaOperacaoType>();
            services.AddScoped<ContaOperacaoInputType>();
            services.AddScoped<ContaOperacaoOutputType>();

            //services.AddDbContext<OperacaoCaixaContext>(options => options.UseSqlServer(Configuration["ConnectionStrings:OperacaoCaixaDb"]));

            if (Env.IsEnvironment("Development"))
            {
                services.AddDbContext<OperacaoCaixaContext>(options =>
                    options.UseInMemoryDatabase(databaseName: "operacao"));
            }
            else
            {
                services.AddDbContext<OperacaoCaixaContext>(options =>
                    options.UseMySql(Configuration["ConnectionStrings:OperacaoCaixaDb"]));
            }

            var sp = services.BuildServiceProvider();
            services.AddSingleton<ISchema>(new OperacaoCaixaSchema(new FuncDependencyResolver(type => sp.GetService(type))));
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, ILoggerFactory loggerFactory, IHostingEnvironment env, OperacaoCaixaContext db)
        {
            loggerFactory.AddConsole(Configuration.GetSection("Logging"));
            loggerFactory.AddDebug();

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseGraphiQl();
            app.UseMvc();
            db.EnsureSeedData();
        }
    }
}
