using HealthTracker.Api.Models;
using Microsoft.AspNetCore.Mvc;

namespace HealthTracker.Api.Controllers;

[ApiController]
[Route("[controller]")]
public class TrackerController : ControllerBase
{
    private readonly ILogger<TrackerController> _logger;

    public TrackerController(ILogger<TrackerController> logger)
    {
        _logger = logger;
    }
    
    [HttpPost]
    [Route("activity")]
    public IActionResult PostActivity(Activityinfo activityInfo)
    {
        return Ok();
    }
    
    [HttpPost]
    [Route("activity")]
    public IActionResult PostActivity(Activityinfo activityInfo)
    {
        return Ok();
    }
}