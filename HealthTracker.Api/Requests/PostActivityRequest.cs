using System.ComponentModel.DataAnnotations;

namespace HealthTracker.Api.Requests;

public class PostActivityRequest
{
    [Required]
    public DateTimeOffset Moment { get; set; }
    [Required]
    public string ActivityName { get; set; }
    [Required]
    [Range(1, int.MaxValue)]
    public int DurationMinutes { get; set; }
    [Required]
    [Range(1, int.MaxValue)]
    public int Calories { get; set; }
}