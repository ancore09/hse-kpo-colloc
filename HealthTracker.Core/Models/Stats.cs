namespace HealthTracker.Core.Models;

public class Stats
{
    public DateTimeOffset From { get; set; }
    public DateTimeOffset To { get; set; }
    public int TotalCalories { get; set; }
    public int TotalSleepDurationMinutes { get; set; }
    public int TotalActivity { get; set; }
    
    public double AverageCalories { get; set; }
    public double AverageSleepDurationMinutes { get; set; }
    public double AverageActivity { get; set; }
}