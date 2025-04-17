using AutoMapper;
using KatServices.Db.Entities;


namespace $safeprojectname$.Services.KatStorageService.Mappers;


public class BaseEntitiesMappingProfile : Profile
{
    public BaseEntitiesMappingProfile()
    {
        CreateMap<MyAwesomeProductBase, MyAwesomeProduct>();
    }
}