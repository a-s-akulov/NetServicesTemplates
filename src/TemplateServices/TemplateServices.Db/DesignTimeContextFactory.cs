using Microsoft.EntityFrameworkCore.Design;
using Microsoft.EntityFrameworkCore;
using $safeprojectname$.Context;


namespace $safeprojectname$;


/// <summary>
/// Фабрика для создания DbContext при создании миграций из Package Manager Console в DesignTime
/// </summary>
public class DesignTimeContextFactory : IDesignTimeDbContextFactory<$ext_safeprojectname$DbContext>
{
    public $ext_safeprojectname$DbContext CreateDbContext(string[] args)
    {
        var optionsBuilder = new DbContextOptionsBuilder<$ext_safeprojectname$DbContext>();
        optionsBuilder.UseNpgsql();

        return new $ext_safeprojectname$DbContext(optionsBuilder.Options);
    }
}