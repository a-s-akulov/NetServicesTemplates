using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using $safeprojectname$.Context.Configurations.Base;
using $safeprojectname$.Entities;


namespace $safeprojectname$.Context.Configurations;


public class LogMyAwesomeProductConfiguration : LogEntityConfiguration<LogMyAwesomeProduct>
{
    protected override void ConfigurePartial(EntityTypeBuilder<LogMyAwesomeProduct> entity)
    {
        entity.ToTable("log_my_awesome_products");
        entity.HasIndex(e => e.Id);

        MyAwesomeProductConfiguration.ConfigureAtomic(entity);
    }
}
