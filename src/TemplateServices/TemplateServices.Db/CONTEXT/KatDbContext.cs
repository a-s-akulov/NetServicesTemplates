using Microsoft.EntityFrameworkCore;
using $safeprojectname$.Context.Base;
using $safeprojectname$.Entities;


namespace $safeprojectname$.Context;


public class $ext_safeprojectname$DbContext : BaseLoggingEntitiesDbContext
{
    public $ext_safeprojectname$DbContext(DbContextOptions options)
        : base(options)
    { }


    public virtual DbSet<MyAwesomeProduct> MyAwesomeProducts { get; set; }



    public virtual DbSet<LogMyAwesomeProduct> LogMyAwesomeProducts { get; set; }


    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfiguration(new Configurations.MyAwesomeProductConfiguration());

        modelBuilder.ApplyConfiguration(new Configurations.LogMyAwesomeProductConfiguration());
    }
    

    protected override object ConvertEntityToLog(object entity, Type sourceType, Type destinationType) => throw new InvalidOperationException("Auto logging is not implemented here");
}
