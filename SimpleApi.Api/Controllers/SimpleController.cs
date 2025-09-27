using Microsoft.AspNetCore.Mvc;

namespace SimpleApi.Api.Controllers
{
  [Route("api/")]
  [ApiController]
  public class SimpleController : ControllerBase
  {
    [HttpGet("ping")]
    public IActionResult Get()
    {
      return Ok("Pong");
    }
  }
}
