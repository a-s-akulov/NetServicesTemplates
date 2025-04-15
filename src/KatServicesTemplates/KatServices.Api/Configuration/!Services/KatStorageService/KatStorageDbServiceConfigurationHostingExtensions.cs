using KatServices.Api.Options;
using KatServices.Common.Configuration;


namespace KatServices.Api.Configuration;


/// <summary>
/// Расширения для интеграции KatStorageDbService в приложение
/// </summary>
public static class KatStorageDbServiceConfigurationHostingExtensions
{
    public static IHostApplicationBuilder AddKatStorageDbServiceInApp(this IHostApplicationBuilder builder, AppOptions appOptions)
    {
        builder.Services.AddKatStorageDbServiceInApp(appOptions.KatStorageDbService);

        return builder;
    }
}