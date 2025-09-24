using System.Linq.Expressions;


namespace $safeprojectname$.Mappers.Base;


public static class CommonValueTransformers
{
    public static Expression<Func<DateTime, DateTime>> DateTimeToUtc = static src => src.ToUniversalTime();
    public static Expression<Func<DateTime?, DateTime?>> DateTimeToUtcNullable = static src => src == null ? null : src.Value.ToUniversalTime();
    public static Expression<Func<DateTimeOffset, DateTimeOffset>> DateTimeOffsetToUtc = static src => src.ToUniversalTime();
    public static Expression<Func<DateTimeOffset?, DateTimeOffset?>> DateTimeOffsetToUtcNullable = static src => src == null ? null : src.Value.ToUniversalTime();
}