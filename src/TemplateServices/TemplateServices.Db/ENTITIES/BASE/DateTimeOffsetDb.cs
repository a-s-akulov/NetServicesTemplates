namespace $safeprojectname$.Entities.Base;


public class DateTimeOffsetDb
{
    public DateTimeOffsetDb()
    { }


    public DateTimeOffsetDb(DateTimeOffset dateTimeOffset)
    {
        DateTimeUtc = dateTimeOffset.UtcDateTime;
        TimeZoneOffset = dateTimeOffset.Offset.Hours;
    }

    public DateTimeOffset DateTimeUtc { get; init; }

    public int TimeZoneOffset { get; init; }

    public DateTimeOffset ToDateTimeOffset() => DateTimeUtc.ToOffset(TimeSpan.FromHours(TimeZoneOffset));
}