using ChiTech.NET.OpenTelemetry.Configuration;


namespace $safeprojectname$.Configuration;


public static class OpenTelemetryConfigurationHostingExtensions
{
    public static IHostApplicationBuilder AddOpenTelemetryInApp(this IHostApplicationBuilder builder)
    {
        builder.AddChiTechOpenTelemetry(otOptions => otOptions
            .AddAspNetCoreInstrumentation()
            .AddHttpClientInstrumentation()
            .AddSqlClientInstrumentation()
            .AddPostgreSqlInstrumentation()
        );


        return builder;
    }
}
