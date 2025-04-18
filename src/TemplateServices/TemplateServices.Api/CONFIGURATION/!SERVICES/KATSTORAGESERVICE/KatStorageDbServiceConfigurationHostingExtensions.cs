using $safeprojectname$.Options;
using $ext_safeprojectname$Services.Common.Configuration;


namespace $safeprojectname$.Configuration;


/// <summary>
/// Расширения для интеграции $ext_safeprojectname$StorageDbService в приложение
/// </summary>
public static class $ext_safeprojectname$StorageDbServiceConfigurationHostingExtensions
{
    public static IHostApplicationBuilder Add$ext_safeprojectname$StorageDbServiceInApp(this IHostApplicationBuilder builder, AppOptions appOptions)
    {
        builder.Services.Add$ext_safeprojectname$StorageDbServiceInApp(appOptions.$ext_safeprojectname$StorageDbService);

        return builder;
    }
}