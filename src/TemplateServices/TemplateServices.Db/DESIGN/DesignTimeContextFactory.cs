using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using $safeprojectname$.Context;


namespace $safeprojectname$.Design;


/// <summary>
/// Фабрика для создания DbContext при создании миграций из Package Manager Console в DesignTime
/// </summary>
public class DesignTimeContextFactory : IDesignTimeDbContextFactory<$ext_safeprojectname$DbContext>
{
    public $ext_safeprojectname$DbContext CreateDbContext(string[] args)
    {
        var optionsBuilder = new DbContextOptionsBuilder<$ext_safeprojectname$DbContext>();
        optionsBuilder
            .UseNpgsql()
            .EnableSensitiveDataLogging()
            .EnableDetailedErrors();


        return new $ext_safeprojectname$DbContext(optionsBuilder.Options);
    }
}