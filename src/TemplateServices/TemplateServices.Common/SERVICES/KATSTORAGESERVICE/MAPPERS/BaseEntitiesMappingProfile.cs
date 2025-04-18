using AutoMapper;
using $ext_safeprojectname$Services.Db.Entities;


namespace $safeprojectname$.Services.$ext_safeprojectname$StorageService.Mappers;


public class BaseEntitiesMappingProfile : Profile
{
    public BaseEntitiesMappingProfile()
    {
        CreateMap<MyAwesomeProductBase, MyAwesomeProduct>();
    }
}