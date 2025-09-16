using $safeprojectname$.Options;
using $ext_safeprojectname$Services.Common.Configuration;


namespace $safeprojectname$.Configuration;


public static class DistributedCacheConfigurationHostingExtensions
{
    public static IHostApplicationBuilder AddDistributedCacheInApp(this IHostApplicationBuilder builder, AppOptions appOptions)
    {
        builder.Services.AddDistributedCacheInApp(appOptions.DistributedCache);


        return builder;
    }
}