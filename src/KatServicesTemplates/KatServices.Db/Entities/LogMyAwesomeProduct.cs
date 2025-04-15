using KatServices.Db.Entities.Base;


namespace KatServices.Db.Entities;


public class LogMyAwesomeProduct : MyAwesomeProductBase, ILogEntity<MyAwesomeProduct>
{
    /// <inheritdoc/>
    public Guid LogId { get; set; }

    /// <inheritdoc/>
    public DateTime ChangedDate { get; set; }

    /// <inheritdoc/>
    public enLogOperation ChangedOperation { get; set; }

    /// <inheritdoc/>
    public MyAwesomeProduct? Entity { get; set; }
}