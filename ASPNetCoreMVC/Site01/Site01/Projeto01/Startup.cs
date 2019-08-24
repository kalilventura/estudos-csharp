using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Projeto01.Database;

namespace Projeto01
{
    public class Startup
    {
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc();
            services.AddDbContext<DatabaseContext>(options =>
            {
                options.UseSqlServer(@"Server=localhost\SQLEXPRESS;Database=site01;Integrated Security=True;Trusted_Connection=True;");
            });
            services.AddDistributedMemoryCache();
            services.AddSession();
        }
        
        
        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            /**
             * www.site.com/Cliente/listar (Lista todos os clientes)
            *  www.site.com/Cliente/deletar/30 (Deleta o cliente 30)
            *  www.site.com/Cliente/vizualizar/30 (Vizualizar o Cliente com o id 30)
            *  www.site.com/noticias/visualizar/acidentes-de-carros-nas-rodovias
            *  {domain}/{Controller}/{Action}/{Id?}
             */

            app.UseSession();

            app.UseStaticFiles();
            app.UseMvcWithDefaultRoute();
            /*
            app.Run(async (context) =>
            {
                await context.Response.WriteAsync("Hello World!");
            });*/
        }
    }
}
