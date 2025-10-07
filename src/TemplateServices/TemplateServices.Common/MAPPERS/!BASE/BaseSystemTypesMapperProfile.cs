using AutoMapper;
using $ext_safeprojectname$Services.Db.Entities.Base;


namespace $safeprojectname$.Mappers.Base;


public class BaseSystemTypesMapperProfile : Profile
{
    public BaseSystemTypesMapperProfile()
    {
        CreateMap<DateTime, DateTimeOffsetDb>()
            .ConvertUsing(static (src, _) => new DateTimeOffsetDb(src));
        CreateMap<DateTimeOffsetDb, DateTime>()
            .ConvertUsing(static (src, _) => src.ToDateTimeOffset().DateTime);

        CreateMap<DateTimeOffset, DateTimeOffsetDb>()
            .ConvertUsing(static (src, _) => new DateTimeOffsetDb(src));
        CreateMap<DateTimeOffsetDb, DateTimeOffset>()
            .ConvertUsing(static (src, _) => src.ToDateTimeOffset());
    }
}