﻿using AutoMapper;
using $safeprojectname$.Services.Base;
using System.Diagnostics;
using $ext_safeprojectname$Services.Db.Entities.Base;
using Microsoft.EntityFrameworkCore;
using $ext_safeprojectname$Services.Db.Entities;


namespace $safeprojectname$.Services.$ext_safeprojectname$StorageService.Repository;


/// <inheritdoc cref="I$ext_safeprojectname$StorageService"/>
public class $ext_safeprojectname$StorageDbService : ServiceBase, I$ext_safeprojectname$StorageService
{
    #region Поля

    private readonly IDbContextFactory<$ext_safeprojectname$AutoMapperConverterContext> _storageDbFactory;

    #endregion Поля


    #region Конструктор

    public $ext_safeprojectname$StorageDbService(IDbContextFactory<$ext_safeprojectname$AutoMapperConverterContext> storageDbFactory, ILogger<I$ext_safeprojectname$StorageService> logger, IMapper mapper, ActivitySource activitySource) : base(logger, mapper, activitySource)
    {
        _storageDbFactory = storageDbFactory;
    }

    #endregion Конструктор


    #region Методы

    #region Common

    /// <inheritdoc/>
    public async Task<StorageDataMetrics> GetStorageDataMetrics(CancellationToken cancellationToken = default)
    {
        using var tracingActivity = Trace.StartActivity();

        try
        {
            await using var entities = await _storageDbFactory.CreateDbContextAsync(cancellationToken: cancellationToken).ConfigureAwait(false);


            // myAwesomeProductsAllCount
            var myAwesomeProductsAllCount = await entities
                .MyAwesomeProducts
                .CountAsync(cancellationToken: cancellationToken)
                .ConfigureAwait(false);

            // myAwesomeProductsBooksAllCount
            var myAwesomeProductsBooksAllCountProductTypesInclude = new enAwesomeProductType?[] {
                enAwesomeProductType.Books
            };
            var myAwesomeProductsBooksAllCount = await entities
                .MyAwesomeProducts
                .CountAsync(x => myAwesomeProductsBooksAllCountProductTypesInclude.Contains(x.ProductType), cancellationToken: cancellationToken)
                .ConfigureAwait(false);

            // myAwesomeProductsFoodAllCount
            var myAwesomeProductsFoodAllCountProductTypesInclude = new enAwesomeProductType?[] {
                enAwesomeProductType.Food
            };
            var myAwesomeProductsFoodAllCount = await entities
                .MyAwesomeProducts
                .CountAsync(x => myAwesomeProductsFoodAllCountProductTypesInclude.Contains(x.ProductType), cancellationToken: cancellationToken)
                .ConfigureAwait(false);

            // myAwesomeProductsCarsAllCount
            var myAwesomeProductsCarsAllCountProductTypesInclude = new enAwesomeProductType?[] {
                enAwesomeProductType.Cars
            };
            var myAwesomeProductsCarsAllCount = await entities
                .MyAwesomeProducts
                .CountAsync(x => myAwesomeProductsCarsAllCountProductTypesInclude.Contains(x.ProductType), cancellationToken: cancellationToken)
                .ConfigureAwait(false);


            var result = new StorageDataMetrics()
            {
                MyAwesomeProductsAllCount = myAwesomeProductsAllCount,
                MyAwesomeProductsBooksAllCount = myAwesomeProductsBooksAllCount,
                MyAwesomeProductsFoodAllCount = myAwesomeProductsFoodAllCount,
                MyAwesomeProductsCarsAllCount = myAwesomeProductsCarsAllCount
            };
            return result;
        }
        catch (Exception ex)
        {
            var exception = new ScopedException(ex, nameof(I$ext_safeprojectname$StorageService));
            tracingActivity?.SetStatus(ActivityStatusCode.Error, description: exception.ToString());
            Log.LogError(exception, ex.Message);
            throw exception;
        }
    }

    #endregion Common


    #region MyAwesomeProduct

