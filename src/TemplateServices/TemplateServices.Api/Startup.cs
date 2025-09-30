using $safeprojectname$.Configuration;
using $safeprojectname$.Configuration.Middleware;


namespace $safeprojectname$;


public static class Startup
{
    public static WebApplicationBuilder ConfigureServices(this WebApplicationBuilder builder)
    {
        var options = builder.ConfigureOptions();

        builder.Services.AddHealthChecks();
        builder.Services.AddMemoryCache();

        builder.AddControllersInApp();                                          // Controllers
        builder.AddJsonSerializerInApp();                                       // JsonSerializer
        builder.AddSwaggerInApp(options);                                       // Swagger
        builder.AddApiVersioningInApp();                                        // ApiVersioning
        builder.AddSerilogInApp(options);                                       // Serilog
        builder.AddAccessApiAuthenticationInApp(options);                       // AccessApi
        builder.AddAutoMapperInApp();                                           // AutoMapper
        builder.AddMediatRInApp();                                              // MediatR
        builder.AddOpenTelemetryInApp();                                        // OpenTelemetry
        builder.AddMetricsInApp();                                              // Metrics
        builder.AddDistributedCacheInApp(options);                              // Distributed cache

        builder.AddPartnersApiServiceInApp(options);
        builder.Add$ext_safeprojectname$StorageDbServiceInApp(options);



        return builder;
    }




    public static WebApplication ConfigureApplication(this WebApplication app)
    {
        app.UseSwaggerInApp();


        app.UseRouting();

        if (app.Environment.IsProduction())
        {
            app.UseHsts();
        }

        app.UseHttpsRedirection();
        app.UseAuthorization();
        app.UseMiddleware<ExceptionMiddleware>();

        app.MapControllers();
        app.MapHealthChecks("/healthz");

        return app;
    }
}
