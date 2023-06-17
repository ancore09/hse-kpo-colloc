using HealthTracker.Core.Models;

namespace HealthTracker.Core.Interfaces;

public interface IStatsAggregator
{
    Task<Stats> GetStatsAsync(DateTimeOffset from, DateTimeOffset to);
}