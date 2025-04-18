using $safeprojectname$.Options;
using $ext_safeprojectname$Services.Common.Configuration;


namespace $safeprojectname$.Configuration;


/// <summary>
/// Расширения для интеграции PartnersApiService в приложение
/// </summary>
public static class PartnersApiServiceConfigurationHostingExtensions
{
    public static IHostApplicationBuilder AddPartnersApiServiceInApp(this IHostApplicationBuilder builder, AppOptions appOptions)
    {
        builder.Services.AddPartnersApiServiceInApp(appOptions.PartnersApiService);

        return builder;
    }
}