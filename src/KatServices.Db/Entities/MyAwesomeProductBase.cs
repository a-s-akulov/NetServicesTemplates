

namespace KatServices.Db.Entities;


public abstract class MyAwesomeProductBase
{
    /// <summary>
    /// ID
    /// </summary>
    public Guid Id { get; set; }

    /// <summary>
    /// Название продукта
    /// </summary>
    public string Name { get; set; } = string.Empty;

    /// <summary>
    /// Тип продукта
    /// </summary>
    public enAwesomeProductType ProductType { get; set; }
}
