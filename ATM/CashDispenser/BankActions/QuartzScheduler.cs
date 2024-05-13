using CashDispenser.Actions;
using Contracts;
using Quartz;
using Quartz.Impl;

namespace CashDispenser;

public class QuartzScheduler : IQuartzScheduler
{
    public async Task Start()
    {
        var schedulerFactory = new StdSchedulerFactory();
        var scheduler = await schedulerFactory.GetScheduler();
        await scheduler.Start();

        
        var accountTypeJob = JobBuilder.Create<MonthlyResetJob>()
            .WithIdentity("MonthlyResetJob", "AccountMaintenance")
            .Build();
        
        var balanceIncreaseJob = JobBuilder.Create<MonthlyResetJob>()
            .WithIdentity("IncreaseBalanceJob", "AccountMaintenance")
            .Build();

        
        var accountTypeTrigger = TriggerBuilder.Create()
            .WithIdentity("MonthlyResetTrigger", "AccountMaintenance")
            .StartNow()
            .WithSchedule(CronScheduleBuilder.MonthlyOnDayAndHourAndMinute(1, 0, 0)) 
            .Build();
        
        var balanceIncreaseTrigger = TriggerBuilder.Create()
            .WithIdentity("IncreaseBalanceTrigger", "AccountMaintenance")
            .StartNow()
            .WithSchedule(CronScheduleBuilder.MonthlyOnDayAndHourAndMinute(1, 0, 0)) 
            .Build();
        
        await scheduler.ScheduleJob(accountTypeJob, accountTypeTrigger);
        await scheduler.ScheduleJob(balanceIncreaseJob, balanceIncreaseTrigger);
    }
}