using $safeprojectname$.Options;
using KatServices.Common.Configuration;


namespace $safeprojectname$.Configuration;


/// <summary>
/// Расширения для интеграции PartnersApiService в приложение
/// </summary>
public static class PartnersApiServiceConfigurationHostingExtensions
{
    #region Методы

    public static IHostApplicationBuilder AddPartnersApiServiceInApp(this IHostApplicationBuilder builder, AppOptions appOptions)
    {
        builder.Services.AddPartnersApiServiceInApp(appOptions.PartnersApiService);

        return builder;
    }

    #endregion Методы
}