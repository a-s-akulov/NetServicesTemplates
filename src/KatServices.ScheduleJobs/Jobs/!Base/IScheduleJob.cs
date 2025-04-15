using Quartz;


namespace KatServices.ScheduleJobs.Jobs.Base;


public interface IScheduleJob<TJob> : IJob where TJob : IScheduleJob<TJob>
{
    /// <summary>
    /// Идентификатор типа джобы
    /// </summary>
    public JobKey JobKey { get; }
}