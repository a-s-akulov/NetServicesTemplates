using $ext_safeprojectname$Services.Db.Entities;


namespace $safeprojectname$.DTO.V1.MyAwesomeProducts;


public class GetProductsResponse
{
    /// <summary>
    /// Список найденных продуктов
    /// </summary>
    public ICollection<MyAwesomeProduct> Products { get; set; } = [];
}
