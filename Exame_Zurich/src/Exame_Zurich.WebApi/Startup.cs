using Exame_Zurich.App.SeguroApp;
using Exame_Zurich.Domain.Repositorio;
using Exame_Zurich.Infra.Repositorio;
using Exame_Zurich.ServicesExt;
using Exame_Zurich.ServicesExt.Repositorio;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System.IO;

namespace Exame_Zurich.WebApi
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public static IConfiguration Configuration { get; set; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);

            var builder = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json");

            Configuration = builder.Build();
            services.AddMvc();

            services.AddResponseCompression();

            services.AddTransient<ISeguroRep, SeguroRep>();
            services.AddTransient<ISeguradoRep, SeguradoService>();
            services.AddTransient<SeguroApp, SeguroApp>();



        }

  
        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseMvc();
        }
    }
}
