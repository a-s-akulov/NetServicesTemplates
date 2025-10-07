using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using $safeprojectname$.Entities.Base;


namespace $safeprojectname$.Context.Configurations.Base;


public static class DateTimeOffsetBaseConfiguration
{
    public static OwnedNavigationBuilder ConfigureAtomic(OwnedNavigationBuilder entityBuilder, string columnPrefix)
    {
        entityBuilder.Property(nameof(DateTimeOffsetDb.DateTimeUtc)).HasColumnName($"{columnPrefix}date_time_utc");
        entityBuilder.Property(nameof(DateTimeOffsetDb.TimeZoneOffset)).HasColumnName($"{columnPrefix}time_zone_offset");
        
        return entityBuilder;
    }
}