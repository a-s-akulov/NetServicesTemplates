namespace $safeprojectname$.Entities.Base;


public interface IEntityWithGuidId
{
    /// <summary>
    /// Идентификатор сущности
    /// </summary>
    public Guid Id { get; set; }
}