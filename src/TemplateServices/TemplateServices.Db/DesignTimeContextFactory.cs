using Microsoft.EntityFrameworkCore.Design;
using Microsoft.EntityFrameworkCore;
using $safeprojectname$.Context;


namespace $safeprojectname$;


/// <summary>
/// Фабрика для создания DbContext при создании миграций из Package Manager Console в DesignTime
/// </summary>
public class DesignTimeContextFactory : IDesignTimeDbContextFactory<KatDbContext>
{
    public KatDbContext CreateDbContext(string[] args)
    {
        var optionsBuilder = new DbContextOptionsBuilder<KatDbContext>();
        optionsBuilder.UseNpgsql();

        return new KatDbContext(optionsBuilder.Options);
    }
}