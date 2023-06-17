using HealthTracker.Core.Interfaces;
using HealthTracker.Core.Models;

namespace HealthTracker.Core.Services;

public class StatsAggregatorService: IStatsAggregator
{
    private readonly IHealthRepository _healthRepository;
    
    public StatsAggregatorService(IHealthRepository healthRepository)
    {
        _healthRepository = healthRepository;
    }
    
    public async Task<Stats> GetStatsAsync(DateTimeOffset from, DateTimeOffset to)
    {
        var records = await _healthRepository.GetStatsAsync(from, to);
        
        var totalCalories = records.Item1.Sum(x => x.Calories);
        var totalSleepDurationMinutes = records.Item2.Sum(x => x.DurationMinutes);
        var totalActivity = records.Item3.Sum(x => x.DurationMinutes);
        var averageCalories = totalCalories / to.Subtract(from).TotalDays;
        var averageSleepDurationMinutes = totalSleepDurationMinutes / to.Subtract(from).TotalDays;
        var averageActivity = totalActivity / to.Subtract(from).TotalDays;
        
        var stats = new Stats
        {
            From = from,
            To = to,
            TotalCalories = totalCalories,
            TotalSleepDurationMinutes = totalSleepDurationMinutes,
            TotalActivity = totalActivity,
            AverageCalories = averageCalories,
            AverageSleepDurationMinutes = averageSleepDurationMinutes,
            AverageActivity = averageActivity
        };
        
        return stats;
    }
}