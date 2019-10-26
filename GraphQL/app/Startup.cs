using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using app.Database;
using app.GraphQL;
using app.GraphQL.Interfaces;
using GraphiQl;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace app {
    public class Startup {
        public Startup (IConfiguration configuration) {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices (IServiceCollection services) {

            services.AddDbContext<StoreContext> ();
            services.AddScoped<StoreContext, StoreContext> ();
            services.AddScoped<IMySchema, MySchema> ();
            services.AddControllers ();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure (IApplicationBuilder app, IWebHostEnvironment env) {
            if (env.IsDevelopment ()) {
                Seed.SeedDatabase ();
                app.UseDeveloperExceptionPage ();
            }

            app.UseHttpsRedirection ();

            app.UseRouting ();

            app.UseAuthorization ();

            app.UseGraphiQl ("/graphql");

            app.UseEndpoints (endpoints => {
                endpoints.MapControllers ();
            });
        }
    }
}