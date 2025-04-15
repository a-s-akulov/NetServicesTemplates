using AutoMapper;
using KatServices.Api.DTO.V1.MyAwesomeProducts;
using KatServices.Db.Entities;


namespace KatServices.Api.RequestHandlers.V1.MyAwesomeProducts.Mappers;


public class MyAwesomeProductDtoMappingProfile : Profile
{
    public MyAwesomeProductDtoMappingProfile()
    {
        CreateMap<MyAwesomeProductToPut, MyAwesomeProduct>();
    }
}