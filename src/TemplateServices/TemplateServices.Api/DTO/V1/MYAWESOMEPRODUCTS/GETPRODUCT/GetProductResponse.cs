using KatServices.Db.Entities;


namespace $safeprojectname$.DTO.V1.MyAwesomeProducts;


public class GetProductResponse
{
    /// <summary>
    /// Найденный продукт
    /// </summary>
    public MyAwesomeProduct? Product { get; set; }
}
