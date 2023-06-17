using HealthTracker.Api.Requests;
using HealthTracker.Core.Interfaces;
using HealthTracker.Core.Models;
using Microsoft.AspNetCore.Mvc;

namespace HealthTracker.Api.Controllers;

[ApiController]
[Route("[controller]")]
public class TrackerController : ControllerBase
{
    private readonly ILogger<TrackerController> _logger;
    private readonly IStatsAggregator _statsAggregator;
    private readonly IHealthRepository _healthRepository;

    public TrackerController(
        ILogger<TrackerController> logger, 
        IStatsAggregator statsAggregator, 
        IHealthRepository healthRepository)
    {
        _logger = logger;
        _statsAggregator = statsAggregator;
        _healthRepository = healthRepository;
    }
    
    [HttpPost]
    [Route("activity")]
    public async Task<IActionResult> PostActivity(PostActivityRequest request)
    {
        var model = new Activityinfo()
        {
            ActivityName = request.ActivityName,
            DurationMinutes = request.DurationMinutes,
            Calories = request.Calories,
            Moment = request.Moment
        };
        var id = await _healthRepository.AddActivityInfoAsync(model);
        return Ok(id);
    }
    
    [HttpPost]
    [Route("nutrition")]
    public async Task<IActionResult> PostNutrition(PostNutritionRequest request)
    {
        var model = new NutritionInfo()
        {
            DishName = request.DishName,
            Calories = request.Calories,
            Moment = request.Moment
        };
        var id = await _healthRepository.AddNutritionInfoAsync(model);
        return Ok(id);
    }
    
    [HttpPost]
    [Route("sleep")]
    public async Task<IActionResult> PostSleep(PostSleepRequest request)
    {
        var model = new SleepInfo()
        {
            DurationMinutes = request.DurationMinutes,
            Moment = request.Moment
        };
        var id = await _healthRepository.AddSleepInfoAsync(model);
        return Ok(id);
    }
    
    [HttpPost]
    [Route("stats")]
    public async Task<IActionResult> GetStats(GetStatsRequest request)
    {
        var from = request.StartDate!.Value;
        var to = request.EndDate!.Value;
        var stats = await _statsAggregator.GetStatsAsync(from, to);
        return Ok(stats);
    }
}