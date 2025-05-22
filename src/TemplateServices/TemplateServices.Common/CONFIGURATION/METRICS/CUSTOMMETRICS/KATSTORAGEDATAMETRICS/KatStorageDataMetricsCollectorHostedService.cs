using App.Metrics;
using AutoMapper;
using Microsoft.Extensions.Options;
using System.Diagnostics;
using $safeprojectname$.Services.Base;
using $safeprojectname$.Services.$ext_safeprojectname$StorageService;


namespace $safeprojectname$.Configuration.Metrics.CustomMetrics.$ext_safeprojectname$StorageDataMetrics;



public class $ext_safeprojectname$StorageDataMetricsCollectorHostedService : ServiceBase, IHostedService, IDisposable
{

    #region Поля

    private readonly IMetrics _metrics;
    private readonly $ext_safeprojectname$StorageDataMetricsCollectorOptions _options;
    private readonly I$ext_safeprojectname$StorageService _storageService;

    private Timer? _timer = null;
    private CancellationTokenSource? _cancellationTokenSource = null;

    #endregion Поля


    #region Конструкторы

    public $ext_safeprojectname$StorageDataMetricsCollectorHostedService(I$ext_safeprojectname$StorageService storageService, IOptions<$ext_safeprojectname$StorageDataMetricsCollectorOptions> options, IMetrics metrics, ILogger<$ext_safeprojectname$StorageDataMetricsCollectorHostedService> logger, IMapper mapper, ActivitySource activitySource) : base(logger, mapper, activitySource)
    {
        _storageService = storageService;
        _options = options.Value;
        _metrics = metrics;
    }

    #endregion Конструкторы


    #region Свойства



    #endregion Свойства


    #region Методы

    public void Dispose()
    {
        _timer?.Dispose();
    }


    public Task StartAsync(CancellationToken cancellationToken)
    {
        _timer = new Timer(CollectData, null, 1000, _options.CollectIntervalMilliseconds);

        return Task.CompletedTask;
    }


    public Task StopAsync(CancellationToken cancellationToken)
    {
        _timer?.Change(-1, -1);

        return _cancellationTokenSource?.CancelAsync() ?? Task.CompletedTask;
    }


    private async void CollectData(object? state)
    {
        using var tracingActivity = Trace.StartActivity(name: "Collect$ext_safeprojectname$StorageDataMetrics");

        try
        {
            _cancellationTokenSource = new CancellationTokenSource();
            var storageMetrics = await _storageService.GetStorageDataMetrics(cancellationToken: _cancellationTokenSource.Token).ConfigureAwait(false);
            
            _metrics.Measure.Gauge.SetValue($ext_safeprojectname$StorageDataMetricsRegistry.MyAwesomeProductsAllCount, storageMetrics.MyAwesomeProductsAllCount);
            _metrics.Measure.Gauge.SetValue($ext_safeprojectname$StorageDataMetricsRegistry.MyAwesomeProductsBooksAllCount, storageMetrics.MyAwesomeProductsBooksAllCount);
            _metrics.Measure.Gauge.SetValue($ext_safeprojectname$StorageDataMetricsRegistry.MyAwesomeProductsFoodAllCount, storageMetrics.MyAwesomeProductsFoodAllCount);
            _metrics.Measure.Gauge.SetValue($ext_safeprojectname$StorageDataMetricsRegistry.MyAwesomeProductsCarsAllCount, storageMetrics.MyAwesomeProductsCarsAllCount);
        }
        catch (Exception ex)
        {
            var exception = new ScopedException("Failed to collect $ext_safeprojectname$ storage data metrics", ex, nameof($ext_safeprojectname$StorageDataMetricsCollectorHostedService));
            tracingActivity?.SetStatus(ActivityStatusCode.Error, description: exception.ToString());
            Log.LogError(exception, "Failed to collect $ext_safeprojectname$ storage data metrics");
        }
    }

    #endregion Методы
}



public class $ext_safeprojectname$StorageDataMetricsCollectorOptions
{
    /// <summary>
    /// Collect interval in milliseconds
    /// </summary>
    public int CollectIntervalMilliseconds { get; set; } = 10 * 60 * 1000; // 10 минут
}