namespace $safeprojectname$.Options.Base;


/// <summary>
/// Базовая конфигурации приложения
/// </summary>
public abstract class BaseAppOptions
{
    /// <summary>
    /// Название приложения
    /// </summary>
    public virtual string ServiceName { get; init; }

    /// <summary>
    /// Постфикс базового адреса сервиса
    /// </summary>
    public virtual string HostPostfix { get; init; } = string.Empty;
}