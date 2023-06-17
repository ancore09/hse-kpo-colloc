namespace HealthTracker.Core.Models;

public class NutritionInfo
{
    public DateTimeOffset Moment { get; set; }
    public string DishName { get; set; }
    public int Calories { get; set; }
}