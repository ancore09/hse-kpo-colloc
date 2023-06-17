using HealthTracker.Core.Models;

namespace HealthTracker.Core.Interfaces;

public interface IHealthRepository
{
    Task<long> AddNutritionInfoAsync(NutritionInfo nutritionInfo);
    Task<long> AddSleepInfoAsync(SleepInfo sleepInfo);
    Task<long> AddActivityInfoAsync(Activityinfo activityInfo);
    Task<(List<NutritionInfo>, List<SleepInfo>, List<Activityinfo>)> GetStatsAsync(DateTimeOffset from, DateTimeOffset to);
}