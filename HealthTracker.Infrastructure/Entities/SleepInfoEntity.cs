namespace HealthTracker.Infrastructure.Entities;

public class SleepInfoEntity
{
    public long Id { get; set; }
    public DateTimeOffset Moment { get; set; }
    public int DurationMinutes { get; set; }
}