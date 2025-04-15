using AutoMapper;
using KatServices.Common.Services.Base;
using System.Diagnostics;
using KatServices.Db.Entities.Base;
using Microsoft.EntityFrameworkCore;
using KatServices.Db.Context;
using KatServices.Db.Entities;


namespace KatServices.Common.Services.KatStorageService.Repository;


/// <inheritdoc cref="IKatStorageService"/>
public class KatStorageDbService : ServiceBase, IKatStorageService
{
    #region Поля

    private readonly IDbContextFactory<KatDbContext> _storageDbFactory;

    #endregion Поля


    #region Конструктор

    public KatStorageDbService(IDbContextFactory<KatDbContext> storageDbFactory, ILogger<IKatStorageService> logger, IMapper mapper, ActivitySource activitySource) : base(logger, mapper, activitySource)
    {
        _storageDbFactory = storageDbFactory;
    }

    #endregion Конструктор


    #region Методы

    #region MyAwesomeProduct

    /// <inheritdoc/>
    public async Task<TryAddOrUpdateBaseResult<MyAwesomeProduct>> TryAddOrUpdate(MyAwesomeProductBase recordToSet, CancellationToken cancellationToken = default)
    {
        using var tracingActivity = Trace.StartActivity();

        try
        {
            await using var entities = await _storageDbFactory.CreateDbContextAsync(cancellationToken: cancellationToken).ConfigureAwait(false);
            await using var transaction = await entities.Database.BeginTransactionAsync(cancellationToken: cancellationToken).ConfigureAwait(false);


            var existingRecord = await entities.MyAwesomeProducts
                .FirstOrDefaultAsync(x => x.Id == recordToSet.Id, cancellationToken: cancellationToken).ConfigureAwait(false);

            LogMyAwesomeProduct logRecord;

            // ADD NEW
            if (existingRecord == null)
            {
                var newRecord = Map.Map<MyAwesomeProduct>(recordToSet);
                await entities.MyAwesomeProducts.AddAsync(newRecord, cancellationToken: cancellationToken).ConfigureAwait(false);
                await entities.SaveChangesAsync(cancellationToken: cancellationToken).ConfigureAwait(false);

                // LOG
                logRecord = newRecord.ToLog<LogMyAwesomeProduct>(Map, enLogOperation.Add);
                await entities.LogMyAwesomeProducts.AddAsync(logRecord, cancellationToken: cancellationToken).ConfigureAwait(false);


                await entities.SaveChangesAsync(cancellationToken: cancellationToken).ConfigureAwait(false);
                await transaction.CommitAsync(cancellationToken: cancellationToken).ConfigureAwait(false);
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

            // LOG
            logRecord = existingRecord.ToLog<LogMyAwesomeProduct>(Map, enLogOperation.Update);
            await entities.LogMyAwesomeProducts.AddAsync(logRecord, cancellationToken: cancellationToken).ConfigureAwait(false);

            await entities.SaveChangesAsync(cancellationToken: cancellationToken).ConfigureAwait(false);
            await transaction.CommitAsync(cancellationToken: cancellationToken).ConfigureAwait(false);
            return new() { IsUpdated = true, Entity = existingRecord };
        }
        catch (Exception ex)
        {
            var exception = new ScopedException(ex, nameof(IKatStorageService));
            tracingActivity?.SetStatus(ActivityStatusCode.Error, description: exception.ToString());
            Log.LogError(exception, ex.Message);
            throw exception;
        }
    }


    /// <inheritdoc/>
    public async Task<List<MyAwesomeProduct>> GetMyAwesomeProducts(ICollection<Guid>? idsFilter = null, ICollection<enAwesomeProductType?>? productTypesFilter = null, bool includeReferences = false, bool includeLogs = false, CancellationToken cancellationToken = default)
    {
        using var tracingActivity = Trace.StartActivity();
        await using var entities = await _storageDbFactory.CreateDbContextAsync(cancellationToken: cancellationToken).ConfigureAwait(false);

        try
        {
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
            var exception = new ScopedException(ex, nameof(IKatStorageService));
            tracingActivity?.SetStatus(ActivityStatusCode.Error, description: exception.ToString());
            Log.LogError(exception, ex.Message);
            throw exception;
        }
    }


    /// <inheritdoc/>
    public async Task<bool> DeleteMyAwesomeProduct(Guid id, CancellationToken cancellationToken = default)
    {
        using var tracingActivity = Trace.StartActivity();

        try
        {
            await using var entities = await _storageDbFactory.CreateDbContextAsync(cancellationToken: cancellationToken).ConfigureAwait(false);


            var existingRecord = await entities.MyAwesomeProducts.FindAsync([id], cancellationToken: cancellationToken).ConfigureAwait(false);
            if (existingRecord == null)
                return false;

            entities.MyAwesomeProducts.Remove(existingRecord);

            // LOG
            var logRecord = existingRecord.ToLog<LogMyAwesomeProduct>(Map, enLogOperation.Remove);
            await entities.LogMyAwesomeProducts.AddAsync(logRecord, cancellationToken: cancellationToken).ConfigureAwait(false);

            await entities.SaveChangesAsync(cancellationToken: cancellationToken).ConfigureAwait(false);
            return true;
        }
        catch (Exception ex)
        {
            var exception = new ScopedException(ex, nameof(IKatStorageService));
            tracingActivity?.SetStatus(ActivityStatusCode.Error, description: exception.ToString());
            Log.LogError(exception, ex.Message);
            throw exception;
        }
    }

    #endregion MyAwesomeProduct

    #endregion Методы
}