using AutoMapper;
using $safeprojectname$.DTO.V1.MyAwesomeProducts;
using $ext_safeprojectname$Services.Db.Entities;


namespace $safeprojectname$.RequestHandlers.V1.MyAwesomeProducts.Mappers;


public class MyAwesomeProductDtoMappingProfile : Profile
{
    public MyAwesomeProductDtoMappingProfile()
    {
        CreateMap<MyAwesomeProductToPut, MyAwesomeProduct>();
    }
}