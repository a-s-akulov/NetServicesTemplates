using Microsoft.Extensions.DependencyInjection;
using $safeprojectname$.Options.Base;
using Microsoft.EntityFrameworkCore;
using KatServices.Db.Context;
using $safeprojectname$.Services.KatStorageService;
using $safeprojectname$.Services.KatStorageService.Repository;


namespace $safeprojectname$.Configuration;


/// <summary>
/// Расширения для интеграции KatStorageDbService в приложение
/// </summary>
public static class KatStorageDbServiceConfigurationHostingExtensions
{
    #region Методы

    public static IServiceCollection AddKatStorageDbServiceInApp(this IServiceCollection services, DbConnectionOptions dbConnectionOptions)
    {
        services.AddSingleton<IKatStorageService, KatStorageDbService>();

        var connectionString = string.Format(
            dbConnectionOptions.ConnectionString,
            dbConnectionOptions.Username,
            dbConnectionOptions.Password
        );

        services.AddDbContextFactory<KatDbContext>(opt =>
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

    #endregion Методы
}