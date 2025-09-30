using Serilog;
using Serilog.Configuration;
using Serilog.Exceptions;
using Serilog.Exceptions.Core;
using Serilog.Exceptions.Destructurers;
using Serilog.Exceptions.EntityFrameworkCore.Destructurers;
using $safeprojectname$.Options.Base;


namespace $safeprojectname$.Configuration;


public static class SerilogConfigurationHostingExtensions
{
    public static IServiceCollection AddSerilogInApp(this IServiceCollection services, IConfiguration configuration, BaseAppOptions appOptions)
    {
        services.AddSerilog((serviceProvider, loggerConfiguration) =>
        {
            loggerConfiguration.ReadFrom.Configuration(configuration)
                .ReadFrom.Services(serviceProvider)
                .Enrich.WithProperty("App", appOptions.ServiceName);
        });


        return services;
    }


    public static LoggerConfiguration WithAppExceptionDetails(this LoggerEnrichmentConfiguration enrichmentConfiguration) =>
        enrichmentConfiguration.WithExceptionDetails(
            new DestructuringOptionsBuilder()
                .WithDefaultDestructurers()
                .WithDestructurers([
                    new DbUpdateExceptionDestructurer(),
                    new AutoMapperFailureFixExceptionDestructurer()
                ])
        );


    /// <summary>
    /// Деструктор для исправления падений при попытках логирования исключений AutoMapper
    /// <br/>Разбирает только базовые свойства исключения, без ReflectionBasedDestructurer
    /// </summary>
    public class AutoMapperFailureFixExceptionDestructurer() : ExceptionDestructurer
    {
        /// <inheritdoc />
        public override Type[] TargetTypes => new[] { typeof(AutoMapper.AutoMapperMappingException) };
    }
}