using AccessApi.ClientLibCore.Helpers;
using AccessApi.ClientLibCore.Model;
using KatServices.Api.Auth;
using KatServices.Api.Options;


namespace KatServices.Api.Configuration;


public static class AccessApiConfigurationHostingExtensions
{
    public static IHostApplicationBuilder AddAccessApiAuthenticationInApp(this IHostApplicationBuilder builder, AppOptions options)
    {
        Action<AccessApiAuthSchemeOptions> optionsBuilder = o =>
        {
            o.UrlPasswordAuth = options.AccessContext.UrlPasswordAuth;
            o.UrlWindowsAuth = options.AccessContext.UrlWindowsAuth;
            o.ApplicationName = options.AccessContext.ApplicationName;
            o.ApplicationActions = Enum.GetValues<enAppAction>().ToDictionary(x => (int)x, x => x.GetDescription());
        };

        builder.Services
            .AddAuthentication(AccessApiAuthSchemas.APIKEY)
            .AddAccessApiKey(optionsBuilder, ServiceLifetime.Singleton)
            .AddAccessApiBasic(optionsBuilder, ServiceLifetime.Singleton);

        return builder;
    }
}
