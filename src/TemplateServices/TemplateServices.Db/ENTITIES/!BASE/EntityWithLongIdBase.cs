namespace $safeprojectname$.Entities.Base;


public abstract class EntityWithLongIdBase : IEntityWithLongId
{
    /// <inheritdoc/>
    public long Id { get; set; }
}