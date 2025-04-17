using Microsoft.Extensions.Options;
using System.Text.Json;


namespace $safeprojectname$.Services.JsonSerializerService.Repository;


public class SystemTextJsonSerializerService : IJsonSerializerService
{
    #region Поля

    private readonly JsonSerializerOptions _jsonSerializerOptions;

    #endregion Поля


    #region Конструкторы

    public SystemTextJsonSerializerService(IOptions<JsonSerializerOptions> jsonSerializerOptions)
    {
        _jsonSerializerOptions = jsonSerializerOptions.Value;
    }

    #endregion Конструкторы


    #region Методы

    public string Serialize<TValue>(TValue value)
    {
        return JsonSerializer.Serialize(value, options: _jsonSerializerOptions);
    }


    public TValue? Deserialize<TValue>(string json)
    {
        return JsonSerializer.Deserialize<TValue>(json);
    }

    #endregion Методы
}
