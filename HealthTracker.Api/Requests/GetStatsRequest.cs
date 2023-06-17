using System.ComponentModel.DataAnnotations;

namespace HealthTracker.Api.Requests;

public class GetStatsRequest
{
    [Required]
    public DateTimeOffset? StartDate { get; set; }
    [Required]
    public DateTimeOffset? EndDate { get; set; }
}