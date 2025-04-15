using KatServices.Api.Configuration;
using KatServices.Api.Configuration.Middleware;


namespace KatServices.Api;


public static class Startup
{
    public static WebApplicationBuilder ConfigureServices(this WebApplicationBuilder builder)
    {
        var options = builder.ConfigureOptions();

        builder.AddControllersInApp();
        builder.Services.AddHealthChecks();
        builder.Services.AddMemoryCache();

        builder.AddJsonSerializerInApp();                                       // JsonSerializer
        builder.AddSwaggerInApp(options);                                       // Swagger
        builder.AddApiVersioningInApp();                                        // ApiVersioning
        builder.AddSerilogInApp();                                              // Serilog
        builder.AddAccessApiAuthenticationInApp(options);                       // AccessApi
        builder.AddAutoMapperInApp();                                           // AutoMapper
        builder.AddMediatRInApp();                                              // MediatR
        builder.AddOpenTelemetryInApp();                                        // OpenTelemetry

        builder.AddPartnersApiServiceInApp(options);
        builder.AddKatStorageDbServiceInApp(options);



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
