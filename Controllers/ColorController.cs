using System;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

// :: ---

namespace colorteller_dotnet.Controllers 
{
  [Route("/")]
  [ApiController]
  public class ColorController : ControllerBase
  {
    private readonly ILogger _logger;
    private readonly string color;

    public ColorController (ILogger<ColorController> logger) {
      this._logger = logger;

      // :: update color to be returned on invocation
      var _color = Environment.GetEnvironmentVariable("COLORTELLER_COLOR");
      this.color = string.IsNullOrEmpty(_color)
        ? "black"   // :: default color if none is specified
        : _color
        ;
    }

    // :: ---

    [HttpGet]
    public ActionResult<string> GetColor () 
    {
      this._logger.LogInformation($"color requested, responding with {this.color}.");
      return this.color;
    }

    [HttpGet("/ping")]
    public IActionResult GetPing ()
    {
      this._logger.LogInformation("ping requested, responding with OK.");
      return Ok();
    }
  }
}