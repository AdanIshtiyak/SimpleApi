using Microsoft.AspNetCore.Mvc;
using SimpleApi.Services.Interfaces;

namespace SimpleApi.Api.Controllers
{
  [ApiController]
  [Route("api/health")]
  public class HealthController : ControllerBase
  {
    private readonly IHealthServices _healthService;

    public HealthController(IHealthServices healthService)
    {
      _healthService = healthService;
    }

    [HttpGet("database")]
    public async Task<IActionResult> GetDatabaseHealth()
    {
      var isHealthy = await _healthService.CheckDatabaseHealth();

      return isHealthy ? Ok(new { status = "Healthy", db = "Connected" }) :
        StatusCode(503, new { status = "Unhealthy", db = "Not Connected" });
    }
  }
}
