using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using Quartz;
using Quartz.Impl;

/// <summary>
/// Summary description for QuartzScheduler
/// </summary>
public class QuartzSchedulerForEmail
{
    public static void Start()
    {
        IJobDetail emailJob = JobBuilder.Create<QuartzTriggerForEmail>()
              .WithIdentity("job2")
              .Build();

        ITrigger trigger = TriggerBuilder.Create()
            .WithDailyTimeIntervalSchedule
              (s =>
                 s.WithIntervalInSeconds(30)
                .OnEveryDay()
              )
             .ForJob(emailJob)
             .WithIdentity("trigger2")
             .StartNow()
             .WithCronSchedule("0 0 12 * * ?")
             .Build();

        ISchedulerFactory sf = new StdSchedulerFactory();
        IScheduler sc = sf.GetScheduler();
        sc.ScheduleJob(emailJob, trigger);
        sc.Start();
    }
}