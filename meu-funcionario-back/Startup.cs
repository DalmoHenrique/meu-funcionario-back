using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using meu_funcionario_back.Data;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace meu_funcionario_back
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
            /**
             * Utilizar do SQL Server junto com o uso da Connect String para conectar com o banco de dados
             */
            services.AddDbContextPool<FuncionarioContext>(
                option => option.UseSqlServer("Integrated Security=SSPI;Persist Security Info=False;Initial Catalog=MeuFuncionarioDB;Data Source=localhost\\MSSQLLocalDB"));


            // Não causar bloqueio nas requisições da API por conta do Cors. Além de ser adicionado o mesmo precisa ser executado no método de Configure abaixo, setando como 'UseCors'
            services.AddCors(options => {
                options.AddDefaultPolicy(
                    builder =>
                    {
                        builder.AllowAnyHeader().AllowAnyMethod().AllowAnyOrigin();
                    });

            });

            services.AddControllers();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseRouting();

            // Utilizar o Cors
            app.UseCors();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
