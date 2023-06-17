namespace HealthTracker.Infrastructure.Entities;

public class NutrutionInfoEntity
{
    public long Id { get; set; }
    public DateTimeOffset Moment { get; set; }
    public string DishName { get; set; }
    public int Calories { get; set; }
}