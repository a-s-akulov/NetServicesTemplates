using ChiTech.NET.OpenTelemetry.Configuration;


namespace KatServices.ScheduleJobs.Configuration;


public static class OpenTelemetryConfigurationHostingExtensions
{
    public static IHostApplicationBuilder AddOpenTelemetryInApp(this IHostApplicationBuilder builder)
    {
        builder.AddChiTechOpenTelemetry(otOptions => otOptions
            .AddAspNetCoreInstrumentation()
            .AddHttpClientInstrumentation()
            .AddSqlClientInstrumentation()
        );


        return builder;
    }
}
