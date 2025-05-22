using App.Metrics;
using App.Metrics.AspNetCore;
using App.Metrics.Formatters.Prometheus;
using $safeprojectname$.Configuration.Metrics.CustomMetrics;


namespace $safeprojectname$.Configuration;


public static class MetricsConfigurationHostingExtensions
{
    public static IServiceCollection AddMetricsInApp(this IServiceCollection services, IHostBuilder hostBuilder, bool enable$ext_safeprojectname$StorageDataMetricsCollector = false)
    {
        var metrics = AppMetrics.CreateDefaultBuilder()
            .OutputMetrics.AsPrometheusPlainText()
            .Build();

        services.AddMetrics(metrics);
        services.AddMetricsEndpoints();
        services.AddAppMetricsSystemMetricsCollector();

        if (enable$ext_safeprojectname$StorageDataMetricsCollector)
            services.AddAppMetrics$ext_safeprojectname$StorageDataMetricsCollector();

 
        hostBuilder.UseMetrics((hostContext, opt) =>
        {
        });

        hostBuilder.UseMetricsWebTracking((hostContext, opt) =>
        {
        });

        hostBuilder.UseMetricsEndpoints(opt =>
        {
            opt.MetricsEndpointOutputFormatter
                = metrics.OutputMetricsFormatters.OfType<MetricsPrometheusTextOutputFormatter>().First();
        });


        return services;
    }
}