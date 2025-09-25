using Microsoft.Extensions.DependencyInjection;
using $safeprojectname$.Options.Base;
using Microsoft.EntityFrameworkCore;
using $safeprojectname$.Services.$ext_safeprojectname$StorageService;
using $safeprojectname$.Services.$ext_safeprojectname$StorageService.Repository;


namespace $safeprojectname$.Configuration;


/// <summary>
/// Расширения для интеграции $ext_safeprojectname$StorageDbService в приложение
/// </summary>
public static class $ext_safeprojectname$StorageDbServiceConfigurationHostingExtensions
{
    public static IServiceCollection Add$ext_safeprojectname$StorageDbServiceInApp(this IServiceCollection services, DbConnectionOptions dbConnectionOptions)
    {
        services.AddSingleton<I$ext_safeprojectname$StorageService, $ext_safeprojectname$StorageDbService > ();

        var connectionString = string.Format(
            dbConnectionOptions.ConnectionString,
            dbConnectionOptions.Username,
            dbConnectionOptions.Password
        );

        services.AddDbContextFactory<$ext_safeprojectname$AutoMapperConverterContext> (opt =>
        {
            opt.UseNpgsql(
                    connectionString,
                    sqlOpt =>
                    {
                        sqlOpt.CommandTimeout(30);
                    }
                )
                .EnableDetailedErrors();
        });


        return services;
    }
}