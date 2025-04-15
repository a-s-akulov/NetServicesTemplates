using KatServices.ScheduleJobs.Options;
using KatServices.Common.Configuration;


namespace KatServices.ScheduleJobs.Configuration;


public static class OptionsConfigurationHostingExtensions
{
    public static AppOptions ConfigureOptions(this IHostApplicationBuilder builder)
    {
        var appOptions = builder.Services.ConfigureOptions<AppOptions>(builder.Configuration);


        return appOptions;
    }
}
