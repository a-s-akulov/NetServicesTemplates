using KatServices.Db.Entities;


namespace KatServices.Api.DTO.V1.MyAwesomeProducts;


public class GetProductsResponse
{
    /// <summary>
    /// Список найденных продуктов
    /// </summary>
    public ICollection<MyAwesomeProduct> Products { get; set; } = [];
}
