using $ext_safeprojectname$Services.Common.Options.Base;


namespace $safeprojectname$.Options;


public class AppOptions : BaseAppOptions
{    
    /// <summary>
    /// Настройка распределённого кеша
    /// </summary>
    public DistributedCacheOptions DistributedCache { get; init; }


    /// <summary>
    /// Настройка подключения к API Partners
    /// </summary>
    public ApiConnectionOptions PartnersApiService { get; init; }

    /// <summary>
    /// Настройка подключения к БД $ext_safeprojectname$
    /// </summary>
    public DbConnectionOptions $ext_safeprojectname$StorageDbService { get; init; }

    /// <summary>
    /// Настройка подключения к БД для Quartz
    /// </summary>
    public DbConnectionOptions QuartzDbService { get; init; }



    /// <summary>
    /// Настройка джобы MyAwesomeProductsImport
    /// </summary>
    public ScheduleJobOptions MyAwesomeProductsImportJob { get; init; }


    /// <summary>
    /// Настройки для подключения к сервису AccessAPI
    /// </summary>
    public AccessContextOptions AccessContext { get; init; }
}