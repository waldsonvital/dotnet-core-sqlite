using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using superprojeto.Models;

namespace superprojeto
{
    public class Startup
    {
        public IConfigurationRoot Configuration { get; set; }
        public Startup(IHostingEnvironment env){
            var buider = new ConfigurationBuilder()
                            .SetBasePath(env.ContentRootPath)
                            .AddJsonFile("config.json");

            Configuration = buider.Build();
        }

        public void ConfigureServices(IServiceCollection service){
            
            service.AddMvc();
            service.AddDbContext<ProdutoContext>(
                options => options.UseMySql(Configuration["mysql"])
            );

        }
        
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory log){
            app.UseDeveloperExceptionPage();
            
            var DB = app.ApplicationServices.GetRequiredService<ProdutoContext>();
            DB.Database.EnsureCreated();

            app.UseMvcWithDefaultRoute();
        }
    }
}