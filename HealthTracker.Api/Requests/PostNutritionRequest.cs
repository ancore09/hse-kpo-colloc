using System.ComponentModel.DataAnnotations;

namespace HealthTracker.Api.Requests;

public class PostNutritionRequest
{
    [Required]
    public DateTimeOffset Moment { get; set; }
    [Required]
    public string DishName { get; set; }
    [Required]
    [Range(1, int.MaxValue)]
    public int Calories { get; set; }
}