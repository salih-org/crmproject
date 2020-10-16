using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Crm.API.Service.Common.EventBusConsumers;
using Crm.API.Service.Reservation.Data.Context;
using Crm.API.Service.Reservation.Service.Interfaces;
using Crm.API.Service.Reservation.Service.Services;
using MassTransit;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace Crm.API.Service.Reservation
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
            services.AddMassTransit(x =>
            {
                x.AddConsumer<EventContactConsumer>();

                x.AddBus(provider => Bus.Factory.CreateUsingRabbitMq(cfg =>
                {
                    cfg.UseHealthCheck(provider);
                    cfg.Host("rabbitmq://s_rabbitmq");

                    cfg.ReceiveEndpoint("test_queue", ep => 
                    {
                        ep.PrefetchCount = 16;
                        ep.ConfigureConsumer<EventContactConsumer>(provider);
                    });
                }));
            });

            services.AddControllers();


            services.AddLogging();

            services.AddDbContext<ReservationDbContext>(conf =>
            {
                conf.UseNpgsql(Configuration.GetConnectionString("Postgresql"), builder =>
                {
                    builder.EnableRetryOnFailure(5, TimeSpan.FromSeconds(2), null);
                });
            });

            services.AddScoped<IReservationService, ReservationService>();
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
