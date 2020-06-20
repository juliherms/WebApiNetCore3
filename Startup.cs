using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Shop.Data;

namespace Shop
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
            services.AddControllers(); //habilita os controllers
            //services.AddDbContext<DataContext>(opt => opt.UseInMemoryDatabase("Database")); //adiciona minha database em memória
            services.AddDbContext<DataContext>(opt => opt.UseSqlServer(Configuration.GetConnectionString("connectionString"))); //uso do sql server.
            services.AddScoped<DataContext, DataContext>(); //add dependencia e garante que só tenho 1 por conexao
            
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                //exibe mais detalhe do erro em tempo de execução.
                app.UseDeveloperExceptionPage();
            }

            //força a nossa API a responder via https
            app.UseHttpsRedirection();

            //utiliza o padrão de rotas
            app.UseRouting();

            //autorização com roles
            app.UseAuthorization();

            //exposicao dos endpoins
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
