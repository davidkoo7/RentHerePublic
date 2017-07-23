using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Quartz;
using Quartz.Impl;

/// <summary>
/// Summary description for QuartzScheduler
/// </summary>
public class QuartzScheduler
{
    public static void Start()
    {
        IJobDetail emailJob = JobBuilder.Create<QuartzTrigger>()
              .WithIdentity("job1")
              .Build();

        ITrigger trigger = TriggerBuilder.Create()
            .WithDailyTimeIntervalSchedule
              (s =>
                 s.WithIntervalInSeconds(30)
                .OnEveryDay()
              )
             .ForJob(emailJob)
             .WithIdentity("trigger1")
             .StartNow()
             .WithCronSchedule("0/30 0/1 * 1/1 * ? *") // Time : Every 1 Minutes job execute
             .Build();

        ISchedulerFactory sf = new StdSchedulerFactory();
        IScheduler sc = sf.GetScheduler();
        sc.ScheduleJob(emailJob, trigger);
        sc.Start();
    }
}