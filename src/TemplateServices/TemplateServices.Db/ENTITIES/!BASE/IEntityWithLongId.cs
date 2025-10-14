namespace $safeprojectname$.Entities.Base;


public interface IEntityWithLongId
{
    /// <summary>
    /// Идентификатор сущности
    /// </summary>
    public long Id { get; set; }
}