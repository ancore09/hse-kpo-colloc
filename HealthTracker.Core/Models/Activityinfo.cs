namespace HealthTracker.Core.Models;

public class Activityinfo
{
    public DateTimeOffset Moment { get; set; }
    public string ActivityName { get; set; }
    public int DurationMinutes { get; set; }
    public int Calories { get; set; }
}