using AutoMapper;
using System.Diagnostics;


namespace $safeprojectname$.Services.Base;


public abstract class ServiceBase
{
    #region Конструкторы

    public ServiceBase(ILogger logger, IMapper mapper, ActivitySource activitySource)
    {
        Log = logger;
        Map = mapper;
        Trace = activitySource;
    }

    #endregion Конструкторы


    #region Свойства

    /// <summary>
    /// Логгер
    /// </summary>
    protected ILogger Log { get; }

    /// <summary>
    /// Поставщик маппинга сущностей
    /// </summary>
    protected IMapper Map { get; }

    /// <summary>
    /// Поставщик трассировки
    /// </summary>
    protected ActivitySource Trace { get; }



    /// <summary>
    /// Текущая системная дата и время (UTC)
    /// </summary>
    protected DateTime NowSystemDate => DateTime.UtcNow; // UTC

    #endregion Свойства


    #region Методы

    protected Exception HandleOperationException(Exception ex, string exceptionScope, Activity? tracingActivity)
    {
        var exception = new ScopedException(ex, exceptionScope);
        tracingActivity?.SetStatus(ActivityStatusCode.Error, description: exception.ToString());
        Log.LogError(exception, ex.Message);
        return exception;
    }

    #endregion Методы
}
