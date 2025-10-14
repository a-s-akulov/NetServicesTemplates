using $safeprojectname$.Entities.Base;


namespace $safeprojectname$.Entities;


public abstract class MyAwesomeProductBase : EntityWithLongIdBase
{
    /// <summary>
    /// Название продукта
    /// </summary>
    public string Name { get; set; } = string.Empty;

    /// <summary>
    /// Тип продукта
    /// </summary>
    public enAwesomeProductType ProductType { get; set; }
}
