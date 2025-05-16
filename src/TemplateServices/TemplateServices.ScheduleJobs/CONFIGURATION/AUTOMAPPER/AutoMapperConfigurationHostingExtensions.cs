using $ext_safeprojectname$Services.Common.Configuration;


namespace $safeprojectname$.Configuration;


public static class AutoMapperConfigurationHostingExtensions
{
    public static IHostApplicationBuilder AddAutoMapperInApp(this IHostApplicationBuilder builder)
    {
        builder.Services.AddAutoMapperInApp();


        return builder;
    }
}
