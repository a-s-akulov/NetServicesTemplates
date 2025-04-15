using System.Reflection;
using KatServices.Api.Configuration.MediatR.Behaviors;


namespace KatServices.Api.Configuration;


public static class MediatRConfigurationHostingExtensions
{
    public static IHostApplicationBuilder AddMediatRInApp(this IHostApplicationBuilder builder)
    {
        builder.Services.AddMediatR(cfg =>
        {
            cfg.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly());
            cfg.AddOpenBehavior(typeof(LoggingAndTracingBehavior<,>));
        });


        return builder;
    }
}
