using Microsoft.EntityFrameworkCore;
using $safeprojectname$.Entities;


namespace $safeprojectname$.Context;


public class KatDbContext : DbContext
{
    public KatDbContext(DbContextOptions<KatDbContext> options)
        : base(options)
    { }


    public virtual DbSet<MyAwesomeProduct> MyAwesomeProducts { get; set; }



    public virtual DbSet<LogMyAwesomeProduct> LogMyAwesomeProducts { get; set; }


    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfiguration(new Configurations.MyAwesomeProductConfiguration());

        modelBuilder.ApplyConfiguration(new Configurations.LogMyAwesomeProductConfiguration());
    }
}
