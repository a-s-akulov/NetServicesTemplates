using AutoMapper;
using $safeprojectname$.DTO.V1.MyAwesomeProducts;
using KatServices.Db.Entities;


namespace $safeprojectname$.RequestHandlers.V1.MyAwesomeProducts.Mappers;


public class MyAwesomeProductDtoMappingProfile : Profile
{
    public MyAwesomeProductDtoMappingProfile()
    {
        CreateMap<MyAwesomeProductToPut, MyAwesomeProduct>();
    }
}