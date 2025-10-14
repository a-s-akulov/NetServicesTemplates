using $ext_safeprojectname$Services.Db.Entities;

namespace $safeprojectname$.DTO.V1.MyAwesomeProducts;


public class GetProductsRequest : ApiRequest
{
    /// <summary>
    /// Фильтры запроса
    /// </summary>
    public GetProductsRequestFilters? Filters { get; set; }
}


public class GetProductsRequestFilters
{
    /// <summary>
    /// Идентификаторы продуктов
    /// </summary>
    public ICollection<long>? Ids { get; set; }


    /// <summary>
    /// Типы продуктов
    /// </summary>
    public ICollection<enAwesomeProductType?>? ProductTypes { get; set; }
}