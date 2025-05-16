using $ext_safeprojectname$Services.Common.Configuration;


namespace $safeprojectname$.Configuration;


public static class ControllersConfigurationHostingExtensions
{
    public static IHostApplicationBuilder AddControllersInApp(this IHostApplicationBuilder builder)
    {
        builder.Services.AddControllersInApp();


        return builder;
    }
}
