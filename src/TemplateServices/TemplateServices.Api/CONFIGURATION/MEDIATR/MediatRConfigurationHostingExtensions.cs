using System.Reflection;
using $safeprojectname$.Configuration.MediatR.Behaviors;


namespace $safeprojectname$.Configuration;


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
