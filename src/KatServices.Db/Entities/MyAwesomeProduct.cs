using KatServices.Db.Entities.Base;


namespace KatServices.Db.Entities;


public class MyAwesomeProduct : MyAwesomeProductBase, IEntityWithLogs<LogMyAwesomeProduct>
{
    /// <inheritdoc/>>
    public ICollection<LogMyAwesomeProduct> Logs { get; set; } = [];
}