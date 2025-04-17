using $safeprojectname$.Entities.Base;


namespace $safeprojectname$.Entities;


public class MyAwesomeProduct : MyAwesomeProductBase, IEntityWithLogs<LogMyAwesomeProduct>
{
    /// <inheritdoc/>>
    public ICollection<LogMyAwesomeProduct> Logs { get; set; } = [];
}