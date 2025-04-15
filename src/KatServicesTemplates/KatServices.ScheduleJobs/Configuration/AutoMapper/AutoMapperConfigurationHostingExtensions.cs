using KatServices.Common.Configuration;


namespace KatServices.ScheduleJobs.Configuration;


public static class AutoMapperConfigurationHostingExtensions
{
    public static IHostApplicationBuilder AddAutoMapperInApp(this IHostApplicationBuilder builder)
    {
        builder.Services.AddAutoMapperInApp();

        return builder;
    }
}
