﻿

namespace $safeprojectname$.Services.$ext_safeprojectname$StorageService;


public record TryAddOrUpdateBaseResult<TEntity> where TEntity : class
{
    public bool IsAdded { get; init; }

    public bool IsUpdated { get; init; }

    public bool IsNoChanges { get; init; }

    public TEntity Entity { get; init; }
}