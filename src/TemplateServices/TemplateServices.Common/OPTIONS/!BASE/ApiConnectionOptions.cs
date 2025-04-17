namespace $safeprojectname$.Options.Base;


/// <summary>
/// Конфигурация соединения с API
/// </summary>
public class ApiConnectionOptions : BaseConnectionOptions
{
    #region Свойства

    /// <summary>
    /// УРЛ хоста API
    /// </summary>
    public string Host { get; init; } = string.Empty;

    /// <summary>
    /// Ключ авторизации
    /// </summary>
    public string ApiKey { get; init; } = string.Empty;

    #endregion Свойства
}