    /// <inheritdoc/>
    public async Task<TryAddOrUpdateBaseResult<MyAwesomeProduct>> TryAddOrUpdate(MyAwesomeProductBase recordToSet, CancellationToken cancellationToken = default)
    {
        using var tracingActivity = Trace.StartActivity();

        try
        {
            await using var entities = await _storageDbFactory.CreateDbContextAsync(cancellationToken: cancellationToken).ConfigureAwait(false);


            var existingRecord = await entities.MyAwesomeProducts
                .FirstOrDefaultAsync(x => x.Id == recordToSet.Id, cancellationToken: cancellationToken).ConfigureAwait(false);

            LogMyAwesomeProduct logRecord;

            // ADD NEW
            if (existingRecord == null)
            {
                var newRecord = Map.Map<MyAwesomeProduct>(recordToSet);
                await entities.MyAwesomeProducts.AddAsync(newRecord, cancellationToken: cancellationToken).ConfigureAwait(false);
                await entities.SaveChangesAsync(cancellationToken: cancellationToken).ConfigureAwait(false);
                return new() { IsAdded = true, Entity = newRecord };
            }

            // UPDATE EXISTING
            if (
                    existingRecord.Name == recordToSet.Name
                    && existingRecord.ProductType == recordToSet.ProductType
                )
                return new() { IsNoChanges = true, Entity = existingRecord };

            existingRecord.Name = recordToSet.Name;
            existingRecord.ProductType = recordToSet.ProductType;

            await entities.SaveChangesAsync(cancellationToken: cancellationToken).ConfigureAwait(false);
            return new() { IsUpdated = true, Entity = existingRecord };
        }
        catch (Exception ex)
        {
            var exception = new ScopedException(ex, nameof(I$ext_safeprojectname$StorageService));
            tracingActivity?.SetStatus(ActivityStatusCode.Error, description: exception.ToString());
            Log.LogError(exception, ex.Message);
            throw exception;
        }
    }


    /// <inheritdoc/>
    public async Task<List<MyAwesomeProduct>> GetMyAwesomeProducts(ICollection<long>? idsFilter = null, ICollection<enAwesomeProductType?>? productTypesFilter = null, bool includeReferences = false, bool includeLogs = false, CancellationToken cancellationToken = default)
    {
        using var tracingActivity = Trace.StartActivity();

        try
        {
            await using var entities = await _storageDbFactory.CreateDbContextAsync(cancellationToken: cancellationToken).ConfigureAwait(false);


            var query = entities.MyAwesomeProducts
                .AsNoTracking();

            if (idsFilter != null)
                query = query.Where(x => idsFilter.Contains(x.Id));

            if (productTypesFilter != null && productTypesFilter.Count > 0)
            {
                query = query
                    .Where(x => productTypesFilter.Contains(x.ProductType));
            }

            if (includeReferences)
            {
                // MyAwesomeProduct пока не имеет  взаимосвязанных объектов
                //
                //query = query
                //    .Include(x => x.ShopsWithProduct)
                //    .Include(x => x.Dimensions)
                //    .Include(x => x.SupplierInfo);
            }

            if (includeLogs)
                query = query.Include(x => x.Logs);


            var result = await query
                .ToListAsync(cancellationToken: cancellationToken)
                .ConfigureAwait(false);

            return result;
        }
        catch (Exception ex)
        {
            var exception = new ScopedException(ex, nameof(I$ext_safeprojectname$StorageService));
            tracingActivity?.SetStatus(ActivityStatusCode.Error, description: exception.ToString());
            Log.LogError(exception, ex.Message);
            throw exception;
        }
    }


    /// <inheritdoc/>
    public async Task<bool> DeleteMyAwesomeProduct(long id, CancellationToken cancellationToken = default)
    {
        using var tracingActivity = Trace.StartActivity();

        try
        {
            await using var entities = await _storageDbFactory.CreateDbContextAsync(cancellationToken: cancellationToken).ConfigureAwait(false);


            var existingRecord = await entities.MyAwesomeProducts.FindAsync([id], cancellationToken: cancellationToken).ConfigureAwait(false);
            if (existingRecord == null)
                return false;

            entities.MyAwesomeProducts.Remove(existingRecord);

            await entities.SaveChangesAsync(cancellationToken: cancellationToken).ConfigureAwait(false);
            return true;
        }
        catch (Exception ex)
        {
            var exception = new ScopedException(ex, nameof(I$ext_safeprojectname$StorageService));
            tracingActivity?.SetStatus(ActivityStatusCode.Error, description: exception.ToString());
            Log.LogError(exception, ex.Message);
            throw exception;
        }
    }

    #endregion MyAwesomeProduct

    #endregion Методы
}