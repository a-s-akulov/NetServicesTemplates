using StackExchange.Redis;


namespace $safeprojectname$.Options;


public class DistributedCacheOptions
{
    public RedisConfigurationOptions Redis { get; init; }
}


public class RedisConfigurationOptions
{
    /// <inheritdoc cref="ConfigurationOptions.EndPoints"/>
    public ICollection<RedisEndpointConfigurationOptions>? EndPoints { get; init; }

    /// <inheritdoc cref="ConfigurationOptions.AbortOnConnectFail"/>
    public bool? AbortOnConnectFail { get; init; }

    /// <inheritdoc cref="ConfigurationOptions.AllowAdmin"/>
    public bool? AllowAdmin { get; init; }

    /// <inheritdoc cref="ConfigurationOptions.AsyncTimeout"/>
    public int? AsyncTimeout { get; init; }

    /// <inheritdoc cref="ConfigurationOptions.ClientName"/>
    public string? ClientName { get; set; }

    /// <inheritdoc cref="ConfigurationOptions.ConnectRetry"/>
    public int? ConnectRetry { get; init; }

    /// <inheritdoc cref="ConfigurationOptions.ConnectTimeout"/>
    public int? ConnectTimeout { get; init; }

    /// <inheritdoc cref="ConfigurationOptions.HeartbeatConsistencyChecks"/>
    public bool? HeartbeatConsistencyChecks { get; init; }

    /// <inheritdoc cref="ConfigurationOptions.HeartbeatInterval"/>
    public TimeSpan? HeartbeatInterval { get; init; }

    /// <inheritdoc cref="ConfigurationOptions.KeepAlive"/>
    public int? KeepAlive { get; init; }

    /// <inheritdoc cref="ConfigurationOptions.User"/>
    public string? User { get; init; }

    /// <inheritdoc cref="ConfigurationOptions.Password"/>
    public string? Password { get; init; }

    /// <inheritdoc cref="ConfigurationOptions.ResolveDns"/>
    public bool? ResolveDns { get; init; }

    /// <inheritdoc cref="ConfigurationOptions.Ssl"/>
    public bool? Ssl { get; init; }

    /// <inheritdoc cref="ConfigurationOptions.SslHost"/>
    public string? SslHost { get; init; }

    /// <inheritdoc cref="ConfigurationOptions.SslProtocols"/>
    public System.Security.Authentication.SslProtocols? SslProtocols { get; init; }

    /// <inheritdoc cref="ConfigurationOptions.SyncTimeout"/>
    public int? SyncTimeout { get; init; }

    /// <inheritdoc cref="ConfigurationOptions.ConfigCheckSeconds"/>
    public int? ConfigCheckSeconds { get; init; }
}


public class RedisEndpointConfigurationOptions
{
    public string Host { get; init; }

    public int Port { get; init; }
}