using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Diagnostics.HealthChecks;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Crm.API.Gateway.Extensions
{
    public static class HealthCheckConfigurationExtension
    {
        public static IApplicationBuilder UseCustomHealthCheck(this IApplicationBuilder app)
        {
            app.UseHealthChecks("/health", getHealthCheckOptions());

            return app;
        }

        private static HealthCheckOptions getHealthCheckOptions()
        {
            return new HealthCheckOptions
            {
                ResponseWriter = async (context, report) =>
                {
                    await context.Response.WriteAsync("OK");
                }
            };
        }
    }
}
