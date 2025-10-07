using AutoMapper;
using $ext_safeprojectname$Services.Db.Entities;


namespace $safeprojectname$.Services.$ext_safeprojectname$StorageService.Mappers;


public class LogsMappingProfile : Profile
{
    private static readonly LogChangedDateValueResolver _logChangedDateValueResolver = new();


    public LogsMappingProfile()
    {
        CreateMap<MyAwesomeProduct, LogMyAwesomeProduct>()
            .ForMember(dst => dst.ChangedDate, opt => opt.MapFrom(_logChangedDateValueResolver));
    }
}


public class LogChangedDateValueResolver : IValueResolver<object, object, DateTimeOffset>
{
    public DateTimeOffset Resolve(object src, object dst, DateTimeOffset _, ResolutionContext context)
    {
        return DateTimeOffset.UtcNow;
    }
}