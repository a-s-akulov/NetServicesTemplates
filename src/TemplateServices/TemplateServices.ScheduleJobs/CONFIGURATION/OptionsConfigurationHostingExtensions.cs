using $safeprojectname$.Options;
using $ext_safeprojectname$Services.Common.Configuration;


namespace $safeprojectname$.Configuration;


public static class OptionsConfigurationHostingExtensions
{
    public static AppOptions ConfigureOptions(this IHostApplicationBuilder builder)
    {
        var appOptions = builder.Services.ConfigureOptions<AppOptions>(builder.Configuration);


        return appOptions;
    }
}
