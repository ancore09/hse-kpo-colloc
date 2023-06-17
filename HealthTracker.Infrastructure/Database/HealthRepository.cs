using HealthTracker.Core.Interfaces;
using HealthTracker.Core.Models;
using HealthTracker.Infrastructure.Entities;

namespace HealthTracker.Infrastructure.Database;

public class HealthRepository: IHealthRepository
{
    private static readonly List<NutritionInfo> NutritionInfos = new();
    private static readonly List<SleepInfo> SleepInfos = new();
    private static readonly List<Activityinfo> Activityinfos = new();
    
    private static long _nutritionInfoId = 0;
    private static long _sleepInfoId = 0;
    private static long _activityInfoId = 0;
    
    public async Task<long> AddNutritionInfoAsync(NutritionInfo nutritionInfo)
    {
        await Task.Yield();

        var entity = new NutrutionInfoEntity()
        {
            Id = Interlocked.Increment(ref _nutritionInfoId),
            Moment = nutritionInfo.Moment,
            DishName = nutritionInfo.DishName,
            Calories = nutritionInfo.Calories
        };
        
        NutritionInfos.Add(nutritionInfo);
        return entity.Id;
    }

    public async Task<long> AddSleepInfoAsync(SleepInfo sleepInfo)
    {
        await Task.Yield();
        
        var entity = new SleepInfoEntity()
        {
            Id = Interlocked.Increment(ref _sleepInfoId),
            Moment = sleepInfo.Moment,
            DurationMinutes = sleepInfo.DurationMinutes
        };
        
        SleepInfos.Add(sleepInfo);
        return entity.Id;
    }

    public async Task<long> AddActivityInfoAsync(Activityinfo activityInfo)
    {
        await Task.Yield();
        
        var entity = new ActivityInfoEntity()
        {
            Id = Interlocked.Increment(ref _activityInfoId),
            Moment = activityInfo.Moment,
            ActivityName = activityInfo.ActivityName,
            DurationMinutes = activityInfo.DurationMinutes,
            Calories = activityInfo.Calories
        };
        
        Activityinfos.Add(activityInfo);
        return entity.Id;
    }

    public async Task<(List<NutritionInfo>, List<SleepInfo>, List<Activityinfo>)> GetStatsAsync(DateTimeOffset from, DateTimeOffset to)
    {
        await Task.Yield();
        
        var nutritionInfos = NutritionInfos.Where(x => x.Moment >= from && x.Moment <= to);
        var sleepInfos = SleepInfos.Where(x => x.Moment >= from && x.Moment <= to);
        var activityInfos = Activityinfos.Where(x => x.Moment >= from && x.Moment <= to);
        
        return (nutritionInfos.ToList(), sleepInfos.ToList(), activityInfos.ToList());
    }
}