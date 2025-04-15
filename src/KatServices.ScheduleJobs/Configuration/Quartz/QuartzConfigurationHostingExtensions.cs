using Quartz;
using KatServices.ScheduleJobs.Options;
using KatServices.ScheduleJobs.Jobs;


namespace KatServices.ScheduleJobs.Configuration;


public static class QuartzConfigurationHostingExtensions
{
    public static IHostApplicationBuilder AddQuartzInApp(this IHostApplicationBuilder builder, AppOptions appOptions)
    {
        var dbConnectionOptions = appOptions.QuartzDbService;
        var connectionString = string.Format(
            dbConnectionOptions.ConnectionString,
            dbConnectionOptions.Username,
            dbConnectionOptions.Password
        );


        builder.Services.AddQuartz(quartz =>
        {
            // MyAwesomeProductsImportJob
            quartz.AddJob<MyAwesomeProductsImportJob>(jobKey: MyAwesomeProductsImportJob.Key, jobOpt => jobOpt.DisallowConcurrentExecution(true));
            quartz.AddTrigger(trigOpt =>
            {
                trigOpt
                    .WithIdentity($"trigger-{MyAwesomeProductsImportJob.Key.Name}", MyAwesomeProductsImportJob.Key.Group)
                    .ForJob(MyAwesomeProductsImportJob.Key)
                    .WithSimpleSchedule(trigScheduleOpt =>
                    {
                        trigScheduleOpt.WithIntervalInSeconds(60) // TODO: TO PARAM
                            .RepeatForever()
                            .WithMisfireHandlingInstructionIgnoreMisfires();
                    })
                    .StartNow();
            });




            quartz.InterruptJobsOnShutdownWithWait = true;
            quartz.UsePersistentStore(storeOpt =>
            {
                storeOpt.PerformSchemaValidation = true;
                storeOpt.UseSystemTextJsonSerializer();
                storeOpt.UsePostgres(sqlOpt =>
                {
                    sqlOpt.ConnectionString = connectionString;
                });
            });
        });


        builder.Services.AddQuartzHostedService(opt =>
        {
            opt.WaitForJobsToComplete = true;
            opt.AwaitApplicationStarted = true;
        });


        return builder;
    }
}
