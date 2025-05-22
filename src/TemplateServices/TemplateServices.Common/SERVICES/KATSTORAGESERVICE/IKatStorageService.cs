using $ext_safeprojectname$Services.Db.Entities;


namespace $safeprojectname$.Services.$ext_safeprojectname$StorageService;


/// <summary>
/// Сервис хранилища данных $ext_safeprojectname$
/// </summary>
public interface I$ext_safeprojectname$StorageService
{
    #region MyAwesomeProduct

    /// <summary>
    /// Получить метрики данных из хранилища
    /// </summary>
    public Task<StorageDataMetrics> GetStorageDataMetrics(CancellationToken cancellationToken = default);

    /// <summary>
    /// Добавить или обновить базовую информацию о продукте
    /// </summary>
    public Task<TryAddOrUpdateBaseResult<MyAwesomeProduct>> TryAddOrUpdate(MyAwesomeProductBase recordToSet, CancellationToken cancellationToken = default);

    /// <summary>
    /// Получить продукты
    /// </summary>
    public Task<List<MyAwesomeProduct>> GetMyAwesomeProducts(ICollection<Guid>? idsFilter = null, ICollection<enAwesomeProductType?>? productTypesFilter = null, bool includeReferences = false, bool includeLogs = false, CancellationToken cancellationToken = default);

    /// <summary>
    /// Удалить продукт
    /// </summary>
    public Task<bool> DeleteMyAwesomeProduct(Guid id, CancellationToken cancellationToken = default);

    #endregion MyAwesomeProduct
}
