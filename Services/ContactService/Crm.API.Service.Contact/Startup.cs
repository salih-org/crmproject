using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Crm.API.Service.Contact.Data.Context;
using Crm.API.Service.Contact.Services.Interfaces;
using Crm.API.Service.Contact.Services.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace Crm.API.Services.Contact
{
    public class Startup
    {
        private ILogger<Startup> logger;

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();


            services.AddLogging();

            services.AddDbContext<CrmDbContext>(conf =>
            {
                conf.UseNpgsql(Configuration.GetConnectionString("Postgresql"), builder =>
                {
                    builder.EnableRetryOnFailure(5, TimeSpan.FromSeconds(2), null);
                });
            });

            services.AddScoped<IContactService, ContactService>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, ILogger<Startup> Logger)
        {
            logger = Logger;

            logger.LogWarning("ConnStr: " + Configuration.GetConnectionString("Postgresql"));

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            //app.UseHttpsRedirection();

            app.UseRouting();


            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
