using Microsoft.EntityFrameworkCore.Design;
using Microsoft.EntityFrameworkCore.Migrations.Design;
using $ext_safeprojectname$Services.Db.Design;


namespace $safeprojectname$.Design;


/// <summary>
/// Design-time EF core services configuration
/// </summary>
public class AppEFCoreDesignTimeServices : IDesignTimeServices
{
    public void ConfigureDesignTimeServices(IServiceCollection services)
    {
        services.AddSingleton<ICSharpMigrationOperationGenerator, AppCSharpMigrationOperationGenerator>();
    }
}