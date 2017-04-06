using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.EntityFrameworkCore;
using superprojeto.Models;

namespace superprojeto
{
    public class Startup
    {
        public IConfigurationRoot Configuration { get; set; }

        public Startup(IHostingEnvironment env){
            var builder = new ConfigurationBuilder()
                                .SetBasePath(env.ContentRootPath)
                                .AddJsonFile("configs.json");
            
            Configuration = builder.Build();
        }

        public void ConfigureServices(IServiceCollection service){
            
            service.AddMvc();
            service.AddDbContext<ProdutoContext>(
                options => options.UseMySql(Configuration["connection"])
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