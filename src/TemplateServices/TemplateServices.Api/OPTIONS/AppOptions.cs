using $ext_safeprojectname$Services.Common.Options.Base;


namespace $safeprojectname$.Options;


public class AppOptions
{
    /// <summary>
    /// Настройка подключения к API Partners
    /// </summary>
    public ApiConnectionOptions PartnersApiService { get; init; }

    /// <summary>
    /// Настройка подключения к БД $ext_safeprojectname$
    /// </summary>
    public DbConnectionOptions $ext_safeprojectname$StorageDbService { get; init; }



    /// <summary>
    /// Название приложения
    /// </summary>
    public string ServiceName { get; init; }

    /// <summary>
    /// Постфикс базового адреса сервиса
    /// </summary>
    public string HostPostfix { get; set; } = string.Empty;

    /// <summary>
    /// Настройки для подключения к сервису AccessAPI
    /// </summary>
    public AccessContextOptions AccessContext { get; init; }
}