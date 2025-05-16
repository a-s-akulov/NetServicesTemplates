using App.Metrics;
using App.Metrics.AspNetCore;
using App.Metrics.Formatters.Prometheus;


namespace $safeprojectname$.Configuration;


public static class MetricsConfigurationHostingExtensions
{
    public static IServiceCollection AddMetricsInApp(this IServiceCollection services, IHostBuilder hostBuilder)
    {
        var metrics = AppMetrics.CreateDefaultBuilder()
            .OutputMetrics.AsPrometheusPlainText()
            .Build();

        services.AddMetrics(metrics);
        services.AddMetricsEndpoints();
        services.AddAppMetricsSystemMetricsCollector();

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