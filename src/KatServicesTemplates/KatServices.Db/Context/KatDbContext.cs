using Microsoft.EntityFrameworkCore;
using KatServices.Db.Entities;


namespace KatServices.Db.Context;


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
