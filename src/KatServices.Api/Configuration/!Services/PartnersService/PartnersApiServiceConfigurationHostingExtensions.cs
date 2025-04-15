using KatServices.Api.Options;
using KatServices.Common.Configuration;


namespace KatServices.Api.Configuration;


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