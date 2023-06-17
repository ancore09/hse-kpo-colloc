namespace HealthTracker.Infrastructure.Entities;

public class ActivityInfoEntity
{
    public long Id { get; set; }
    public DateTimeOffset Moment { get; set; }
    public string ActivityName { get; set; }
    public int DurationMinutes { get; set; }
    public int Calories { get; set; }
}