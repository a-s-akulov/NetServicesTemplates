namespace $safeprojectname$.DTO.V1.MyAwesomeProducts;


public class DeleteProductRequest : ApiRequest
{
    /// <summary>
    /// ID Продукта
    /// </summary>
    public Guid Id { get; set; }
}