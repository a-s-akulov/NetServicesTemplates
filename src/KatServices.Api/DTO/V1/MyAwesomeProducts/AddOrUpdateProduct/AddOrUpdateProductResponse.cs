using KatServices.Db.Entities;


namespace KatServices.Api.DTO.V1.MyAwesomeProducts;


public class AddOrUpdateProductResponse
{
    /// <summary>
    /// Обновленный продукт
    /// </summary>
    public MyAwesomeProduct Product { get; set; }
}
