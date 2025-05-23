﻿using System.Reflection;
using Microsoft.Extensions.DependencyInjection;


namespace $safeprojectname$.Configuration;


public static class AutoMapperConfigurationHostingExtensions
{
    public static IServiceCollection AddAutoMapperInApp(this IServiceCollection services)
    {
        services.AddAutoMapper(
            [
                Assembly.GetEntryAssembly(),
                Assembly.GetAssembly(typeof(AutoMapperConfigurationHostingExtensions))
            ],
            ServiceLifetime.Singleton
        );


        return services;
    }
}
