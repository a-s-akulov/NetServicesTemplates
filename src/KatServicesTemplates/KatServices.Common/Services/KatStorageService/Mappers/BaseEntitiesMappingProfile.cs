using AutoMapper;
using KatServices.Db.Entities;


namespace KatServices.Common.Services.KatStorageService.Mappers;


public class BaseEntitiesMappingProfile : Profile
{
    public BaseEntitiesMappingProfile()
    {
        CreateMap<MyAwesomeProductBase, MyAwesomeProduct>();
    }
}