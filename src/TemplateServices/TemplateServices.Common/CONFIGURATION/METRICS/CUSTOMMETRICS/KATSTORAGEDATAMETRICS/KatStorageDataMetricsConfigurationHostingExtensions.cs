using $safeprojectname$.Configuration.Metrics.CustomMetrics.$ext_safeprojectname$StorageDataMetrics;


namespace $safeprojectname$.Configuration.Metrics.CustomMetrics;


public static class $ext_safeprojectname$StorageDataMetricsConfigurationHostingExtensions
{
    public static IServiceCollection AddAppMetrics$ext_safeprojectname$StorageDataMetricsCollector(this IServiceCollection services, Action<$ext_safeprojectname$StorageDataMetricsCollectorOptions>? optionsSetup = null)
    {
        var collectorOptions = new $ext_safeprojectname$StorageDataMetricsCollectorOptions();
        optionsSetup?.Invoke(collectorOptions);
        services.AddSingleton(Microsoft.Extensions.Options.Options.Create(collectorOptions));

        services.AddHostedService<$ext_safeprojectname$StorageDataMetricsCollectorHostedService>();


        return services;
    }
}
