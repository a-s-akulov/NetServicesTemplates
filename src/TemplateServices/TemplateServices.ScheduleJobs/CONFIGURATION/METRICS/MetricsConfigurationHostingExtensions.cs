using $ext_safeprojectname$Services.Common.Configuration;


namespace $safeprojectname$.Configuration;


public static class MetricsConfigurationHostingExtensions
{
    public static IHostApplicationBuilder AddMetricsInApp(this WebApplicationBuilder builder)
    {
        builder.Services.AddMetricsInApp(builder.Host, enable$ext_safeprojectname$StorageDataMetricsCollector: true);


        return builder;
    }
}