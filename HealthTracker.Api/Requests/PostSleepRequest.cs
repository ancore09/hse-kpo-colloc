using System.ComponentModel.DataAnnotations;

namespace HealthTracker.Api.Requests;

public class PostSleepRequest
{
    [Required]
    public DateTimeOffset Moment { get; set; }
    [Required]
    [Range(1, int.MaxValue)]
    public int DurationMinutes { get; set; }
}