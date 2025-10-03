using Medallion.Threading;
using Medallion.Threading.Redis;
using Microsoft.Extensions.Caching.Hybrid;
using StackExchange.Redis;
using $safeprojectname$.Options;


namespace $safeprojectname$.Configuration;


public static class DistributedCacheConfigurationHostingExtensions
{
    public static IServiceCollection AddDistributedCacheInApp(this IServiceCollection services, DistributedCacheOptions options)
    {
        var redisOptions = options.Redis.ToRedisOptions();
        var redisConnection = ConnectionMultiplexer.Connect(redisOptions);
        var redisDatabase = redisConnection.GetDatabase();
        var provider = new RedisDistributedSynchronizationProvider(redisDatabase);

        // Distributed cache
        services.AddStackExchangeRedisCache(opt =>opt.ConfigurationOptions = redisOptions);
        services.AddHybridCache(opt =>
        {
            opt.DefaultEntryOptions = new HybridCacheEntryOptions
            {
                Expiration = TimeSpan.FromHours(1),
                LocalCacheExpiration = TimeSpan.FromHours(1)
            };
        });

        // Distributed lock
        services.AddSingleton<IDistributedLockProvider>(provider);
        services.AddSingleton<IDistributedReaderWriterLockProvider>(provider);
        services.AddSingleton<IDistributedSemaphoreProvider>(provider);


        return services;
    }


    public static ConfigurationOptions ToRedisOptions(this RedisConfigurationOptions src)
    {
        var dst = new ConfigurationOptions();

        if (src.EndPoints != null)
            foreach (var endPoint in src.EndPoints)
                dst.EndPoints.Add(endPoint.Host, endPoint.Port);

        if (src.AbortOnConnectFail != null)
            dst.AbortOnConnectFail = src.AbortOnConnectFail.Value;

        if (src.AllowAdmin != null)
            dst.AllowAdmin = src.AllowAdmin.Value;

        if (src.AsyncTimeout != null)
            dst.AsyncTimeout = src.AsyncTimeout.Value;

        if (src.ClientName != null)
            dst.ClientName = src.ClientName;

        if (src.ConnectRetry != null)
            dst.ConnectRetry = src.ConnectRetry.Value;

        if (src.ConnectTimeout != null)
            dst.ConnectTimeout = src.ConnectTimeout.Value;

        if (src.HeartbeatConsistencyChecks != null)
            dst.HeartbeatConsistencyChecks = src.HeartbeatConsistencyChecks.Value;

        if (src.HeartbeatInterval != null)
            dst.HeartbeatInterval = src.HeartbeatInterval.Value;

        if (src.KeepAlive != null)
            dst.KeepAlive = src.KeepAlive.Value;

        if (src.User != null)
            dst.User = src.User;

        if (src.Password != null)
            dst.Password = src.Password;

        if (src.ResolveDns != null)
            dst.ResolveDns = src.ResolveDns.Value;

        if (src.Ssl != null)
            dst.Ssl = src.Ssl.Value;

        if (src.SslHost != null)
            dst.SslHost = src.SslHost;

        if (src.SslProtocols != null)
            dst.SslProtocols = src.SslProtocols.Value;

        if (src.SyncTimeout != null)
            dst.SyncTimeout = src.SyncTimeout.Value;

        if (src.ConfigCheckSeconds != null)
            dst.ConfigCheckSeconds = src.ConfigCheckSeconds.Value;



        return dst;
    }
}