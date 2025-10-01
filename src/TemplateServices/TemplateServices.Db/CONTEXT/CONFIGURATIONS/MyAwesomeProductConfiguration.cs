using $safeprojectname$.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;


namespace $safeprojectname$.Context.Configurations;


public class MyAwesomeProductConfiguration : IEntityTypeConfiguration<MyAwesomeProduct>
{
    public void Configure(EntityTypeBuilder<MyAwesomeProduct> entity)
    {
        entity.ToTable("my_awesome_products");
        entity.HasKey(e => e.Id);

        ConfigureAtomic(entity);

        entity.HasMany(e => e.Logs)
            .WithOne(e => e.Entity)
            .HasForeignKey(e => e.Id)
            .WithNoDatabaseForeignKey();
    }


    public static void ConfigureAtomic(EntityTypeBuilder entityBuilder)
    {
        entityBuilder.Property(nameof(MyAwesomeProduct.Id)).HasColumnName("id");
        entityBuilder.Property(nameof(MyAwesomeProduct.Name)).HasColumnName("name");
        entityBuilder.Property(nameof(MyAwesomeProduct.ProductType)).HasColumnName("product_type");
    }
}
