using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;
using $safeprojectname$.Options.Base;


namespace $safeprojectname$.Configuration;


public static class OptionsConfigurationHostingExtensions
{
    public static TOptions ConfigureOptions<TOptions>(this IServiceCollection services, IConfigurationManager configuration) where TOptions : BaseAppOptions
    {
        configuration
            .AddJsonFile(
                Path.Combine("config", "appsettings.json"),
                optional: false,
                reloadOnChange: false
            )
            .AddEnvironmentVariables();


        var appOptions = configuration.Get<TOptions>() ?? throw new Exception($"Failed to configure {nameof(TOptions)}");
        services.AddSingleton(Microsoft.Extensions.Options.Options.Create<TOptions>(appOptions));


        return appOptions;
    }
}
