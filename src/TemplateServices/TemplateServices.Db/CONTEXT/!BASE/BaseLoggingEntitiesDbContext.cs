using Microsoft.EntityFrameworkCore;
using System.Collections.Concurrent;
using System.Diagnostics.CodeAnalysis;
using System.Reflection;
using $safeprojectname$.Entities.Base;


namespace $safeprojectname$.Context.Base;


public abstract class BaseLoggingEntitiesDbContext : DbContext
{
    #region Поля

    private static readonly Type _entityWithLogsInterfaceType = typeof(IEntityWithLogs<>);
    private static readonly ConcurrentDictionary<string, RecordRelatedReflectionInfo> _entitiesRelatedReflectionInfoCache = new();

    #endregion Поля


    #region Конструкторы

    protected BaseLoggingEntitiesDbContext(DbContextOptions options)
        : base(options)
    { }

    #endregion Конструкторы


    #region Свойства

    /// <summary>
    /// Включено ли автоматическое создание записей логов для сущностей
    /// </summary>
    public virtual bool IsAutoLoggingForEntitiesEnabled => false;

    #endregion Свойства


    #region Методы

    #region Public

    /// <inheritdoc/>
    public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
    {
        if (IsAutoLoggingForEntitiesEnabled)
            HandleEntitiesLogs();


        return base.SaveChangesAsync(cancellationToken: cancellationToken);
    }


    /// <inheritdoc/>
    public override int SaveChanges()
    {
        if (IsAutoLoggingForEntitiesEnabled)
            HandleEntitiesLogs();


        return base.SaveChanges();
    }

    #endregion Public


    private void HandleEntitiesLogs()
    {
        foreach (var entry in ChangeTracker.Entries())
        {
            switch (entry.State)
            {
                case EntityState.Added:
                    TryAddLogEntity(entry.Entity, enLogOperation.Add);
                    break;
                case EntityState.Modified:
                    TryAddLogEntity(entry.Entity, enLogOperation.Update);
                    break;
                case EntityState.Deleted:
                    TryAddLogEntity(entry.Entity, enLogOperation.Remove);
                    break;
                default:
                    continue;
            }
        }
    }


    private bool TryAddLogEntity(object entity, enLogOperation logOperation)
    {
        var entityType = entity.GetType();
        var reflectionInfo = _entitiesRelatedReflectionInfoCache.GetOrAdd(
            entityType.FullName ?? throw new InvalidOperationException($"Entity type don't have '{nameof(entityType.FullName)}' value from reflection"),
            CreateEntityRelatedReflectionInfo,
            entityType
        );
        if (!reflectionInfo.CanBeConvertedToLog)
            return false;


        var logRecordToAdd = ConvertEntityToLog(entity, entityType, reflectionInfo.LogType) as ILogEntity ?? throw new InvalidOperationException($"Log entity MUST implement '{nameof(ILogEntity)}' interface"); ;
        logRecordToAdd.ChangedOperation = logOperation;
        logRecordToAdd.ChangedDate = DateTime.UtcNow;


        var logs = reflectionInfo.LogsPropertyInfo.GetValue(entity) ?? throw new InvalidOperationException($"Not found value for '{nameof(IEntityWithLogs<ILogEntity>.Logs)}' property");
        reflectionInfo.LogsAddMethodInfo.Invoke(logs, [logRecordToAdd]);


        return true;
    }


    private static RecordRelatedReflectionInfo CreateEntityRelatedReflectionInfo(string cacheKey, Type entityType)
    {
        var reflectionInfo = new RecordRelatedReflectionInfo()
        {
            EntityWithLogsInterfaceType = entityType
                .GetInterfaces()
                .FirstOrDefault(x => x.IsGenericType && x.GetGenericTypeDefinition() == _entityWithLogsInterfaceType)
        };
        if (reflectionInfo.EntityWithLogsInterfaceType == null)
            return reflectionInfo;

        reflectionInfo.LogsPropertyInfo = entityType.GetProperty(nameof(IEntityWithLogs<ILogEntity>.Logs)) ?? throw new InvalidOperationException($"Not found '{nameof(IEntityWithLogs<ILogEntity>.Logs)}' property for '{nameof(IEntityWithLogs<ILogEntity>)}' type");
        reflectionInfo.LogsAddMethodInfo = reflectionInfo.LogsPropertyInfo.PropertyType.GetMethod(nameof(IEntityWithLogs<ILogEntity>.Logs.Add)) ?? throw new InvalidOperationException($"Not found '{nameof(IEntityWithLogs<ILogEntity>.Logs.Add)}' method for Logs property");
        reflectionInfo.LogType = reflectionInfo.LogsPropertyInfo.PropertyType.GenericTypeArguments[0];


        return reflectionInfo;
    }


    #region Abstract

    /// <summary>
    /// Преобразовать сущность в сущность её лога
    /// </summary>
    protected abstract object ConvertEntityToLog(object entity, Type sourceType, Type destinationType);

    #endregion Abstract

    #endregion Методы


    #region Вложенные типы

    private class RecordRelatedReflectionInfo
    {
        public Type? EntityWithLogsInterfaceType {  get; set; }

        public PropertyInfo? LogsPropertyInfo {  get; set; }

        public Type? LogType {  get; set; }

        public MethodInfo? LogsAddMethodInfo {  get; set; }


        [MemberNotNullWhen(true, nameof(EntityWithLogsInterfaceType))]
        [MemberNotNullWhen(true, nameof(LogsPropertyInfo))]
        [MemberNotNullWhen(true, nameof(LogType))]
        [MemberNotNullWhen(true, nameof(LogsAddMethodInfo))]
        public bool CanBeConvertedToLog => EntityWithLogsInterfaceType != null && LogsPropertyInfo != null && LogType != null && LogsAddMethodInfo != null;
    }

    #endregion Вложенные типы
}