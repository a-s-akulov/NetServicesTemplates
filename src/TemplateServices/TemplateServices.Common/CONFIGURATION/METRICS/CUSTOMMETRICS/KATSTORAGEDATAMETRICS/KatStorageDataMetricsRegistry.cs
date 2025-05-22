using App.Metrics;
using App.Metrics.Gauge;


namespace $safeprojectname$.Configuration.Metrics.CustomMetrics.$ext_safeprojectname$StorageDataMetrics;


public static class $ext_safeprojectname$StorageDataMetricsRegistry
{
    private static readonly string _contextName = "$ext_safeprojectname$ storage data";




    public static readonly GaugeOptions MyAwesomeProductsAllCount = new GaugeOptions
    {
        Context = _contextName,
        Name = "My awesome products all count",
        MeasurementUnit = Unit.Items
    };


    public static readonly GaugeOptions MyAwesomeProductsBooksAllCount = new GaugeOptions
    {
        Context = _contextName,
        Name = "My awesome products food all count",
        MeasurementUnit = Unit.Items
    };


    public static readonly GaugeOptions MyAwesomeProductsFoodAllCount = new GaugeOptions
    {
        Context = _contextName,
        Name = "My awesome products food all count",
        MeasurementUnit = Unit.Items
    };


    public static readonly GaugeOptions MyAwesomeProductsCarsAllCount = new GaugeOptions
    {
        Context = _contextName,
        Name = "My awesome products cars all count",
        MeasurementUnit = Unit.Items
    };
}
