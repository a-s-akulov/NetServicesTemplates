namespace $safeprojectname$.Entities.Base;


public abstract class EntityWithGuidIdBase : IEntityWithGuidId
{
    /// <inheritdoc/>
    public Guid Id { get; set; }
}