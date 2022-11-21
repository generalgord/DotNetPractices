namespace BestPractices.Api.Extensions
{
    public static class HealthCheckConfigureExt
    {
        public static IApplicationBuilder UseCustomHealthCheck(this IApplicationBuilder app)
        {
            app.UseHealthChecks("/api/health", new Microsoft.AspNetCore.Diagnostics.HealthChecks.HealthCheckOptions()
            {
                ResponseWriter = async (context, report) =>
                {
                    await context.Response.WriteAsync("OK");
                }
            });
            return app;
        }
    }
}
