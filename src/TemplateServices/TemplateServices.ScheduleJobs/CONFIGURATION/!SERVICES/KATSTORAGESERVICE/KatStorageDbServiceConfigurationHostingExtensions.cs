using $safeprojectname$.Options;
using KatServices.Common.Configuration;


namespace $safeprojectname$.Configuration;


/// <summary>
/// Расширения для интеграции KatStorageDbService в приложение
/// </summary>
public static class KatStorageDbServiceConfigurationHostingExtensions
{
    #region Методы

    public static IHostApplicationBuilder AddKatStorageDbServiceInApp(this IHostApplicationBuilder builder, AppOptions appOptions)
    {
        builder.Services.AddKatStorageDbServiceInApp(appOptions.KatStorageDbService);

        return builder;
    }

    #endregion Методы
}